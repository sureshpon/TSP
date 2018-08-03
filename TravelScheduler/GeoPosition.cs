using System.Device.Location;

namespace Suresh.Fun.TravelScheduler
{
    /// <summary>
    /// Represents the geographical coordinate position class
    /// </summary>
    public class GeoPosition
    {
        /// <summary>
        /// Gets the latitude of the geographical coordinate
        /// </summary>
        /// <value>The latitude in decimal coordinate</value>
        public double Latitude { get; }

        /// <summary>
        /// Gets the longitude of the geographical coordinate
        /// </summary>
        /// <value>The longitude in decimal coordinate</value>
        public double Longitude { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GeoPosition"/> class.
        /// </summary>
        /// <param name="latitude">The latitude in decimal coordinate</param>
        /// <param name="longitude">The longitude in decimal coordinate</param>
        public GeoPosition(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        /// <summary>
        /// Gives distance from given coordinate position
        /// </summary>
        /// <param name="coordinate">The coordinate.</param>
        /// <returns>Distance in KM</returns>
        public double DistanceFrom(GeoPosition coordinate)
        {
            var sCoord = new GeoCoordinate(Latitude, Longitude);
            var eCoord = new GeoCoordinate(coordinate.Latitude, coordinate.Longitude);

            return sCoord.GetDistanceTo(eCoord) / 1000; // distance in KM.
        }
    }
}