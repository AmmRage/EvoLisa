using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Threading;
using System.Windows.Forms;
using GenArt.AST;
using GenArt.Classes;

namespace GenArt
{
    public partial class MainForm : Form
    {
        #region attributes
        public static Settings Settings;
        private DnaDrawing _currentDrawing;

        private double _errorLevel = double.MaxValue;
        private int _generation;
        private DnaDrawing _guiDrawing;
        private bool _isRunning;
        private DateTime _lastRepaint = DateTime.MinValue;
        private int _lastSelected;
        private TimeSpan _repaintIntervall = new TimeSpan(0, 0, 0, 0, 0);
        private int _repaintOnSelectedSteps = 3;
        private int _selected;
        private SettingsForm _settingsForm;
        private Color[,] _sourceColors;

        private Thread _thread;
        #endregion

        #region init
        public MainForm()
        {
            InitializeComponent();

            picPattern.Image = Properties.Resources.ml1;

            Settings = Serializer.DeserializeSettings();
            if (Settings == null)
                Settings = new Settings();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.picPattern.Image = Image.FromFile(@"C:\Users\ZhiYong\Pictures\pr\925681127.jpg");
            Tools.MaxHeight = this.picPattern.Height;
            Tools.MaxWidth = this.picPattern.Width;
            SetCanvasSize();
            this.splitContainer1.SplitterDistance = this.picPattern.Width + 30;
        }

        private static DnaDrawing GetNewInitializedDrawing()
        {
            var drawing = new DnaDrawing();
            drawing.Init();
            return drawing;
        }
        #endregion

        #region controls event handler 
        
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (this._isRunning)
                Stop();
            else
                Start();
        }

        /// <summary>
        /// show draw status
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrRedraw_Tick(object sender, EventArgs e)
        {
            if (this._currentDrawing == null)
                return;

            var polygons = this._currentDrawing.Polygons.Count;
            var points = this._currentDrawing.PointCount;
            double avg = 0;
            if (polygons != 0)
                avg = points/polygons;

            this.toolStripStatusLabelFitness.Text = this._errorLevel.ToString();
            this.toolStripStatusLabelGeneration.Text = this._generation.ToString();
            this.toolStripStatusLabelSelected.Text = this._selected.ToString();
            this.toolStripStatusLabelPoints.Text = points.ToString();
            this.toolStripStatusLabelPolygons.Text = polygons.ToString();
            this.toolStripStatusLabelAvgPoints.Text = avg.ToString();

            var shouldRepaint = false;
            if (this._repaintIntervall.Ticks > 0)
                if (this._lastRepaint < DateTime.Now - this._repaintIntervall)
                    shouldRepaint = true;

            if (this._repaintOnSelectedSteps > 0)
                if (this._lastSelected + this._repaintOnSelectedSteps < this._selected)
                    shouldRepaint = true;

            if (shouldRepaint)
            {
                lock (this._currentDrawing)
                {
                    this._guiDrawing = this._currentDrawing.Clone();
                }
                this.pnlCanvas.Invalidate();
                this._lastRepaint = DateTime.Now;
                this._lastSelected = this._selected;
            }
        }

        private void pnlCanvas_Paint(object sender, PaintEventArgs e)
        {
            if (this._guiDrawing == null)
            {
                e.Graphics.Clear(Color.Black);
                return;
            }
            using ( var backBuffer = new Bitmap(this.trackBarScale.Value*this.picPattern.Width, this.trackBarScale.Value*this.picPattern.Height, PixelFormat.Format24bppRgb))
            using (var backGraphics = Graphics.FromImage(backBuffer))
            {
                backGraphics.SmoothingMode = SmoothingMode.HighQuality;
                Renderer.Render(this._guiDrawing, backGraphics, this.trackBarScale.Value);
                e.Graphics.DrawImage(backBuffer, 0, 0);
            }
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this._settingsForm != null)
                if (this._settingsForm.IsDisposed)
                    this._settingsForm = null;

            if (this._settingsForm == null)
                this._settingsForm = new SettingsForm();

            this._settingsForm.Show();
        }

        private void sourceImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenImage();
        }

        private void dNAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenDna();
        }

        private void dNAToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveDna();
        }

        private void trackBarScale_Scroll(object sender, EventArgs e)
        {
            SetCanvasSize();
        }

        #endregion

        //covnerts the source image to a Color[,] for faster lookup
        private void SetupSourceColorMatrix()
        {
            this._sourceColors = new Color[Tools.MaxWidth,Tools.MaxHeight];
            var sourceImage = this.picPattern.Image as Bitmap;
            
            if (sourceImage == null)
                throw new NotSupportedException("A source image of Bitmap format must be provided");

            for (var y = 0; y < Tools.MaxHeight; y++)
            {
                for (var x = 0; x < Tools.MaxWidth; x++)
                {
                    var c = sourceImage.GetPixel(x, y);
                    this._sourceColors[x, y] = c;
                }
            }
        }

        private void StartEvolution()
        {
            Trace.WriteLine("StartEvolution");
            SetupSourceColorMatrix();
            if (this._currentDrawing == null)
                this._currentDrawing = GetNewInitializedDrawing();
            this._lastSelected = 0;

            Trace.WriteLine("Processing");
            while (this._isRunning)
            {
                DnaDrawing newDrawing;
                lock (this._currentDrawing)
                {
                    newDrawing = this._currentDrawing.Clone();
                }
                newDrawing.Mutate(); //Mutate, 突变

                if (newDrawing.IsDirty)
                {
                    this._generation++;

                    var newErrorLevel = FitnessCalculator.GetDrawingFitness(newDrawing, this._sourceColors);

                    if (newErrorLevel <= this._errorLevel)
                    {
                        this._selected++;
                        lock (this._currentDrawing)
                        {
                            this._currentDrawing = newDrawing;
                        }
                        this._errorLevel = newErrorLevel;
                    }
                }
                //else, discard new drawing
            }
        }

        private void Start()
        {
            Trace.WriteLine("Stop processing");
            this.btnStart.Text = "Stop";
            this._isRunning = true;
            this.tmrRedraw.Enabled = true;

            if (this._thread != null)
                KillThread();

            this._thread = new Thread(StartEvolution)
            {
                IsBackground = true,
                Priority = ThreadPriority.AboveNormal
            };
            this._thread.Start();
        }

        private void KillThread()
        {
            if (this._thread != null)
            {
                this._thread.Abort();
            }
            this._thread = null;
        }

        private void Stop()
        {
            Trace.WriteLine("Stop processing");
            if (this._isRunning)
                KillThread();

            this.btnStart.Text = "Start";
            this._isRunning = false;
            this.tmrRedraw.Enabled = false;
        }

        private void OpenImage()
        {
            Stop();

            var fileName = FileUtil.GetOpenFileName(FileUtil.ImgExtension);
            if (string.IsNullOrEmpty(fileName))
                return;

            this.picPattern.Image = Image.FromFile(fileName);

            Tools.MaxHeight = this.picPattern.Height;
            Tools.MaxWidth = this.picPattern.Width;

            SetCanvasSize();

            this.splitContainer1.SplitterDistance = this.picPattern.Width + 30;
        }

        private void SetCanvasSize()
        {
            this.pnlCanvas.Height = this.trackBarScale.Value * this.picPattern.Height;
            this.pnlCanvas.Width = this.trackBarScale.Value * this.picPattern.Width;
        }

        private void OpenDna()
        {
            Stop();

            var drawing = Serializer.DeserializeDnaDrawing(FileUtil.GetOpenFileName(FileUtil.DnaExtension));
            if (drawing != null)
            {
                if (this._currentDrawing == null)
                    this._currentDrawing = GetNewInitializedDrawing();

                lock (this._currentDrawing)
                {
                    this._currentDrawing = drawing;
                    this._guiDrawing = this._currentDrawing.Clone();
                }
                this.pnlCanvas.Invalidate();
                this._lastRepaint = DateTime.Now;
            }
        }

        private void SaveDna()
        {
            var fileName = FileUtil.GetSaveFileName(FileUtil.DnaExtension);
            if (string.IsNullOrEmpty(fileName) == false && this._currentDrawing != null)
            {
                DnaDrawing clone = null;
                lock (this._currentDrawing)
                {
                    clone = this._currentDrawing.Clone();
                }
                if (clone != null)
                    Serializer.Serialize(clone, fileName);
            }
        }

        private void toolStripMenuItemSavePic_Click(object sender, EventArgs e)
        {
            try
            {
                //new Bitmap(this.picPattern.Image).Save("Generated_" + DateTime.Now.ToString("hhmmss") + ".bmp");
                using (var bmp = new Bitmap(this.trackBarScale.Value * this.picPattern.Width, this.trackBarScale.Value * this.picPattern.Height, PixelFormat.Format24bppRgb))
                using (var g = Graphics.FromImage(bmp))
                {
                    g.SmoothingMode = SmoothingMode.HighQuality;
                    Renderer.Render(this._guiDrawing, g, this.trackBarScale.Value);
                    g.DrawImage(bmp, 0, 0);
                    bmp.Save("Generated_" + DateTime.Now.ToString("hhmmss") + ".bmp");
                }
                MessageBox.Show("Successfully saved", "Notice");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error");
            }
        }
    }
}