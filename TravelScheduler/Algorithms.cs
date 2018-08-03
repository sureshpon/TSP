using System.Collections.Generic;
using System.Linq;

namespace Suresh.Fun.TravelScheduler
{
    /// <summary>
    /// Represents algorithm routines 
    /// </summary>
    public static class Algorithms
    {
        #region -- Nearest neighbour Algorithms --

        // https://en.wikipedia.org/wiki/Nearest_neighbour_algorithm

        /// <summary>
        /// Finds the nearest neighbour route.
        /// </summary>
        /// <param name="stops">IEnumerable of cities</param>
        /// <returns> IEnumerable of cities with nearest neighbours linked</returns>
        public static IEnumerable<City> FindNearestNeighbourRoute(this IEnumerable<City> stops)
        {
            var visitingStops = stops.ToList();
            var stop = visitingStops.First();
            while (true)
            {
                yield return stop;
                visitingStops.Remove(stop);
                if (visitingStops.Count() == 0)
                {
                    stop.NextVisit = stops.First(); // links the last city to start city
                    break;
                }
                var nextStop = visitingStops.Aggregate((s1, s2) => stop.DistanceFrom(s1) <= stop.DistanceFrom(s2) ? s1 : s2);
                stop.NextVisit = nextStop; // link the cities
                stop = nextStop;
            }
        }
        #endregion

        #region -- Optimization Algorithms --

        //https://en.wikipedia.org/wiki/2-opt

        /// <summary>
        /// 2-opt optimization routine
        /// </summary>
        /// <param name="initialTour">The initial tour.</param>
        /// <returns>IEnumerable of optimized tour. The last one is the final one</returns>
        public static IEnumerable<Tour> TwoOptSwapOptimization(this Tour initialTour)
        {
            bool isNewRoute;
            do
            {
                isNewRoute = false;
                yield return initialTour;

                for (int i = 1; i < initialTour.TourPlaces.Count() - 1; i++)
                {
                    for (int k = i + 1; k < initialTour.TourPlaces.Count(); k++)
                    {
                        var newRoute = TwoOptSwap(initialTour.TourPlaces, i, k);
                        Tour newTour = new Tour(newRoute);
                        if (newTour.Distance() < initialTour.Distance())
                        {
                            initialTour = newTour;
                            isNewRoute = true;
                            break;
                        }
                    }
                    if (isNewRoute) break;
                }
            } while (isNewRoute);
        }

        private static IEnumerable<City> TwoOptSwap(this IEnumerable<City> stops, int i, int k)
        {
            var currentRoute = stops.ToList();

            IEnumerable<City> newRoute = currentRoute.Take(i)
                .Concat(currentRoute.Skip(i).Take(k - i + 1).Reverse()
                .Concat(currentRoute.Skip(k + 1).Take(currentRoute.Count - k - 1))); 

            newRoute.LinkCities();

            return newRoute;
        }

        private static void LinkCities(this IEnumerable<City> cities)
        {
            City prev = null, first = null;
            foreach (var city in cities)
            {
                if (first == null) first = city;
                if (prev != null) prev.NextVisit = city;
                prev = city;
            }

            prev.NextVisit = first; // Link the last node to first
        }

        #endregion
    }
}