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
            var origin = new DnaPoint();
            //set point to random point in canvas
            origin.Init();
            for (var i = 0; i < Settings.ActivePointsPerPolygonMin; i++)
            {
                var point = new DnaPoint
                {
                    X = Math.Min(Math.Max(0, origin.X + Tools.GetRandomNumber(-3, 3)), Tools.MaxWidth),
                    Y = Math.Min(Math.Max(0, origin.Y + Tools.GetRandomNumber(-3, 3)), Tools.MaxHeight)

                    //X = Math.Min(Math.Max(0, origin.X), Tools.MaxWidth),
                    //Y = Math.Min(Math.Max(0, origin.Y), Tools.MaxHeight)
                };
                this.Points.Add(point);
            }
            this.Brush = new DnaBrush();
            //random color
            this.Brush.Init();
        }

        public DnaPolygon Clone()
        {
            var newPolygon = new DnaPolygon
            {
                Points = new List<DnaPoint>(),
                Brush = this.Brush.Clone()
            };
            foreach (var point in this.Points)
                newPolygon.Points.Add(point.Clone());

            return newPolygon;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="drawing"></param>
        public void Mutate(DnaDrawing drawing)
        {
            if (Tools.WillMutate(Settings.ActiveAddPointMutationRate))
                AddPoint(drawing);

            if (Tools.WillMutate(Settings.ActiveRemovePointMutationRate))
                RemovePoint(drawing);

            this.Brush.Mutate(drawing);
            this.Points.ForEach(p => p.Mutate(drawing));
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

        private void RemovePoint(DnaDrawing drawing)
        {
            if (this.Points.Count <= Settings.ActivePointsPerPolygonMin) return;
            if (drawing.PointCount <= Settings.ActivePointsMin) return;

            var index = Tools.GetRandomNumber(0, this.Points.Count);
            this.Points.RemoveAt(index);
            drawing.SetDirty();
        }
    }
}