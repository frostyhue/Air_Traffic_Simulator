using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Air_Traffic_Simulation
{
    [Serializable]
    public class Airstrip : AbstractCheckpoint
    {
        /// <summary>
        /// This is any help written.
        /// </summary>
        private double _takeOffDirection;
        public override string Name { get; }
        public override double CoordinateX { get; set; }
        public override double CoordinateY { get; set; }
        [field:NonSerialized]
        public override LinkedList<AbstractCheckpoint> ShortestPath { get; set; }
        public override double DistanceFromSource { get; set; }
        public override Dictionary<AbstractCheckpoint, double> ReachableNodes { get; set; }

        public override int MaxSpeed { get; set; }
        public override int MinSpeed { get; set; }
        public override int MaxAltitude { get; set; }
        public override int MinAltitude { get; set; }

        public bool IsFree { get; set; }

        public double TakeOffDirection
        {
            get { return _takeOffDirection; }

            private set
            {
                if (value >= 360)
                {
                    _takeOffDirection = value - 360;
                }
                else
                {
                    _takeOffDirection = value;
                }
            }
        }

        public Airstrip(string name, double coordinateX, double coordinateY, bool isFree, double takeOffDirection)
        {
            Name = name;
            CoordinateX = coordinateX;
            CoordinateY = coordinateY;
            this.IsFree = isFree;
            this._takeOffDirection = takeOffDirection;

            ShortestPath = new LinkedList<AbstractCheckpoint>();
            DistanceFromSource = Int32.MaxValue;
            ReachableNodes = new Dictionary<AbstractCheckpoint, double>();

            MinSpeed = 0;
            MaxSpeed = 0;
            MaxAltitude = 0;
            MinAltitude = 0;
        }


        /// <summary>
        /// Changes the take off/landing direction to the opposite.
        /// </summary>
        public void SwitchDirections()
        {
            TakeOffDirection += 180;
        }

        //TODO: SetStatus() method in Airstrip class
        public void SetStatus()
        {
            throw new NotImplementedException();
        }
    }
}