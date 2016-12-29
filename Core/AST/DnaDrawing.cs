using System.Collections.Generic;
using System.Xml.Serialization;
using GenArt.Classes;
using System;

namespace GenArt.AST
{
    [Serializable]
    public class DnaDrawing
    {
        public List<DnaPolygon> Polygons { get; set; }

        [XmlIgnore]
        public bool IsDirty { get; private set; }

        public int PointCount
        {
            get
            {
                var pointCount = 0;
                foreach (var polygon in this.Polygons)
                    pointCount += polygon.Points.Count;

                return pointCount;
            }
        }

        public void SetDirty()
        {
            this.IsDirty = true;
        }

        public void Init()
        {
            this.Polygons = new List<DnaPolygon>();

            for (var i = 0; i < Settings.ActivePolygonsMin; i++)
                AddPolygon();

            SetDirty();
        }

        public DnaDrawing Clone()
        {
            var drawing = new DnaDrawing();
            drawing.Polygons = new List<DnaPolygon>();
            foreach (var polygon in this.Polygons)
                drawing.Polygons.Add(polygon.Clone());

            return drawing;
        }


        public void Mutate()
        {
            if (Tools.WillMutate(Settings.ActiveAddPolygonMutationRate))
                AddPolygon();

            if (Tools.WillMutate(Settings.ActiveRemovePolygonMutationRate))
                RemovePolygon();

            if (Tools.WillMutate(Settings.ActiveMovePolygonMutationRate))
                MovePolygon();

            foreach (var polygon in this.Polygons)
                polygon.Mutate(this);
        }

        public void MovePolygon()
        {
            if (this.Polygons.Count < 1)
                return;

            var index = Tools.GetRandomNumber(0, this.Polygons.Count);
            var poly = this.Polygons[index];
            this.Polygons.RemoveAt(index);
            index = Tools.GetRandomNumber(0, this.Polygons.Count);
            this.Polygons.Insert(index, poly);
            SetDirty();
        }

        public void RemovePolygon()
        {
            if (this.Polygons.Count > Settings.ActivePolygonsMin)
            {
                var index = Tools.GetRandomNumber(0, this.Polygons.Count);
                this.Polygons.RemoveAt(index);
                SetDirty();
            }
        }

        public void AddPolygon()
        {
            if (this.Polygons.Count < Settings.ActivePolygonsMax)
            {
                var newPolygon = new DnaPolygon();
                newPolygon.Init();

                var index = Tools.GetRandomNumber(0, this.Polygons.Count);

                this.Polygons.Insert(index, newPolygon);
                SetDirty();
            }
        }
    }
}