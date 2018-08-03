using Suresh.Fun.TravelScheduler;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Suresh.Fun.UnitTests
{
    /// <summary>
    /// Tests the program behavior.
    /// </summary>
    [TestClass]
    public class AlgorithmsTest
    {
        /// <summary>
        /// Realistic visual inspection test. Here cities are created with real coordinates based on AlgorithmsTest.PNG.
        /// Coordinate were selected with Visual inspection, which completely gives different results for
        /// Nearest neighbour route and optimized route.
        /// </summary>
        [TestMethod]
        public void RealisticVisualInspection_Test()
        {
            List<City> cities = new List<City>
            {
                new City("British Columbia", new GeoPosition(49.958339, -123.143833)),
                new City("Alberta", new GeoPosition(58.458904, -116.187442)),
                new City("Saskatchewan", new GeoPosition(51.376705, -103.263554)),
                new City("Manitoba", new GeoPosition(53.797236, -96.607212)),
                new City("Ontario", new GeoPosition(51.452722, -83.932216)),
                new City("Quebec", new GeoPosition(47.502418, -73.025056)),
                new City("New York", new GeoPosition(42.748957, -75.595856)),
                new City("California", new GeoPosition(37.725083, -120.258751)),
                new City("Washington", new GeoPosition(47.706278, -119.765803)),
                new City("Montana", new GeoPosition(46.545163, -109.419650))
            };

            var initalRoute = cities.FindNearestNeighbourRoute();

            Tour nonOptimizedTour = new Tour(initalRoute);

            nonOptimizedTour.TourPlaces.ToList().ForEach(i => Trace.WriteLine(i.Name));
            Trace.WriteLine(nonOptimizedTour.Distance());
            Trace.WriteLine("\n");

            /*  British Columbia
              Washington
              Montana
              Saskatchewan
              Manitoba
              Ontario
              Quebec
              New York
              Alberta
              California
              11723.78142737818*/

            var optimizedTour = nonOptimizedTour.TwoOptSwapOptimization();

            optimizedTour.Last().TourPlaces.ToList().ForEach(i => Trace.WriteLine(i.Name));
            Trace.WriteLine(optimizedTour.Last().Distance());
            Trace.WriteLine("\n");

            /* British Columbia
             Alberta
             Manitoba
             Ontario
             Quebec
             New York
             Saskatchewan
             Montana
             California
             Washington
             10502.1766369169 */
        }

        /// <summary>
        /// Tests with high load; randomly generated 150 countries.
        /// just to make sure 150 entries can run within 5 minutes; may vary machine to machine depending on the system resources
        /// </summary>
        [TestMethod]
        [Timeout(300000)]
        [Ignore] // remove if test needed
        public void HighLoad_Test()
        {
            List<City> cities = new List<City>();

            // add random 150 cities
            for (int i = 0; i < 150; i++)
            {
                cities.Add(new City(i.ToString(), new GeoPosition(RandomNumber(40.0, 65.0), -1 * RandomNumber(80.0, 140.0))));
            }

            var initalRoute = cities.FindNearestNeighbourRoute();

            Tour nonOptimizedTour = new Tour(initalRoute);

            nonOptimizedTour.TourPlaces.ToList().ForEach(i => Trace.WriteLine(i.Name));
            Trace.WriteLine(nonOptimizedTour.Distance());
            Trace.WriteLine("\n");

            var optimizedTour = nonOptimizedTour.TwoOptSwapOptimization();

            optimizedTour.Last().TourPlaces.ToList().ForEach(i => Trace.WriteLine(i.Name));
            Trace.WriteLine(optimizedTour.Last().Distance());
            Trace.WriteLine("\n");
        }


        private readonly Random random = new Random();
        private double RandomNumber(double minValue, double maxValue)
        {
            return minValue + (random.NextDouble() * (maxValue - minValue));
        }
    }
}