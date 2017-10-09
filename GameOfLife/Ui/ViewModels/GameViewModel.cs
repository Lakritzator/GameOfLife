using System;
using System.ComponentModel.Composition;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Caliburn.Micro;
using Dapplo.CaliburnMicro;
using GameOfLife.Board;

namespace GameOfLife.Ui.ViewModels
{
    [Export(typeof(IShell))]
    public class GameViewModel : Screen, IShell, IMaintainPosition
    {
        private BitmapSource _gameBitmap;
        private GameBoard _gameBoard;
        private readonly DispatcherTimer _timer = new DispatcherTimer();

        public BitmapSource GameBitmap
        {
            get => _gameBitmap;
            set
            {
                _gameBitmap = value;
                NotifyOfPropertyChange();
            }
        }

        protected override void OnActivate()
        {
            base.OnActivate();
            _gameBoard = new GameBoard
            {
                Height = 50,
                Width = 50
            };

            var acorn = new Cells
            {
                {11, 8},
                {13, 9},
                {10, 10},
                {11, 10},
                {14, 10},
                {15, 10},
                {16, 10}
            };
            _gameBoard.SetBoardContent(acorn);

            _timer.Interval = TimeSpan.FromMilliseconds(100);
            _timer.Tick += Update;
            _timer.Start();
            GameBitmap = Draw();
        }

        private void Update(object sender, EventArgs eventArgs)
        {
            Play();
            GameBitmap = Draw();
        }
        /// <summary>
        /// Draw the GameBoard to a writable Bitmap
        /// </summary>
        /// <returns>BitmapSource</returns>
        private BitmapSource Draw()
        {
            var writeableBitmap = BitmapFactory.New(_gameBoard.Width, _gameBoard.Height);
            using (writeableBitmap.GetBitmapContext())
            {
                foreach (var cell in _gameBoard.Cells)
                {
                    writeableBitmap.SetPixel(cell.X, cell.Y, Colors.Red);
                }
            }
            return writeableBitmap;
        }

        /// <summary>
        /// Move the board to the next iteration
        /// </summary>
        private void Play()
        {
            var newIteration = _gameBoard.NextIteration();
            _gameBoard.SetBoardContent(newIteration);
        }
    }
}
