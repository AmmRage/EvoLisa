using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using GenArt.Classes;

namespace GenArt
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();

            SetMutationRatePolygonTabPageDataBindings();
        }

        private void ApplySettings()
        {
            lock (MainForm.Settings)
            {
                MainForm.Settings.Activate();
            }
        }

        private void DiscardSettings()
        {
            MainForm.Settings.Discard();
        }


        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var settings = Serializer.DeserializeSettings(FileUtil.GetOpenFileName(FileUtil.XmlExtension));
            if (settings != null)
            {
                MainForm.Settings = settings;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Serializer.Serialize(MainForm.Settings);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Serializer.Serialize(MainForm.Settings, FileUtil.GetSaveFileName(FileUtil.XmlExtension));
        }

        private void applyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplySettings();
        }

        private void discardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DiscardSettings();
        }

        private void resetToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MainForm.Settings.Reset();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            ApplySettings();
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DiscardSettings();
            Close();
        }

        private void ResetDataBindings()
        {
            this.numericUpDownAddPolygonMutationRate.DataBindings.Clear();
            this.trackBarAddPolygonMutationRate.DataBindings.Clear();
            this.numericUpDownRemovePolygonMutationRate.DataBindings.Clear();
            this.trackBarRemovePolygonMutationRate.DataBindings.Clear();
            this.numericUpDownMovePolygonMutationRate.DataBindings.Clear();
            this.trackBarMovePolygonMutationRate.DataBindings.Clear();

            this.numericUpDownAddPointMutationRate.DataBindings.Clear();
            this.trackBarAddPointMutationRate.DataBindings.Clear();
            this.numericUpDownRemovePointMutationRate.DataBindings.Clear();
            this.trackBarRemovePointMutationRate.DataBindings.Clear();
            this.numericUpDownMovePointMinMutationRate.DataBindings.Clear();
            this.trackBarMovePointMinMutationRate.DataBindings.Clear();
            this.numericUpDownMovePointMidMutationRate.DataBindings.Clear();
            this.trackBarMovePointMidMutationRate.DataBindings.Clear();
            this.numericUpDownMovePointMaxMutationRate.DataBindings.Clear();
            this.trackBarMovePointMaxMutationRate.DataBindings.Clear();

            this.numericUpDownRedMutationRate.DataBindings.Clear();
            this.trackBarRedMutationRate.DataBindings.Clear();
            this.numericUpDownGreenMutationRate.DataBindings.Clear();
            this.trackBarGreenMutationRate.DataBindings.Clear();
            this.numericUpDownBlueMutationRate.DataBindings.Clear();
            this.trackBarBlueMutationRate.DataBindings.Clear();
            this.numericUpDownAlphaMutationRate.DataBindings.Clear();
            this.trackBarAlphaMutationRate.DataBindings.Clear();

            this.numericUpDownPolygonsMin.DataBindings.Clear();
            this.trackBarPolygonsMin.DataBindings.Clear();
            this.numericUpDownPolygonsMax.DataBindings.Clear();
            this.trackBarPolygonsMax.DataBindings.Clear();

            this.numericUpDownPointsPerPolygonMin.DataBindings.Clear();
            this.trackBarPointsPerPolygonMin.DataBindings.Clear();
            this.numericUpDownPointsPerPolygonMax.DataBindings.Clear();
            this.trackBarPointsPerPolygonMax.DataBindings.Clear();

            this.numericUpDownPointsMin.DataBindings.Clear();
            this.trackBarPointsMin.DataBindings.Clear();
            this.numericUpDownPointsMax.DataBindings.Clear();
            this.trackBarPointsMax.DataBindings.Clear();

            this.numericUpDownMovePointRangeMin.DataBindings.Clear();
            this.trackBarMovePointRangeMin.DataBindings.Clear();
            this.numericUpDownMovePointRangeMid.DataBindings.Clear();
            this.trackBarMovePointRangeMid.DataBindings.Clear();

            this.numericUpDownRedRangeMin.DataBindings.Clear();
            this.trackBarRedRangeMin.DataBindings.Clear();
            this.numericUpDownRedRangeMax.DataBindings.Clear();
            this.trackBarRedRangeMax.DataBindings.Clear();

            this.numericUpDownGreenRangeMin.DataBindings.Clear();
            this.trackBarGreenRangeMin.DataBindings.Clear();
            this.numericUpDownGreenRangeMax.DataBindings.Clear();
            this.trackBarGreenRangeMax.DataBindings.Clear();

            this.numericUpDownBlueRangeMin.DataBindings.Clear();
            this.trackBarBlueRangeMin.DataBindings.Clear();
            this.numericUpDownBlueRangeMax.DataBindings.Clear();
            this.trackBarBlueRangeMax.DataBindings.Clear();

            this.numericUpDownAlphaRangeMin.DataBindings.Clear();
            this.trackBarAlphaRangeMin.DataBindings.Clear();
            this.numericUpDownAlphaRangeMax.DataBindings.Clear();
            this.trackBarAlphaRangeMax.DataBindings.Clear();            
        }

        private void SetMutationRatePolygonTabPageDataBindings()
        {
            ResetDataBindings();

            this.numericUpDownAddPolygonMutationRate.DataBindings.Add("Value", MainForm.Settings, "AddPolygonMutationRate", true, DataSourceUpdateMode.OnPropertyChanged);
            this.trackBarAddPolygonMutationRate.DataBindings.Add("Value", MainForm.Settings, "AddPolygonMutationRate", true, DataSourceUpdateMode.OnPropertyChanged);
            this.numericUpDownRemovePolygonMutationRate.DataBindings.Add("Value", MainForm.Settings, "RemovePolygonMutationRate", true, DataSourceUpdateMode.OnPropertyChanged);
            this.trackBarRemovePolygonMutationRate.DataBindings.Add("Value", MainForm.Settings, "RemovePolygonMutationRate", true, DataSourceUpdateMode.OnPropertyChanged);
            this.numericUpDownMovePolygonMutationRate.DataBindings.Add("Value", MainForm.Settings, "MovePolygonMutationRate", true, DataSourceUpdateMode.OnPropertyChanged);
            this.trackBarMovePolygonMutationRate.DataBindings.Add("Value", MainForm.Settings, "MovePolygonMutationRate", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void SetMutationRatePointTabPageDataBindings()
        {
            ResetDataBindings();

            this.numericUpDownAddPointMutationRate.DataBindings.Add("Value", MainForm.Settings, "AddPointMutationRate", true, DataSourceUpdateMode.OnPropertyChanged);
            this.trackBarAddPointMutationRate.DataBindings.Add("Value", MainForm.Settings, "AddPointMutationRate", true, DataSourceUpdateMode.OnPropertyChanged);
            this.numericUpDownRemovePointMutationRate.DataBindings.Add("Value", MainForm.Settings, "RemovePointMutationRate", true, DataSourceUpdateMode.OnPropertyChanged);
            this.trackBarRemovePointMutationRate.DataBindings.Add("Value", MainForm.Settings, "RemovePointMutationRate", true, DataSourceUpdateMode.OnPropertyChanged);
            this.numericUpDownMovePointMinMutationRate.DataBindings.Add("Value", MainForm.Settings, "MovePointMinMutationRate", true, DataSourceUpdateMode.OnPropertyChanged);
            this.trackBarMovePointMinMutationRate.DataBindings.Add("Value", MainForm.Settings, "MovePointMinMutationRate", true, DataSourceUpdateMode.OnPropertyChanged);
            this.numericUpDownMovePointMidMutationRate.DataBindings.Add("Value", MainForm.Settings, "MovePointMidMutationRate", true, DataSourceUpdateMode.OnPropertyChanged);
            this.trackBarMovePointMidMutationRate.DataBindings.Add("Value", MainForm.Settings, "MovePointMidMutationRate", true, DataSourceUpdateMode.OnPropertyChanged);
            this.numericUpDownMovePointMaxMutationRate.DataBindings.Add("Value", MainForm.Settings, "MovePointMaxMutationRate", true, DataSourceUpdateMode.OnPropertyChanged);
            this.trackBarMovePointMaxMutationRate.DataBindings.Add("Value", MainForm.Settings, "MovePointMaxMutationRate", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void SetMutationRateColorTabPageDataBindings()
        {
            ResetDataBindings();

            this.numericUpDownRedMutationRate.DataBindings.Add("Value", MainForm.Settings, "RedMutationRate", true, DataSourceUpdateMode.OnPropertyChanged);
            this.trackBarRedMutationRate.DataBindings.Add("Value", MainForm.Settings, "RedMutationRate", true, DataSourceUpdateMode.OnPropertyChanged);
            this.numericUpDownGreenMutationRate.DataBindings.Add("Value", MainForm.Settings, "GreenMutationRate", true, DataSourceUpdateMode.OnPropertyChanged);
            this.trackBarGreenMutationRate.DataBindings.Add("Value", MainForm.Settings, "GreenMutationRate", true, DataSourceUpdateMode.OnPropertyChanged);
            this.numericUpDownBlueMutationRate.DataBindings.Add("Value", MainForm.Settings, "BlueMutationRate", true, DataSourceUpdateMode.OnPropertyChanged);
            this.trackBarBlueMutationRate.DataBindings.Add("Value", MainForm.Settings, "BlueMutationRate", true, DataSourceUpdateMode.OnPropertyChanged);
            this.numericUpDownAlphaMutationRate.DataBindings.Add("Value", MainForm.Settings, "AlphaMutationRate", true, DataSourceUpdateMode.OnPropertyChanged);
            this.trackBarAlphaMutationRate.DataBindings.Add("Value", MainForm.Settings, "AlphaMutationRate", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void SetRangePolygonTabPageDataBindings()
        {
            ResetDataBindings();

            this.numericUpDownPolygonsMin.DataBindings.Add("Value", MainForm.Settings, "PolygonsMin", true, DataSourceUpdateMode.OnPropertyChanged);
            this.trackBarPolygonsMin.DataBindings.Add("Value", MainForm.Settings, "PolygonsMin", true, DataSourceUpdateMode.OnPropertyChanged);
            this.numericUpDownPolygonsMax.DataBindings.Add("Value", MainForm.Settings, "PolygonsMax", true, DataSourceUpdateMode.OnPropertyChanged);
            this.trackBarPolygonsMax.DataBindings.Add("Value", MainForm.Settings, "PolygonsMax", true, DataSourceUpdateMode.OnPropertyChanged);

            this.numericUpDownPointsPerPolygonMin.DataBindings.Add("Value", MainForm.Settings, "PointsPerPolygonMin", true, DataSourceUpdateMode.OnPropertyChanged);
            this.trackBarPointsPerPolygonMin.DataBindings.Add("Value", MainForm.Settings, "PointsPerPolygonMin", true, DataSourceUpdateMode.OnPropertyChanged);
            this.numericUpDownPointsPerPolygonMax.DataBindings.Add("Value", MainForm.Settings, "PointsPerPolygonMax", true, DataSourceUpdateMode.OnPropertyChanged);
            this.trackBarPointsPerPolygonMax.DataBindings.Add("Value", MainForm.Settings, "PointsPerPolygonMax", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void SetRangePointTabPageDataBindings()
        {
            ResetDataBindings();

            this.numericUpDownPointsMin.DataBindings.Add("Value", MainForm.Settings, "PointsMin", true, DataSourceUpdateMode.OnPropertyChanged);
            this.trackBarPointsMin.DataBindings.Add("Value", MainForm.Settings, "PointsMin", true, DataSourceUpdateMode.OnPropertyChanged);
            this.numericUpDownPointsMax.DataBindings.Add("Value", MainForm.Settings, "PointsMax", true, DataSourceUpdateMode.OnPropertyChanged);
            this.trackBarPointsMax.DataBindings.Add("Value", MainForm.Settings, "PointsMax", true, DataSourceUpdateMode.OnPropertyChanged);

            this.numericUpDownMovePointRangeMin.DataBindings.Add("Value", MainForm.Settings, "MovePointRangeMin", true, DataSourceUpdateMode.OnPropertyChanged);
            this.trackBarMovePointRangeMin.DataBindings.Add("Value", MainForm.Settings, "MovePointRangeMin", true, DataSourceUpdateMode.OnPropertyChanged);
            this.numericUpDownMovePointRangeMid.DataBindings.Add("Value", MainForm.Settings, "MovePointRangeMid", true, DataSourceUpdateMode.OnPropertyChanged);
            this.trackBarMovePointRangeMid.DataBindings.Add("Value", MainForm.Settings, "MovePointRangeMid", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void SetRangeColorTabPageDataBindings()
        {
            ResetDataBindings();

            this.numericUpDownRedRangeMin.DataBindings.Add("Value", MainForm.Settings, "RedRangeMin", true, DataSourceUpdateMode.OnPropertyChanged);
            this.trackBarRedRangeMin.DataBindings.Add("Value", MainForm.Settings, "RedRangeMin", true, DataSourceUpdateMode.OnPropertyChanged);
            this.numericUpDownRedRangeMax.DataBindings.Add("Value", MainForm.Settings, "RedRangeMax", true, DataSourceUpdateMode.OnPropertyChanged);
            this.trackBarRedRangeMax.DataBindings.Add("Value", MainForm.Settings, "RedRangeMax", true, DataSourceUpdateMode.OnPropertyChanged);

            this.numericUpDownGreenRangeMin.DataBindings.Add("Value", MainForm.Settings, "GreenRangeMin", true, DataSourceUpdateMode.OnPropertyChanged);
            this.trackBarGreenRangeMin.DataBindings.Add("Value", MainForm.Settings, "GreenRangeMin", true, DataSourceUpdateMode.OnPropertyChanged);
            this.numericUpDownGreenRangeMax.DataBindings.Add("Value", MainForm.Settings, "GreenRangeMax", true, DataSourceUpdateMode.OnPropertyChanged);
            this.trackBarGreenRangeMax.DataBindings.Add("Value", MainForm.Settings, "GreenRangeMax", true, DataSourceUpdateMode.OnPropertyChanged);

            this.numericUpDownBlueRangeMin.DataBindings.Add("Value", MainForm.Settings, "BlueRangeMin", true, DataSourceUpdateMode.OnPropertyChanged);
            this.trackBarBlueRangeMin.DataBindings.Add("Value", MainForm.Settings, "BlueRangeMin", true, DataSourceUpdateMode.OnPropertyChanged);
            this.numericUpDownBlueRangeMax.DataBindings.Add("Value", MainForm.Settings, "BlueRangeMax", true, DataSourceUpdateMode.OnPropertyChanged);
            this.trackBarBlueRangeMax.DataBindings.Add("Value", MainForm.Settings, "BlueRangeMax", true, DataSourceUpdateMode.OnPropertyChanged);

            this.numericUpDownAlphaRangeMin.DataBindings.Add("Value", MainForm.Settings, "AlphaRangeMin", true, DataSourceUpdateMode.OnPropertyChanged);
            this.trackBarAlphaRangeMin.DataBindings.Add("Value", MainForm.Settings, "AlphaRangeMin", true, DataSourceUpdateMode.OnPropertyChanged);
            this.numericUpDownAlphaRangeMax.DataBindings.Add("Value", MainForm.Settings, "AlphaRangeMax", true, DataSourceUpdateMode.OnPropertyChanged);
            this.trackBarAlphaRangeMax.DataBindings.Add("Value", MainForm.Settings, "AlphaRangeMax", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            SetMutationRatePolygonTabPageDataBindings();
        }

        private void tabPage2_Enter(object sender, EventArgs e)
        {
            SetMutationRatePointTabPageDataBindings();
        }

        private void tabPage3_Enter(object sender, EventArgs e)
        {
            SetMutationRateColorTabPageDataBindings();
        }

        private void tabPage6_Enter(object sender, EventArgs e)
        {
            SetRangePolygonTabPageDataBindings();
        }

        private void tabPage7_Enter(object sender, EventArgs e)
        {
            SetRangePointTabPageDataBindings();
        }

        private void tabPage8_Click(object sender, EventArgs e)
        {
            SetRangeColorTabPageDataBindings();
        }
    }
}
