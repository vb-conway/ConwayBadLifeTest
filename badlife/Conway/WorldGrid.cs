using System;

namespace badlife
{
    public class WorldGrid
    {
        public readonly IWorldCells WorldCells;
        public bool[][] Grid { get; set; }
        public WorldGrid(IWorldCells cells)
        {
            WorldCells = cells;
            Grid = CreateGridToHostCells(cells);
        }

        private bool[][] CreateGridToHostCells(IWorldCells worldCells)
        {
            if (worldCells is null)
            {
                throw new ArgumentNullException(nameof(worldCells), "Please Provide Cells for World Creation. ");
            }
            var cells = ((WorldCells)worldCells).Cells;
            var grid = new bool[cells.Length][];
            for (int x = 0; x < cells.Length; ++x)
            {
                grid[x] = new bool[cells[x].Length];
            }
            return grid;
        }

        public void Initialize()
        {
            var grid = Grid;
            var cells = ((WorldCells)WorldCells).Cells;

            for (int i = 0; i < cells.Length; i++)
            {
                for (int j = 0; j < cells[i].Length; j++)
                {
                    if (cells[i][j] == '_')
                    {
                        grid[i][j] = false;
                    }
                    else if (cells[i][j] == '*')
                    {
                        grid[i][j] = true;
                    }
                }
            }
        }

        public void Display()
        {
            for (int a = 0; a < Grid.Length; a++)
            {
                string line = "";
                for (int b = 0; b < Grid[0].Length; ++b)
                {
                    if (Grid[a][b])
                        line = line + "*";
                    else
                    {
                        line = line + "_";
                    }
                }
                Console.WriteLine(line);
            }
        }

        public WorldGrid Clone(IWorldCells worldCells)
        {
            return new WorldGrid(worldCells);
        }
    }
}
