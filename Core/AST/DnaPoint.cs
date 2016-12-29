using System;
using GenArt.Classes;

namespace GenArt.AST
{
    [Serializable]
    public class DnaPoint
    {
        public int X { get; set; }
        public int Y { get; set; }

        public void Init()
        {
            this.X = Tools.GetRandomNumber(0, Tools.MaxWidth);
            this.Y = Tools.GetRandomNumber(0, Tools.MaxHeight);
        }

        public DnaPoint Clone()
        {
            return new DnaPoint
                       {
                           X = this.X,
                           Y = this.Y,
                       };
        }

        public void Mutate(DnaDrawing drawing)
        {
            if (Tools.WillMutate(Settings.ActiveMovePointMaxMutationRate))
            {
                this.X = Tools.GetRandomNumber(0, Tools.MaxWidth);
                this.Y = Tools.GetRandomNumber(0, Tools.MaxHeight);
                drawing.SetDirty();
            }

            if (Tools.WillMutate(Settings.ActiveMovePointMidMutationRate))
            {
                this.X =
                    Math.Min(
                        Math.Max(0, this.X +
                                 Tools.GetRandomNumber(-Settings.ActiveMovePointRangeMid,
                                                       Settings.ActiveMovePointRangeMid)), Tools.MaxWidth);
                this.Y =
                    Math.Min(
                        Math.Max(0, this.Y +
                                 Tools.GetRandomNumber(-Settings.ActiveMovePointRangeMid,
                                                       Settings.ActiveMovePointRangeMid)), Tools.MaxHeight);
                drawing.SetDirty();
            }

            if (Tools.WillMutate(Settings.ActiveMovePointMinMutationRate))
            {
                this.X =
                    Math.Min(
                        Math.Max(0, this.X +
                                 Tools.GetRandomNumber(-Settings.ActiveMovePointRangeMin,
                                                       Settings.ActiveMovePointRangeMin)), Tools.MaxWidth);
                this.Y =
                    Math.Min(
                        Math.Max(0, this.Y +
                                 Tools.GetRandomNumber(-Settings.ActiveMovePointRangeMin,
                                                       Settings.ActiveMovePointRangeMin)), Tools.MaxHeight);
                drawing.SetDirty();
            }
        }
    }
}