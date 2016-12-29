using System;
using System.Collections.Generic;
using GenArt.Classes;

namespace GenArt.AST
{
    [Serializable]
    public class DnaPolygon
    {
        public List<DnaPoint> Points { get; set; }
        public DnaBrush Brush { get; set; }

        public void Init()
        {
            this.Points = new List<DnaPoint>();

            //int count = Tools.GetRandomNumber(3, 3);
            var origin = new DnaPoint();
            origin.Init();

            for (var i = 0; i < Settings.ActivePointsPerPolygonMin; i++)
            {
                var point = new DnaPoint();
                point.X = Math.Min(Math.Max(0, origin.X + Tools.GetRandomNumber(-3, 3)), Tools.MaxWidth);
                point.Y = Math.Min(Math.Max(0, origin.Y + Tools.GetRandomNumber(-3, 3)), Tools.MaxHeight);

                this.Points.Add(point);
            }

            this.Brush = new DnaBrush();
            this.Brush.Init();
        }

        public DnaPolygon Clone()
        {
            var newPolygon = new DnaPolygon();
            newPolygon.Points = new List<DnaPoint>();
            newPolygon.Brush = this.Brush.Clone();
            foreach (var point in this.Points)
                newPolygon.Points.Add(point.Clone());

            return newPolygon;
        }

        public void Mutate(DnaDrawing drawing)
        {
            if (Tools.WillMutate(Settings.ActiveAddPointMutationRate))
                AddPoint(drawing);

            if (Tools.WillMutate(Settings.ActiveRemovePointMutationRate))
                RemovePoint(drawing);

            this.Brush.Mutate(drawing);
            this.Points.ForEach(p => p.Mutate(drawing));
        }

        private void RemovePoint(DnaDrawing drawing)
        {
            if (this.Points.Count > Settings.ActivePointsPerPolygonMin)
            {
                if (drawing.PointCount > Settings.ActivePointsMin)
                {
                    var index = Tools.GetRandomNumber(0, this.Points.Count);
                    this.Points.RemoveAt(index);

                    drawing.SetDirty();
                }
            }
        }

        private void AddPoint(DnaDrawing drawing)
        {
            if (this.Points.Count < Settings.ActivePointsPerPolygonMax)
            {
                if (drawing.PointCount < Settings.ActivePointsMax)
                {
                    var newPoint = new DnaPoint();

                    var index = Tools.GetRandomNumber(1, this.Points.Count - 1);

                    var prev = this.Points[index - 1];
                    var next = this.Points[index];

                    newPoint.X = (prev.X + next.X)/2;
                    newPoint.Y = (prev.Y + next.Y)/2;


                    this.Points.Insert(index, newPoint);

                    drawing.SetDirty();
                }
            }
        }
    }
}