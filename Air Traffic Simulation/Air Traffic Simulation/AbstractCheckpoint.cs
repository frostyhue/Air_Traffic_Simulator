using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Air_Traffic_Simulation
{
    /// <summary>
    /// Represents the minimum structure every <see cref="Airplane"/>/<see cref="Airstrip"/>/<see cref="Checkpoint"/> 
    /// should have.
    /// </summary>
    [Serializable]
    public abstract class AbstractCheckpoint
    {
        #region Properties and Class Variables

        /// <summary>
        /// The name of the <see cref="Airplane"/>/<see cref="Airstrip"/>/<see cref="Checkpoint"/>
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// The horizontal coordinates of the object. (Upper left corner)
        /// </summary>
        public abstract double CoordinateX { get; set; }

        /// <summary>
        /// The vertical of the object. (Upper left corner)
        /// </summary>
        public abstract double CoordinateY { get; set; }

        /// <summary>
        /// The shortest path from this AbstractCheckpoint, to whatever final goal it had set
        /// by an <see cref="Airplane"/>. This is only needed for the <see cref="Airplane"/> to get its 
        /// own ShortestPath calcualted.
        /// </summary>
        public abstract LinkedList<AbstractCheckpoint> ShortestPath { get; set; }

        /// <summary>
        /// The distance drom this AbstractCheckpoint to the "final goal" of the path finding.
        /// </summary>
        public abstract double DistanceFromSource { get; set; }

        /// <summary>
        /// All the other AbstractCheckpoints that can be reached from the current one.
        /// </summary>
        public abstract Dictionary<AbstractCheckpoint, double> ReachableNodes { get; set; }


        /// <summary>
        /// The max speed an <see cref="Airplane"/> can be assigned upon the passing of this point.
        /// </summary>
        public abstract int MaxSpeed { get; set; }

        /// <summary>
        /// The min speed an <see cref="Airplane"/> can be assigned upon the passing of this point.
        /// </summary>
        public abstract int MinSpeed { get; set; }

        /// <summary>
        /// The max altitude an <see cref="Airplane"/> can be assigned upon the passing of this point.
        /// </summary>
        public abstract int MaxAltitude { get; set; }

        /// <summary>
        /// The min altitude an <see cref="Airplane"/> can be assigned upon the passing of this point.
        /// </summary>
        public abstract int MinAltitude { get; set; }

        #endregion

        /// <summary>
        /// Uses Pythagoras' theorem to calculate the distance between two checkpoints.
        /// </summary>
        /// <param name="a">The checkpoint we are looking for the distance from.</param>
        /// <returns>The distance between the two checkpoints given as arguments.</returns>
        public virtual double CalculateDistanceBetweenPoints(AbstractCheckpoint a)
        {
            return Math.Sqrt(Math.Pow(Math.Abs(this.CoordinateX - a.CoordinateX), 2) +
                             Math.Pow(Math.Abs(this.CoordinateY - a.CoordinateY), 2));
        }

        /// <summary>
        /// Using just the distance as a factor for the shortest distance calculation seems silly.
        /// This is why this method calculates the time it will take an <see cref="Airplane"/>
        /// to get from the current point to a. 
        /// </summary>
        /// <param name="a">The point, to which the time needed to get to it needs to be calculated. </param>
        /// <returns></returns>
        public virtual double CalculateTimeBetweenPoints(AbstractCheckpoint a)
        {
            return CalculateDistanceBetweenPoints(a) / this.MaxSpeed;
        }

        /// <summary>
        /// Adds a single destination to an AbstractCheckpoint's <see cref="ReachableNodes"/> list.
        /// </summary>
        /// <param name="destination">The destination, which needs to be added to the calling object's reachables.</param>
        /// <param name="weightOfDistance">A unit signifying the weight of the trip between the two points. This can either
        /// be straight up the straight line distance between the two, the time it would take to get from one to the other, 
        /// or it can be influenced by other factors (which we did not see the need to implement.)</param>
        public virtual void AddSingleDestination(AbstractCheckpoint destination, double weightOfDistance)
        {
            if (this.CoordinateX != destination.CoordinateX || this.CoordinateY != destination.CoordinateY ||
                !this.Name.Equals(destination.Name))
            {
                ReachableNodes[destination] = weightOfDistance;
            }
        }

        /// <summary>
        /// Retrieves the AbstractCheckpoint "closest" to the calling AbstractCheckpoint. This is taken from the list
        /// of points, which still haven't been traversed by the path finding algorithm.
        /// 
        /// Note: closest does NOT neccessarily mean the closest just in terms of distance, but the "lightest edge between two nodes"
        /// </summary>
        /// <param name="unsettledCheckpoints">The list of points, which still haven't been traversed by the algorithm.</param>
        /// <returns>The "closest" checkpoint to the caller.</returns>
        public virtual AbstractCheckpoint GetLowestDistanceNode(HashSet<AbstractCheckpoint> unsettledCheckpoints)
        {
            AbstractCheckpoint lowestDistanceCP = null;
            double lowestDist = Int32.MaxValue;

            foreach (var checkpnt in unsettledCheckpoints)
            {
                double checkpntDistance = checkpnt.DistanceFromSource;

                if (checkpntDistance < lowestDist)
                {
                    lowestDist = checkpntDistance;
                    lowestDistanceCP = checkpnt;
                }
            }

            return lowestDistanceCP;
        }

        /// <summary>
        /// Compares the currently defined shortest distance present for the sourceCheckpoint to a candidate for a shorter way -
        /// the evaluation checkpoint with the distance that comes with it.
        /// </summary>
        /// <param name="evaluationCheckpoint"></param>
        /// <param name="edgeWeight">The </param>
        /// <param name="sourceCheckpoint"></param>
        /// <returns></returns>
        public virtual LinkedList<AbstractCheckpoint> CalculateMinDistance(AbstractCheckpoint evaluationCheckpoint,
            double edgeWeight,
            AbstractCheckpoint sourceCheckpoint)
        {
            double sourceDistance = sourceCheckpoint.DistanceFromSource;

            if (sourceDistance + edgeWeight < evaluationCheckpoint.DistanceFromSource)
            {
                evaluationCheckpoint.DistanceFromSource = sourceDistance + edgeWeight;
                LinkedList<AbstractCheckpoint> shortestPath =
                    new LinkedList<AbstractCheckpoint>(sourceCheckpoint.ShortestPath);
                shortestPath.AddLast(sourceCheckpoint);
                evaluationCheckpoint.ShortestPath = shortestPath;

                return shortestPath;
            }

            return null;
        }


        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return $"{this.Name} ({this.CoordinateX}, {this.CoordinateY})";
        }
    }
}