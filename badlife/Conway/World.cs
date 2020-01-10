using System;
using System.IO;

namespace badlife
{
    public class World
    {
        private readonly WorldGrid WorldGrid;
        private readonly INeighbourCountStrategy NeighboursStrategy;
        private readonly IEvolutionStrategy MutationStrategy; 
   
        public World(WorldGrid worldGrid, INeighbourCountStrategy neighboursStrategy, IEvolutionStrategy mutationStrategy)
        {
            WorldGrid = worldGrid;
            NeighboursStrategy = neighboursStrategy;
            MutationStrategy = mutationStrategy;
        }
        
        public WorldGrid Evolve()
        {
            //Get the gen0 Grid
            var initGrid = WorldGrid.Grid;

            //Create a gen1, mutated Grid to store new state
            var mutatedWorldGrid = WorldGrid.Clone(WorldGrid.WorldCells);
  
            for (var g = 0; g < initGrid.Length; ++g)
            {
                for (var k = 0; k < initGrid[0].Length; ++k)
                {
                    var initState = initGrid[g][k];
                    //Count Neighbours
                    var neighbours = NeighboursStrategy.CountNeighbours(WorldGrid, g, k);
                    //Apply Mutation Strategy
                    MutationStrategy.Mutate(mutatedWorldGrid, neighbours, initState, g, k);
                }
            }
            return mutatedWorldGrid;
        }
    }
}
