using System;

namespace GameOfLife.Board
{
    /// <summary>
    /// Cell
    /// </summary>
    public sealed class Cell : IEquatable<Cell>
    {
        /// <summary>
        /// X part of the coordinate
        /// </summary>
        public int X { get; }

        /// <summary>
        /// Y part of the coordinate
        /// </summary>
        public int Y { get; }

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
        /// <param name="boardWidth">Width of the board, used for wrapping</param>
        /// <param name="boardHeight">Height of the board, used for wrapping</param>
        /// <returns>new Cell</returns>
        public Cell WithOffset(Tuple<int, int> offset, int boardWidth, int boardHeight)
        {
            var x = X + offset.Item1;
            var y = Y + offset.Item2;

            // Wrap logic X
            if (x < 0)
            {
                x = boardWidth + x % boardWidth;
            }
            if (x >= boardWidth)
            {
                x = x % boardWidth;
            }

            // Wrap logic Y
            if (y < 0)
            {
                y = boardHeight + y % boardHeight;
            }
            if (y >= boardHeight)
            {
                y = y % boardHeight;
            }
            return new Cell(x, y);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }

        /// <inheritdoc />
        public bool Equals(Cell other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return X == other.X && Y == other.Y;
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Cell) obj);
        }
    }
}
