namespace badlife
{
    public class EvolutionStrategy : IEvolutionStrategy
    {
        public void Mutate(WorldGrid worldGrid, uint neighbours, bool state, int xCord, int yCord)
        { 
            //If Cell is Alive, it will be alive in Mutated State if it has < 2 or > 3 Neighbours
            //If Cell is Dead, it will come to life when it has exactly 2 Neighbours
            //Else it keeps the Original State, state

            var mutatedWorldGrid = worldGrid.Grid;
            if (state && (neighbours < 2 || neighbours > 3))
                mutatedWorldGrid[xCord][yCord] = false;
            else if (!state && neighbours == 3)
                mutatedWorldGrid[xCord][yCord] = true;
            else
                mutatedWorldGrid[xCord][yCord] = state;
        }
    }
}
