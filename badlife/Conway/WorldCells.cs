using System;
using System.IO;

namespace badlife
{
    public class WorldCells : IWorldCells
    {
        public readonly string[] Cells;
        public WorldCells(string path)
        {
            Cells = CreateWorldCells(path);
        }
   
        public string[] CreateWorldCells(string path)
        {
            using (var reader = new StreamReader(path))
            {
                return reader.ReadToEnd().Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}
