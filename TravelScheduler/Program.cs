using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Suresh.Fun.TravelScheduler
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IFileAccess fileContent;
            IList<City> cities;

            try
            {
                // Read the file path from App.config
                string filePath = ConfigurationManager.AppSettings["FilePath"];
                fileContent = new FileAccess(filePath);
            }
            catch (Exception fe)
            {
                Console.WriteLine("Error: " + fe.InnerException);
                return;
            }

            FileProcess fp = new FileProcess(fileContent);

            var cityTask = fp.ReadCities(); //async call

            Console.WriteLine("Enter Starting city Name: ");
            var startcity = Console.ReadLine();

            try
            {
                cities = cityTask.Result;
            }
            catch (Exception re)
            {
                Console.WriteLine("Error: " + re.InnerException);
                return;
            }

            #region -- Choose preferred start city  --

            City foundstart = null;

            while (cities.First().Name.ToLower() != startcity.ToLower())
            {
                foundstart = cities.Where(c => c.Name.ToLower() == startcity.ToLower()).FirstOrDefault();

                if (foundstart != null)
                {
                    cities.Remove(foundstart);
                    cities.Insert(0, foundstart);
                }
                else
                {
                    Console.WriteLine("Warning: There is no city named : " + startcity);
                    startcity = Console.ReadLine();
                }
            };

            #endregion -- choose different start city  --

            #region -- Find optimized route and print--
            //finding Nearest neighbour connected route 
            var stops = cities.FindNearestNeighbourRoute().ToList();

            Tour nonOptimizedTour = new Tour(stops);

            // Optimize the tour
            var optimizedTours = nonOptimizedTour.TwoOptSwapOptimization();

            foreach (var tour in optimizedTours)
            {
                Console.WriteLine();
                tour.TourPlaces.ToList().ForEach(i => Console.Write(i.Name + "-->"));
                Console.WriteLine(Math.Round(tour.Distance(), 2) + " KM");
                Console.WriteLine("\n");
            }

            #endregion -- Find optimized route and print--

            Console.ReadKey();
        }
    }
}