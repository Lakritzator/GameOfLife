using System;

namespace GameOfLife.Board
{
    /// <summary>
    /// Cell
    /// </summary>
    public class Cell : IEquatable<Cell>
    {
        /// <summary>
        /// X part of the coordinate
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Y part of the coordinate
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Create a Cell
        /// </summary>
        /// <param name="x">X part of the coordinate</param>
        /// <param name="y">Y part of the coordinate</param>
        public Cell(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Create a new Cell with the mentioned offset
        /// </summary>
        /// <param name="offset">Tuple x,y</param>
        /// <returns>new Cell</returns>
        public Cell WithOffset(Tuple<int, int> offset)
        {
            return new Cell(X + offset.Item1, Y + offset.Item2);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }

        bool IEquatable<Cell>.Equals(Cell other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return X == other.X && Y == other.Y;
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Cell) obj);
        }
    }
}
