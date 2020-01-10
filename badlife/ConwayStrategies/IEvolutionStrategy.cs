namespace badlife
{
    public interface IEvolutionStrategy
    {
        void Mutate(WorldGrid worldGrid, uint neighbours, bool state, int xCord, int yCord);
    }
}