using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife.Board
{
    /// <summary>
    /// The game of life board
    /// </summary>
    public class GameBoard
    {
        // Offsets for the locations
        private readonly IEnumerable<Tuple<int, int>> _offsets = new List<Tuple<int, int>>
        {
            new Tuple<int, int>(-1, -1),
            new Tuple<int, int>(0, -1),
            new Tuple<int, int>(1, -1),
            new Tuple<int, int>(-1, 1),
            new Tuple<int, int>(0, 1),
            new Tuple<int, int>(1, 1),
            new Tuple<int, int>(-1, 0),
            new Tuple<int, int>(1, 0)
        };

        /// <summary>
        /// Width of the board, can be changed before an iteration
        /// </summary>
        public int Width { get; set; } = 100;

        /// <summary>
        /// Height of the board, can be changed before an iteration
        /// </summary>
        public int Height { get; set; } = 100;

        /// <summary>
        /// A collection of all alive cells
        /// This can be modified before an iteration
        /// </summary>
        public ISet<Cell> Cells { get; private set; } = new HashSet<Cell>();

        /// <summary>
        /// Retrieve the neighbours of a cell
        /// </summary>
        /// <param name="cell">Cell</param>
        /// <returns>IEnumerable with the neighbours</returns>
        public IEnumerable<Cell> Neighbours(Cell cell)
        {
            return _offsets.Select(offset => cell.WithOffset(offset, Width, Height));
        }

        /// <summary>
        /// Create the next iteration of the board
        /// </summary>
        /// <returns>IEnumerable with the locations of the new cells</returns>
        public IEnumerable<Cell> NextIteration()
        {
            ISet<Cell> deadNeighbours = new HashSet<Cell>();
            // Loop over all cells which are alive on the board, inside the dimensions
            foreach (var aliveCell in Cells.Where(location => location.X < Width && location.Y < Height))
            {
                int neighbours = 0;
                // Count the neighbours of the alive cell
                foreach (var neighbourLocation in Neighbours(aliveCell))
                {
                    var isNeighbourAlive = Cells.Contains(neighbourLocation);
                    if (isNeighbourAlive)
                    {
                        neighbours++;
                    }
                    else
                    {
                        // Store the dead neighbours for later, use the set to keep the unique onces
                        deadNeighbours.Add(neighbourLocation);
                    }
                }
                if (neighbours == 2 || neighbours == 3)
                {
                    yield return aliveCell;
                }
            }

            // Loop over the unique dead cells which have exactly 3 neighbours which are alive
            foreach (var deadCellWithNeighbour in deadNeighbours)
            {
                if (Neighbours(deadCellWithNeighbour).Where(Cells.Contains).Take(4).Count() == 3)
                {
                    yield return deadCellWithNeighbour;
                }
            }
        }

        /// <summary>
        /// Set the board with the new cells
        /// </summary>
        /// <param name="cells">IEnumerable with the new cells</param>
        public void SetBoardContent(IEnumerable<Cell> cells)
        {
            Cells = new HashSet<Cell>(cells);
        }
    }
}
