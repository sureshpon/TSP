using System.Collections.Generic;
using System.Linq;

namespace Suresh.Fun.TravelScheduler
{
    /// <summary>
    /// Represents the Tour class
    /// </summary>
    public class Tour
    {
        private double distance;

        /// <summary>
        /// Gets the start city of the tour
        /// </summary>
        public City Start { get; }

        /// <summary>
        /// Gets the tour places in order
        /// </summary>
        public IEnumerable<City> TourPlaces { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Tour"/> class.
        /// </summary>
        /// <param name="stops">The ordered stop places</param>
        public Tour(IEnumerable<City> stops)
        {
            Start = stops.First();
            TourPlaces = stops;
        }

        /// <summary>
        /// Gives the total traveling distance of the Tour
        /// </summary>
        /// <returns>The total traveling distance in KM</returns>
        public double Distance()
        {
            return (distance != 0.0) ? distance :
                distance = TourPlaces.Aggregate(0.0, (sum, stop) => sum + stop.DistanceFrom(stop.NextVisit));
        }
    }
}