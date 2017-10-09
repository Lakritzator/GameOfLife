using System.Linq;
using Xunit;

namespace GameOfLife.Board.Tests
{
    public class BoardTests
    {
        [Fact]
        public void TestStable()
        {
            // Arrange
            var board = new GameBoard();
            var stable = new Cells
            {
                {10, 10},
                {11, 10},
                {12, 10}
            };
            board.SetBoardContent(stable);
            // Act
            var newCell = board.NextIteration().First();

            // Assert, should have a new cell (and a stable one)
            Assert.Equal(new Cell(11, 10), newCell);
        }

        [Fact]
        public void TestBirth()
        {
            // Arrange
            var board = new GameBoard();

            var birth = new Cells
            {
                {10, 10},
                {11, 9},
                {12, 10}
            };

            board.SetBoardContent(birth);

            // Act
            var newCells = board.NextIteration();

            // Assert, should have a new cell (and a stable one)
            Assert.Contains(new Cell(11, 10), newCells);
        }

        [Fact]
        public void TestCellOffset()
        {
            // Arrange
            var board = new GameBoard
            {
                Width = 100,
                Height = 100
            };

            // Act, 
            var cells = board.Neighbours(new Cell(0, 0)).ToList();

            // Assert 
            // 1st row
            // 0,0 offset -1, -1
            Assert.Contains(new Cell(99, 99), cells);
            // 0,0 offset 0, -1
            Assert.Contains(new Cell(0, 99), cells);
            // 0,0 offset 1, -1
            Assert.Contains(new Cell(1, 99), cells);


            // 2nd row
            // 0,0 offset -1, 0
            Assert.Contains(new Cell(99, 0), cells);
            // 0,0 offset 1, 0
            Assert.Contains(new Cell(1, 0), cells);

            // 3rd row
            // 0,0 offset -1, 1
            Assert.Contains(new Cell(99, 1), cells);
            // 0,0 offset 0, 1
            Assert.Contains(new Cell(0, 1), cells);
            // 0,0 offset 1, 1
            Assert.Contains(new Cell(1, 1), cells);
        }
        [Fact]
        public void TestBoardWrapping_Board()
        {
            // Arrange
            var board = new GameBoard();

            var wrapping = new Cells
            {
                {0, 0},
                {98, 0},
                {99, 0}
            };
            board.SetBoardContent(wrapping);

            // Act
            var cells = board.NextIteration().ToList();

            // Asset, should have a new cell (and a stable one)

            Assert.Contains(new Cell(99, 0), cells);
        }
    }
}
