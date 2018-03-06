using System.Collections.Generic;
using System.Xml.Serialization;
using GenArt.Classes;
using System;
using System.Linq;

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
                return this.Polygons.Sum(polygon => polygon.Points.Count);
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
            var drawing = new DnaDrawing {Polygons = new List<DnaPolygon>()};
            foreach (var polygon in this.Polygons)
                drawing.Polygons.Add(polygon.Clone());
            return drawing;
        }

        public void Mutate()
        {
            //多边形列表变异
            if (Tools.WillMutate(Settings.ActiveAddPolygonMutationRate))
            {
                AddPolygon();//add a random sized and random location poligon
            }
            if (Tools.WillMutate(Settings.ActiveRemovePolygonMutationRate))
            {
                RemovePolygon();//remove a random polygon in the list
            }
            if (Tools.WillMutate(Settings.ActiveMovePolygonMutationRate))
            {
                MovePolygon();
            }
            //
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
                //add a random polygon to drawing polygon list
                newPolygon.Init();

                var index = Tools.GetRandomNumber(0, this.Polygons.Count);
                //insert to a random position
                this.Polygons.Insert(index, newPolygon);
                SetDirty();
            }
        }
    }
}