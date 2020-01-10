namespace badlife
{
    public interface INeighbourCountStrategy
    {
        uint CountNeighbours(WorldGrid worldGrid, int xCord, int yCord);
    }
}