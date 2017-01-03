namespace GenArt.Classes
{
    public class Settings
    {
        public static int ActiveAddPointMutationRate = 1500 / 100;
        public static int ActiveAddPolygonMutationRate = 700 / 100;
        public static int ActiveAlphaMutationRate = 1500 / 100;

        public static int ActiveAlphaRangeMax = 60;
        public static int ActiveAlphaRangeMin = 30;
        public static int ActiveBlueMutationRate = 1500;
        public static int ActiveBlueRangeMax = 255;
        public static int ActiveBlueRangeMin;
        public static int ActiveGreenMutationRate = 1500;
        public static int ActiveGreenRangeMax = 255;
        public static int ActiveGreenRangeMin;
        public static int ActiveMovePointMaxMutationRate = 1500;
        public static int ActiveMovePointMidMutationRate = 1500;
        public static int ActiveMovePointMinMutationRate = 1500;

        public static int ActiveMovePointRangeMid = 20;
        public static int ActiveMovePointRangeMin = 3;
        public static int ActiveMovePolygonMutationRate = 700;
        public static int ActivePointsMax = 1500;
        public static int ActivePointsMin;
        public static int ActivePointsPerPolygonMax = 10;
        public static int ActivePointsPerPolygonMin = 3; //test
        public static int ActivePolygonsMax = 255;
        public static int ActivePolygonsMin;
        public static int ActiveRedMutationRate = 1500;
        public static int ActiveRedRangeMax = 255;
        public static int ActiveRedRangeMin;
        public static int ActiveRemovePointMutationRate = 1500 / 100;
        public static int ActiveRemovePolygonMutationRate = 1500;
        private int _addPointMutationRate = 1500;

        //Mutation rates
        private int _addPolygonMutationRate = 700;
        private int _alphaMutationRate = 1500;
        private int _alphaRangeMax = 60;
        private int _alphaRangeMin = 30;
        private int _blueMutationRate = 1500;
        private int _blueRangeMax = 255;
        private int _blueRangeMin;
        private int _greenMutationRate = 1500;
        private int _greenRangeMax = 255;
        private int _greenRangeMin;
        private int _movePointMaxMutationRate = 1500;
        private int _movePointMidMutationRate = 1500;
        private int _movePointMinMutationRate = 1500;
        private int _movePointRangeMid = 20;
        private int _movePointRangeMin = 3;
        private int _movePolygonMutationRate = 700;
        private int _pointsMax = 1500;
        private int _pointsMin;
        private int _pointsPerPolygonMax = 10;
        private int _pointsPerPolygonMin = 3;
        private int _polygonsMax = 255;
        private int _polygonsMin;
        private int _redMutationRate = 1500;
        private int _redRangeMax = 255;
        private int _redRangeMin;
        private int _removePointMutationRate = 1500;

        private int _removePolygonMutationRate = 1500;

        public Settings()
        {
            Reset();
        }

        public int AddPolygonMutationRate
        {
            get { return this._addPolygonMutationRate; }
            set
            {
                this._addPolygonMutationRate = value;
                //this.OnPropertyChanged("AddPolygonMutationRate");
            }
        }

        public int RemovePolygonMutationRate
        {
            get { return this._removePolygonMutationRate; }
            set { this._removePolygonMutationRate = value; }
        }

        public int MovePolygonMutationRate
        {
            get { return this._movePolygonMutationRate; }
            set { this._movePolygonMutationRate = value; }
        }

        public int AddPointMutationRate
        {
            get { return this._addPointMutationRate; }
            set { this._addPointMutationRate = value; }
        }

        public int RemovePointMutationRate
        {
            get { return this._removePointMutationRate; }
            set { this._removePointMutationRate = value; }
        }

        public int MovePointMaxMutationRate
        {
            get { return this._movePointMaxMutationRate; }
            set { this._movePointMaxMutationRate = value; }
        }

        public int MovePointMidMutationRate
        {
            get { return this._movePointMidMutationRate; }
            set { this._movePointMidMutationRate = value; }
        }

        public int MovePointMinMutationRate
        {
            get { return this._movePointMinMutationRate; }
            set { this._movePointMinMutationRate = value; }
        }

        public int RedMutationRate
        {
            get { return this._redMutationRate; }
            set { this._redMutationRate = value; }
        }

        public int GreenMutationRate
        {
            get { return this._greenMutationRate; }
            set { this._greenMutationRate = value; }
        }

        public int BlueMutationRate
        {
            get { return this._blueMutationRate; }
            set { this._blueMutationRate = value; }
        }

        public int AlphaMutationRate
        {
            get { return this._alphaMutationRate; }
            set { this._alphaMutationRate = value; }
        }

        //Ranges
        public int RedRangeMin
        {
            get { return this._redRangeMin; }
            set
            {
                if (value > this._redRangeMax)
                    this.RedRangeMax = value;

                this._redRangeMin = value;
            }
        }

        public int RedRangeMax
        {
            get { return this._redRangeMax; }
            set
            {
                if (value < this._redRangeMin)
                    this.RedRangeMin = value;

                this._redRangeMax = value;
            }
        }

        public int GreenRangeMin
        {
            get { return this._greenRangeMin; }
            set
            {
                if (value > this._greenRangeMax)
                    this.GreenRangeMax = value;

                this._greenRangeMin = value;
            }
        }

        public int GreenRangeMax
        {
            get { return this._greenRangeMax; }
            set
            {
                if (value < this._greenRangeMin)
                    this.GreenRangeMin = value;

                this._greenRangeMax = value;
            }
        }

        public int BlueRangeMin
        {
            get { return this._blueRangeMin; }
            set
            {
                if (value > this._blueRangeMax)
                    this.BlueRangeMax = value;

                this._blueRangeMin = value;
            }
        }

        public int BlueRangeMax
        {
            get { return this._blueRangeMax; }
            set
            {
                if (value < this._blueRangeMin)
                    this.BlueRangeMin = value;

                this._blueRangeMax = value;
            }
        }

        public int AlphaRangeMin
        {
            get { return this._alphaRangeMin; }
            set
            {
                if (value > this._alphaRangeMax)
                    this.AlphaRangeMax = value;

                this._alphaRangeMin = value;
            }
        }

        public int AlphaRangeMax
        {
            get { return this._alphaRangeMax; }
            set
            {
                if (value < this._alphaRangeMin)
                    this.AlphaRangeMin = value;

                this._alphaRangeMax = value;
            }
        }

        public int PolygonsMin
        {
            get { return this._polygonsMin; }
            set
            {
                if (value > this._polygonsMax)
                    this.PolygonsMax = value;

                this._polygonsMin = value;
            }
        }

        public int PolygonsMax
        {
            get { return this._polygonsMax; }
            set
            {
                if (value < this._polygonsMin)
                    this.PolygonsMin = value;

                this._polygonsMax = value;
            }
        }

        public int PointsPerPolygonMin
        {
            get { return this._pointsPerPolygonMin; }
            set
            {
                if (value > this._pointsPerPolygonMax)
                    this.PointsPerPolygonMax = value;

                if (value < 3)
                    return;

                this._pointsPerPolygonMin = value;
            }
        }

        public int PointsPerPolygonMax
        {
            get { return this._pointsPerPolygonMax; }
            set
            {
                if (value < this._pointsPerPolygonMin)
                    this.PointsPerPolygonMin = value;

                this._pointsPerPolygonMax = value;
            }
        }

        public int PointsMin
        {
            get { return this._pointsMin; }
            set
            {
                if (value > this._pointsMax)
                    this.PointsMax = value;

                this._pointsMin = value;
            }
        }

        public int PointsMax
        {
            get { return this._pointsMax; }
            set
            {
                if (value < this._pointsMin)
                    this.PointsMin = value;

                this._pointsMax = value;
            }
        }

        public int MovePointRangeMin
        {
            get { return this._movePointRangeMin; }
            set
            {
                if (value > this._movePointRangeMid)
                    this.MovePointRangeMid = value;

                this._movePointRangeMin = value;
            }
        }

        public int MovePointRangeMid
        {
            get { return this._movePointRangeMid; }
            set
            {
                if (value < this._movePointRangeMin)
                    this.MovePointRangeMin = value;

                this._movePointRangeMid = value;
            }
        }

        public void Activate()
        {
            ActiveAddPolygonMutationRate = this.AddPolygonMutationRate;
            ActiveRemovePolygonMutationRate = this.RemovePolygonMutationRate;
            ActiveMovePolygonMutationRate = this.MovePolygonMutationRate;

            ActiveAddPointMutationRate = this.AddPointMutationRate;
            ActiveRemovePointMutationRate = this.RemovePointMutationRate;
            ActiveMovePointMaxMutationRate = this.MovePointMaxMutationRate;
            ActiveMovePointMidMutationRate = this.MovePointMidMutationRate;
            ActiveMovePointMinMutationRate = this.MovePointMinMutationRate;

            ActiveRedMutationRate = this.RedMutationRate;
            ActiveGreenMutationRate = this.GreenMutationRate;
            ActiveBlueMutationRate = this.BlueMutationRate;
            ActiveAlphaMutationRate = this.AlphaMutationRate;

            //Limits / Constraints
            ActiveRedRangeMin = this.RedRangeMin;
            ActiveRedRangeMax = this.RedRangeMax;
            ActiveGreenRangeMin = this.GreenRangeMin;
            ActiveGreenRangeMax = this.GreenRangeMax;
            ActiveBlueRangeMin = this.BlueRangeMin;
            ActiveBlueRangeMax = this.BlueRangeMax;
            ActiveAlphaRangeMin = this.AlphaRangeMin;
            ActiveAlphaRangeMax = this.AlphaRangeMax;

            ActivePolygonsMax = this.PolygonsMax;
            ActivePolygonsMin = this.PolygonsMin;

            ActivePointsPerPolygonMax = this.PointsPerPolygonMax;
            ActivePointsPerPolygonMin = this.PointsPerPolygonMin;

            ActivePointsMax = this.PointsMax;
            ActivePointsMin = this.PointsMin;

            ActiveMovePointRangeMid = this.MovePointRangeMid;
            ActiveMovePointRangeMin = this.MovePointRangeMin;
        }

        public void Discard()
        {
            this.AddPolygonMutationRate = ActiveAddPolygonMutationRate;
            this.RemovePolygonMutationRate = ActiveRemovePolygonMutationRate;
            this.MovePolygonMutationRate = ActiveMovePolygonMutationRate;

            this.AddPointMutationRate = ActiveAddPointMutationRate;
            this.RemovePointMutationRate = ActiveRemovePointMutationRate;
            this.MovePointMaxMutationRate = ActiveMovePointMaxMutationRate;
            this.MovePointMidMutationRate = ActiveMovePointMidMutationRate;
            this.MovePointMinMutationRate = ActiveMovePointMinMutationRate;

            this.RedMutationRate = ActiveRedMutationRate;
            this.GreenMutationRate = ActiveGreenMutationRate;
            this.BlueMutationRate = ActiveBlueMutationRate;
            this.AlphaMutationRate = ActiveAlphaMutationRate;

            //Limits / Constraints
            this.RedRangeMin = ActiveRedRangeMin;
            this.RedRangeMax = ActiveRedRangeMax;
            this.GreenRangeMin = ActiveGreenRangeMin;
            this.GreenRangeMax = ActiveGreenRangeMax;
            this.BlueRangeMin = ActiveBlueRangeMin;
            this.BlueRangeMax = ActiveBlueRangeMax;
            this.AlphaRangeMin = ActiveAlphaRangeMin;
            this.AlphaRangeMax = ActiveAlphaRangeMax;

            this.PolygonsMax = ActivePolygonsMax;
            this.PolygonsMin = ActivePolygonsMin;

            this.PointsPerPolygonMax = ActivePointsPerPolygonMax;
            this.PointsPerPolygonMin = ActivePointsPerPolygonMin;

            this.PointsMax = ActivePointsMax;
            this.PointsMin = ActivePointsMin;

            this.MovePointRangeMid = ActiveMovePointRangeMid;
            this.MovePointRangeMin = ActiveMovePointRangeMin;
        }

        public void Reset()
        {
            ActiveAddPolygonMutationRate = 700;
            ActiveRemovePolygonMutationRate = 1500;
            ActiveMovePolygonMutationRate = 700;

            ActiveAddPointMutationRate = 1500;
            ActiveRemovePointMutationRate = 1500;
            ActiveMovePointMaxMutationRate = 1500;
            ActiveMovePointMidMutationRate = 1500;
            ActiveMovePointMinMutationRate = 1500;

            ActiveRedMutationRate = 1500;
            ActiveGreenMutationRate = 1500;
            ActiveBlueMutationRate = 1500;
            ActiveAlphaMutationRate = 1500;

            //Limits / Constraints
            ActiveRedRangeMin = 0;
            ActiveRedRangeMax = 255;
            ActiveGreenRangeMin = 0;
            ActiveGreenRangeMax = 255;
            ActiveBlueRangeMin = 0;
            ActiveBlueRangeMax = 255;
            ActiveAlphaRangeMin = 30;
            ActiveAlphaRangeMax = 60;

            ActivePolygonsMax = 255;
            ActivePolygonsMin = 0;

            ActivePointsPerPolygonMax = 10;
            ActivePointsPerPolygonMin = 3;

            ActivePointsMax = 1500;
            ActivePointsMin = 0;

            ActiveMovePointRangeMid = 20;
            ActiveMovePointRangeMin = 3;

            Discard();
        }
    }
}