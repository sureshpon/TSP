namespace Suresh.Fun.TravelScheduler
{
    /// <summary>
    /// Represents the City class
    /// </summary>d
    public class City
    {
        /// <summary>
        /// Gets the name of the City
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the geographic coordinate of the preferred location of the city 
        /// </summary>
        public GeoPosition Location { get; }

        /// <summary>
        /// Gets or sets city where next travel planned from the city
        /// </summary>
        public City NextVisit { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="City"/> class.
        /// </summary>
        /// <param name="name">The name of the city</param>
        /// <param name="location">The geographic coordinate of the city</param>
        public City(string name, GeoPosition location)
        {
            Name = name;
            Location = location;
        }

        /// <summary>
        /// provides the distance of the city from given city
        /// </summary>
        /// <param name="city">The city to measure distance</param>
        /// <returns>distance in KM</returns>
        public double DistanceFrom(City city)
        {
            return  (city != null) ? Location.DistanceFrom(city.Location):0;
        }
    }
}