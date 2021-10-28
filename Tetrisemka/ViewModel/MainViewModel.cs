using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace Tetrisemka.ViewModel
{
    
    public class MainViewModel : ViewModelBase
    {
        private ICommand _startCommand;
        public ICommand StartCommand 
        { 
            get
            {
                return _startCommand;
            }
            set
            {
                _startCommand = value;
                RaisePropertyChanged(nameof(StartCommand));
            }
        }

        public void Start()
        {
            if (timer.IsEnabled)
            {
                timer.Stop();
            }
            else 
            {
                timer.Start();
            }           

        }

        private string _testText;
        public string TestText 
        {
            get => _testText;
            set
            {
                _testText = value;
                RaisePropertyChanged(nameof(TestText));
            }
        }

        public GameField _gameField;
        private WriteableBitmap _gameBoard;
        public WriteableBitmap GameBoard
        {
            get => _gameBoard;
            set
            {
                _gameBoard = value;
                RaisePropertyChanged(nameof(GameBoard));
            }
        }
        private DispatcherTimer timer = new DispatcherTimer();
        private int i = 0;
        public int y = 0;
        public MainViewModel()
        {
            Block.GenerateBlocks();
            _gameField = new GameField();
            _gameField.Create();
            StartCommand = new RelayCommand(Start);
            timer = new DispatcherTimer(DispatcherPriority.Render);
            timer.Tick += new EventHandler(TimerTick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 500);
            timer.Start();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            GameBoard = _gameField.Calc();
            TestText = i.ToString();
            i++;
        }
    }
}