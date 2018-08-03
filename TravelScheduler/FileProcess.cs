using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Suresh.Fun.TravelScheduler
{
    /// <summary>
    /// Represents the file process class
    /// </summary>
    public class FileProcess
    {
        private IFileAccess fileContent;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileProcess"/> class.
        /// </summary>
        /// <param name="fileContent">An instance of the IFileAccess</param>
        public FileProcess(IFileAccess fileContent)
        {
            this.fileContent = fileContent;
        }

        /// <summary>
        /// Reads the cities asynchronously
        /// </summary>
        /// <returns>Task of List<City> </returns>
        public async Task<List<City>> ReadCities()
        {
            IEnumerable<string> c = null;
            await Task.Run(() => c = fileContent.ReadFile());
            return ToCities(c);
        }

        /// <summary>
        /// Converts the sting of cities to List<City>
        /// </summary>
        /// <param name="rowCities">The row cities read form file</param>
        /// <returns>List<City></returns>
        private List<City> ToCities(IEnumerable<string> rowCities)
        {
            List<City> cities = new List<City>(); // Max 200
            foreach (var item in rowCities)
            {
                var det = item.Split(',');
                cities.Add(new City(det[0], new GeoPosition( Convert.ToDouble(det[1]), Convert.ToDouble(det[2]))));
            }
            return cities;
        }
    }
}