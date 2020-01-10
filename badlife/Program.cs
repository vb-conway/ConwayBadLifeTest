using System;
using System.Linq;
using System.Threading;

namespace badlife
{
    /// <summary>
    /// Implements Conway's Game Of Life badly
    /// https://en.wikipedia.org/wiki/Conway%27s_Game_of_Life on a torus
    /// </summary>
    class Program
    {
        private const string Path = "sample_input.txt"; 

        static int Main(string[] args)
        {
            #region Create WorldGrid with WorldCells

            IWorldCells worldCells = new WorldCells(Path);

            WorldGrid worldGrid = new WorldGrid(worldCells);
            worldGrid.Initialize();

            #endregion

            #region Create Strategy

            INeighbourCountStrategy neighboursStrategy = new NeighboursStrategy();
            IEvolutionStrategy mutationStrategy = new EvolutionStrategy();

            #endregion

            //while there is any live cells
            while (worldGrid.Grid.SelectMany(d => d).Contains(true))
            {
                worldGrid.Display();
                Thread.Sleep(1000);

                //Create world
                World initWorld = new World(worldGrid, neighboursStrategy, mutationStrategy);

                //Evolution
                WorldGrid evolutionGrid = initWorld.Evolve();

                //the old grid will now become new grid
                worldGrid = evolutionGrid;
            }
            Console.WriteLine();
            Console.WriteLine("World is Dead !");
            Console.WriteLine();
            Console.WriteLine("Please try another Pattern or different Evolution / Neighbour Count Strategy. ");
            Console.ReadLine();
            return 42;
        }
    }
}
