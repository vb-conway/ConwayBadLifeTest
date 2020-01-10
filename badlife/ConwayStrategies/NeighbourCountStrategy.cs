using System;

namespace badlife
{
    public class NeighboursStrategy : INeighbourCountStrategy
    {
        public uint CountNeighbours(WorldGrid worldGrid, int xCord, int yCord)
        {
            var initGrid = worldGrid.Grid;

            uint neighbours = 0;
            uint rows = (uint)initGrid.Length;
            uint cols = (uint)initGrid[0].Length;

            //will generate 9 points on the Grid including point of reference (xCord,yCord)
            //this is later taken out from neighbours to exclude the (xCord,yCord)
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                { 
                    //(xCord + i + rows) % rows, wraps the grid round (edge cases) and works for all  point on Grid incuding edges on both sides
                    //example for xCord = 0, the Top Most Row, xCord = 0, say i =-1, rows=10 will produce 9 which wraps the rows aroound
                    //same is case with yCord or columns
                    var rowNeighbourIndex = (xCord + i + rows) % rows;
                    var colNeighbourIndex = (yCord + j + cols) % cols;
                    neighbours += (uint)Convert.ToInt32(initGrid[rowNeighbourIndex][colNeighbourIndex]);
                }
            }
            neighbours -= (uint)Convert.ToInt32(initGrid[xCord][yCord]);
            return neighbours;
        }
    }
}
