using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.Logging;

namespace Air_Traffic_Simulation
{
    ///A representation of the airplanes moving through the airspace.
    /// <inheritdoc />
    [Serializable]
    public class Airplane : AbstractCheckpoint
    {
        public override string Name { get; }
        [field: NonSerialized] public override LinkedList<AbstractCheckpoint> ShortestPath { get; set; }
        public override double DistanceFromSource { get; set; }
        public override Dictionary<AbstractCheckpoint, double> ReachableNodes { get; set; }
        public override double CoordinateX { get; set; }
        public override double CoordinateY { get; set; }
        public List<AbstractCheckpoint> Route { get; private set; }

        /// <summary>
        /// A unique identifier of the airplane, similar to the name.
        /// </summary>
        public string FlightNumber { get; private set; }

        public override int MaxSpeed { get; set; }
        public override int MinSpeed { get; set; }
        public override int MaxAltitude { get; set; }
        public override int MinAltitude { get; set; }
        public int Area { get; set; }
        public Rectangle Rect { get; set; }

        private double speedInKts;

        /// <summary>
        /// The speedInKts at which the airplane is currently moving.
        /// </summary>
        public double SpeedInKts
        {
            get { return speedInKts; }
            set
            {
                movingDirectionHasChanged = true;
                milesPerSecond = value / 360;
                speedInKts = value;
            }
        }

        /// <summary>
        /// The airplane's speedInKts for knots per second. Used for calculation of movement.
        /// </summary>
        private double milesPerSecond;

        /// <summary>
        /// The altitude at which the airplane is currently moving.
        /// </summary>
        public int Altitude { get; set; }


        /// <summary>
        /// Shows if the plane is on its way to land.
        /// </summary>
        public bool IsLanding { get; set; }

        /// <summary>
        /// The point through which the airplane will leave the airspace.
        /// </summary>
        public Checkpoint exitDestination { get; set; }

        //EVENTS:

        /// <summary>
        /// The event that gets risen once the airplane lands.
        /// </summary>
        [field: NonSerialized]
        public event EventHandler OnAirportReached;

        /// <summary>
        /// The event that gets risen once the airplane exits the airspace through
        /// its target location.
        /// </summary>
        [field: NonSerialized]
        public event EventHandler OnAirspaceExit;

        /// <summary>
        /// The delegate for the <see cref="OnCrash"/> event.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        public delegate void CrashHandler(Object p1, Object p2);

        /// <summary>
        /// The event that gets risen in case two airplanes turn up to be
        /// in the same spot at the same altitude.
        /// </summary>
        [field: NonSerialized]
        public event CrashHandler OnCrash;

        /// <summary>
        /// Initializes a new instance of the <see cref="Airplane"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="coordinateX">The coordinate x.</param>
        /// <param name="coordinateY">The coordinate y.</param>
        /// <param name="speedInKts">The spped in knots/nautical miles.</param>
        /// <param name="altitudeInFt">The altitude of the airplane in feet.</param>
        /// <param name="flightNumber">The flight number.</param>
        public Airplane(string name, double coordinateX, double coordinateY, double speedInKts, int altitudeInFt, string flightNumber)
        {
            IsLanding = true;
            Name = name;
            this.CoordinateX = coordinateX;
            this.CoordinateY = coordinateY;
            this.SpeedInKts = speedInKts;
            this.Altitude = altitudeInFt;
            FlightNumber = flightNumber;
            Area = 20;
            Rect = new Rectangle((int) CoordinateX - Area, (int) CoordinateY - Area, Area * 2, Area * 2);

            ShortestPath = new LinkedList<AbstractCheckpoint>();
            DistanceFromSource = 0;
            ReachableNodes = new Dictionary<AbstractCheckpoint, double>();
            Route = new List<AbstractCheckpoint>();

            MinSpeed = 500;
            MaxSpeed = 800;
            MaxAltitude = 7500;
            MinAltitude = 6500;

            this.milesPerSecond = speedInKts / 360;
        }

        /// <summary>
        /// A variable showing if the direction of movement of the aircraft has changed.
        /// In other words, if the airplane has to aim for a different <see cref="Checkpoint"/>/<see cref="Airstrip"/> now.
        /// </summary>
        private bool movingDirectionHasChanged = true;

        /// <summary>
        /// The horizontal dislocation an airplane needs to make (repetetively) to get to its target destiantion.
        /// </summary>
        private double leapx = 0;

        /// <summary>
        /// The horizontal dislocation an airplane needs to make (repetetively) to get to its target destiantion.
        /// </summary>
        private double leapy = 0;

        /// <summary>
        /// The <see cref="Checkpoint"/> or <see cref="Airstrip"/>, towards which the airplane is currently moving.
        /// </summary>
        [NonSerialized] public LinkedListNode<AbstractCheckpoint> target;

        /// <summary>
        /// Checks if the distance between two airplanes is safe or not. If the distance is not safe, the OnCrash event triggers
        /// </summary>
        /// <param name="p"></param>
        public void DangerCheck(Airplane p)
        {
            //1000 ft is a normal safe vertical distance for commercial aircraft
            if (OnCrash != null)
                if ((Math.Sqrt(Math.Pow(CoordinateX - p.CoordinateX, 2) + Math.Pow(CoordinateY - p.CoordinateY, 2)) <=
                     Area * 2) && (this.Altitude - 1000 <= p.Altitude && this.Altitude + 1000 >= p.Altitude))
                    OnCrash(this, p);
        }

        /// <summary>
        /// The movement of the airplane in the direction of the next <see cref="AbstractCheckpoint"/> on its path
        /// to its final destination (be it landing or exiting the airspace).
        /// </summary>
        public void MoveTowardsNextPoint()
        {
            if (target == null)
            {
                target = ShortestPath.First;
                target = target.Next;
            }

            if (Math.Abs(CoordinateX - ShortestPath.Last.Value.CoordinateX) < Cell.Width * 3 &&
                Math.Abs(CoordinateY - ShortestPath.Last.Value.CoordinateY) < Cell.Width * 3 &&
                target.Value.GetType() == typeof(Airstrip) &&
                OnAirportReached != null)
            {
                this.CoordinateX = target.Value.CoordinateX;
                this.CoordinateY = target.Value.CoordinateY;
                target = null;
                OnAirportReached(this, EventArgs.Empty);
                return;
            }
            else if (Math.Abs(CoordinateX - ShortestPath.Last.Value.CoordinateX) < Cell.Width * 3 &&
                     Math.Abs(CoordinateY - ShortestPath.Last.Value.CoordinateY) < Cell.Width * 3 &&
                     target.Value.GetType() == typeof(Checkpoint) && OnAirspaceExit != null)
            {
                OnAirspaceExit(this, EventArgs.Empty);
                return;
            }

            if (movingDirectionHasChanged)
            {
                double a = (target.Value.CoordinateY - CoordinateY) / Grid.PixelsPerMileVertically; //"side a" in miles
                double b = (target.Value.CoordinateX - CoordinateX) /
                           Grid.PixelsPerMileHorizontally; //"side b" in miles
                double
                    c = Math.Sqrt(Math.Pow(a, 2) +
                                  Math.Pow(b, 2)); //the distance the plane has to fly in miles; Pythagoras again

                double t = c / milesPerSecond; //the time which the plane will need to fly this distance

                leapx = (b / t) * Grid
                            .PixelsPerMileHorizontally; //the x speedInKts of the airplane in miles times pixels per mile 
                leapy = (a / t) * Grid.PixelsPerMileVertically; //the y speedInKts of the airplane in miles

                movingDirectionHasChanged = false;
            }

            //if the airplane goes through a checkpoint
            if (Math.Abs(CoordinateX - target.Value.CoordinateX) < Cell.Width * 3 &&
                Math.Abs(CoordinateY - target.Value.CoordinateY) < Cell.Width * 3)
            {
                var toRemove = target;

                target = target.Next;

                if (target != null)
                {
                    MinSpeed = target.Value.MinSpeed;
                    MaxSpeed = target.Value.MaxSpeed;
                    SpeedInKts = target.Value.MaxSpeed;

                    if (speedInKts == 0)
                    {
                        MinSpeed = 120;
                        MaxSpeed = 150;
                        SpeedInKts = 150;
                    }

                    MinAltitude = target.Value.MinAltitude;
                    MaxAltitude = target.Value.MaxAltitude;
                    Altitude = target.Value.MaxAltitude-1;
                }

                ShortestPath.Remove(toRemove.Value);

                movingDirectionHasChanged = true;


            }

            CoordinateX += leapx;
            CoordinateY += leapy;
            this.Rect = new Rectangle((int) CoordinateX - Area, (int) CoordinateY - Area, Area * 2, Area * 2);
        }


        /// <summary>
        /// Calculates the shortest path between the airplane and its final destination - the airstrip.
        /// </summary>
        /// <param name="points">All the checkpoints in the airspace. No airstrips, no airplanes.</param>
        /// <param name="landingStrip">The landing strip the airplane is going for.</param>
        public void CalculateShortestPathToAirstrip(List<Checkpoint> points, Airstrip landingStrip)
        {
            this.ReachableNodes.Clear();

            this.ShortestPath.Clear();

            foreach (Checkpoint point in points)
            {
                if (target == null && (point.ParentCellType == CellType.UPPER ||
                                       point.ParentCellType == CellType.UNASSIGNED))
                {
                    this.AddSingleDestination(point, CalculateTimeBetweenPoints(point));
                }
                else if (target != null && target.Value.GetType() == typeof(Airstrip))
                {
                    ShortestPath.Clear();
                    ShortestPath.AddFirst(target);
                    return;
                }
                else if (target != null && point.ParentCellType == ((Checkpoint) target.Value).ParentCellType)
                {
                    this.AddSingleDestination(point, CalculateTimeBetweenPoints(point));
                }


                point.ShortestPath.Clear();
                point.DistanceFromSource = int.MaxValue;
            }


            landingStrip.DistanceFromSource = int.MaxValue;
            landingStrip.ShortestPath.Clear();

            HashSet<AbstractCheckpoint> settledCheckpoints = new HashSet<AbstractCheckpoint>();
            HashSet<AbstractCheckpoint> unsettledCheckpoints = new HashSet<AbstractCheckpoint> {this};


            while (unsettledCheckpoints.Count != 0)
            {
                AbstractCheckpoint currentCheckpnt = this.GetLowestDistanceNode(unsettledCheckpoints);
                unsettledCheckpoints.Remove(currentCheckpnt);
                foreach (var pair in currentCheckpnt.ReachableNodes)
                {
                    AbstractCheckpoint reachableCheckpoint = pair.Key;
                    double edgeWeight = pair.Value;

                    if (!settledCheckpoints.Contains(reachableCheckpoint))
                    {
                        var shortestPath = CalculateMinDistance(reachableCheckpoint, edgeWeight, currentCheckpnt);
                        if (shortestPath != null && reachableCheckpoint.GetType() == typeof(Airstrip))
                        {
                            shortestPath.AddLast(reachableCheckpoint);

                            this.ShortestPath = new LinkedList<AbstractCheckpoint>();
                            var pathNode = shortestPath.First;

                            while (pathNode != null)
                            {
                                this.ShortestPath.AddLast(pathNode.Value);
                                pathNode = pathNode.Next;
                            }
                        }

                        unsettledCheckpoints.Add(reachableCheckpoint);
                    }
                }

                settledCheckpoints.Add(currentCheckpnt);
            }

            if (this.ShortestPath.Count != 0)
            {
                movingDirectionHasChanged = true;
                target = ShortestPath.First;
                target = target.Next;
            }
        }


        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return this.Name + " -- " + this.FlightNumber;
        }

        /// <summary>Determines whether the specified object is equal to the current object.</summary>
        /// <param name="obj">The object to compare with the current object. </param>
        /// <returns>
        /// <see langword="true" /> if the specified object  is equal to the current object; otherwise, <see langword="false" />.</returns>
        public override bool Equals(object obj)
        {
            var airplane = obj as Airplane;
            return airplane != null &&
                   Name == airplane.Name &&
                   FlightNumber == airplane.FlightNumber;
        }

        public void RevertPath()
        {
            ShortestPath.Reverse();
        }

        /// <summary>
        /// Calculates the shortest path between the airplane and the point through which it has to leave the airspace.
        /// </summary>
        /// <param name="points">All the checkpoints in the airspace. No airstrips, no airplanes.</param>
        /// <param name="exitCheckpoint">The checkpoint through which the plane has to leave the airspace.</param>
        public void CalculateShortestPathLeavingAirspace(List<Checkpoint> points)
        {
            this.ReachableNodes.Clear();
            this.ShortestPath.Clear();

            foreach (Checkpoint point in points)
            {
                if (target == null && point.ParentCellType == CellType.FINAL)
                {
                    this.AddSingleDestination(point, CalculateTimeBetweenPoints(point));
                }
                else if (target != null && target.Equals(ShortestPath.Last)
                ) //if this doesn't work: ((Checkpoint)target.Value).ParentCellType == Cell.BORDER
                {
                    ShortestPath.Clear();
                    ShortestPath.AddFirst(target);
                    return;
                }
                else if (target != null && point.ParentCellType == ((Checkpoint)target.Value).ParentCellType)
                {
                    this.AddSingleDestination(point, CalculateTimeBetweenPoints(point));
                }

                point.ShortestPath.Clear();
                point.DistanceFromSource = int.MaxValue;
            }

            exitDestination.DistanceFromSource = int.MaxValue;
            exitDestination.ShortestPath.Clear();

            HashSet<AbstractCheckpoint> settledCheckpoints = new HashSet<AbstractCheckpoint>();
            HashSet<AbstractCheckpoint> unsettledCheckpoints = new HashSet<AbstractCheckpoint> { this };


            while (unsettledCheckpoints.Count != 0)
            {
                AbstractCheckpoint currentCheckpnt = this.GetLowestDistanceNode(unsettledCheckpoints);
                unsettledCheckpoints.Remove(currentCheckpnt);
                foreach (var pair in currentCheckpnt.ReachableNodes)
                {
                    AbstractCheckpoint reachableCheckpoint = pair.Key;
                    double edgeWeight = pair.Value;

                    if (!settledCheckpoints.Contains(reachableCheckpoint))
                    {
                        var shortestPath = CalculateMinDistance(reachableCheckpoint, edgeWeight, currentCheckpnt);
                        if (shortestPath != null && reachableCheckpoint.GetType() == typeof(Checkpoint) &&
                            ((Checkpoint)reachableCheckpoint).ParentCellType == CellType.BORDER)
                        {
                            shortestPath.AddLast(reachableCheckpoint);

                            this.ShortestPath = new LinkedList<AbstractCheckpoint>();
                            var pathNode = shortestPath.First;

                            while (pathNode != null)
                            {
                                this.ShortestPath.AddLast(pathNode.Value);
                                pathNode = pathNode.Next;
                            }
                        }

                        unsettledCheckpoints.Add(reachableCheckpoint);
                    }
                }

                settledCheckpoints.Add(currentCheckpnt);
            }

            if (this.ShortestPath.Count != 0)
            {
                movingDirectionHasChanged = true;
                target = ShortestPath.First;
                target = target.Next;
            }
        }

        public override int GetHashCode()
        {
            var hashCode = 1980789528;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FlightNumber);
            return hashCode;
        }
    }
}