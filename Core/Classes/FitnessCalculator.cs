using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using GenArt.AST;
using System.Linq;

namespace GenArt.Classes
{
    public static class FitnessCalculator
    {
        public static double GetDrawingFitness(DnaDrawing newDrawing, Color[,] sourceColors)
        {
            double error = 0;

            using (var bmp = new Bitmap(Tools.MaxWidth, Tools.MaxHeight, PixelFormat.Format24bppRgb))
            using (var g = Graphics.FromImage(bmp))
            {
                Renderer.Render(newDrawing, g, 1);
                var bmpData = bmp.LockBits(new Rectangle(0, 0, Tools.MaxWidth, Tools.MaxHeight), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

                for (var y = 0; y < Tools.MaxHeight; y++)
                {
                    for (var x = 0; x < Tools.MaxWidth; x++)
                    {
                        var c1 = GetPixel(bmpData, x, y);
                        var c2 = sourceColors[x, y];

                        var pixelError = GetColorFitness(c1, c2);
                        error += pixelError;
                    }
                }
                bmp.UnlockBits(bmpData);
            }
            return error;
        }

        public static double GetDrawingFitness(DnaDrawing newDrawing, byte[] sourceByteContent, double lastError)
        {
            double error = 0;

            using (var bmp = new Bitmap(Tools.MaxWidth, Tools.MaxHeight, PixelFormat.Format24bppRgb))
            using (var g = Graphics.FromImage(bmp))
            {
                Renderer.Render(newDrawing, g, 1);
                var bmpData = bmp.LockBits(new Rectangle(0, 0, Tools.MaxWidth, Tools.MaxHeight), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

                var bytes = new byte[sourceByteContent.Length];
                Marshal.Copy(bmpData.Scan0, bytes, 0, bytes.Length);

                for (var i = 0; i < sourceByteContent.Length; i++)
                {
                    error += (sourceByteContent[i] - bytes[i])*(sourceByteContent[i] - bytes[i]);
                    //if (error > lastError)
                    //    return double.MaxValue;
                }
                bmp.UnlockBits(bmpData);
            }
            return error;
        }

        private static unsafe Color GetPixel(BitmapData bmd, int x, int y)
        {
            var p = (byte*) bmd.Scan0 + y*bmd.Stride + 3*x;
            return Color.FromArgb(p[2], p[1], p[0]);
        }

        private static double GetColorFitness(Color c1, Color c2)
        {
            double r = c1.R - c2.R;
            double g = c1.G - c2.G;
            double b = c1.B - c2.B;

            return r*r + g*g + b*b;
        }
    }
}