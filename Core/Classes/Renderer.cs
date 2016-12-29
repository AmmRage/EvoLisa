using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

using GenArt.AST;

namespace GenArt.Classes
{
    public static class Renderer
    {
        //Render a Drawing
        public static void Render(DnaDrawing drawing,Graphics g,int scale)
        {
            g.Clear(Color.Black);

            foreach (var polygon in drawing.Polygons)
                Render(polygon, g, scale);
        }

        //Render a polygon
        private static void Render(DnaPolygon polygon, Graphics g, int scale)
        {
            using (var brush = GetGdiBrush(polygon.Brush))
            {
                var points = GetGdiPoints(polygon.Points, scale);
                g.FillPolygon(brush,points);
            }
        }

        //Convert a list of DnaPoint to a list of System.Drawing.Point's
        private static Point[] GetGdiPoints(IList<DnaPoint> points,int scale)
        {
            var pts = new Point[points.Count];
            var i = 0;
            foreach (var pt in points)
            {
                pts[i++] = new Point(pt.X * scale, pt.Y * scale);
            }
            return pts;
        }

        //Convert a DnaBrush to a System.Drawing.Brush
        private static Brush GetGdiBrush(DnaBrush b)
        {
            return new SolidBrush(Color.FromArgb(b.Alpha, b.Red, b.Green, b.Blue));
        }

        
    }
}
