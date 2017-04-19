using System.Linq;
using Xunit;

namespace GameOfLife.Board.Tests
{
    public class BoardTests
    {
        [Fact]
        public void TestStable()
        {
            var board = new Board();
            board.Cells.Add(new Cell(10, 10));
            board.Cells.Add(new Cell(11, 10));
            board.Cells.Add(new Cell(12, 10));

            Assert.Equal(new Cell(11,10), board.NextIteration().First());
        }

        [Fact]
        public void TestBirth()
        {
            var board = new Board();
            board.Cells.Add(new Cell(10, 10));
            board.Cells.Add(new Cell(11, 9));
            board.Cells.Add(new Cell(12, 10));

            // Should have a new cell (and a stable one)
            Assert.Contains(new Cell(11, 10), board.NextIteration());
        }
    }
}
