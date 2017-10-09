using System.Collections;
using System.Collections.Generic;

namespace GameOfLife.Board
{
    /// <summary>
    /// This is a container for multiple cells which simplifies the constructing
    /// </summary>
    public class Cells : IEnumerable<Cell>
    {
        private readonly IList<Cell> _cells = new List<Cell>();
        /// <summary>
        /// Add a cell to the cells
        /// </summary>
        /// <param name="x">int</param>
        /// <param name="y">int</param>
        public void Add(int x, int y)
        {
            _cells.Add(new Cell(x, y));
        }

        /// <inheritdoc />
        public IEnumerator<Cell> GetEnumerator()
        {
            return _cells.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
