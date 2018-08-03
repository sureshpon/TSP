TSP

Traveling Salesman problem, identified as NP-hard problem in optimization. This is just a fun way of implementing not only using plain C# (arrays, loops, conditionals) but also extensively using LINQ and .NET collections. In performance-critical scenarios, it may force to avoid high-level .NET language features. 

The following assumptions are made.
1. Traveling city details are read from a file called Travel.data. File only has valid entries.
2.  There is always a direct path for a given two cities.
4. Interconnecting cities are satisfying Triangle-Inequality

Based on these assumptions, the implementation follows the Nearest neighbors to find the initial route and then trying to optimize the result with 2-opt optimization. 

https://en.wikipedia.org/wiki/Nearest_neighbour_algorithm

https://en.wikipedia.org/wiki/2-opt

2-opt  not always gives the optimal solution. There are several other alternative approaches. 
