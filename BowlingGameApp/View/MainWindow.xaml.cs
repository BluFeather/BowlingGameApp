using System.Windows;

namespace BowlingGameApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            RollButtons.ScoreReceived += OnScoreReceived;
        }

        private void OnScoreReceived(object? sender, int value)
        {
            
        }
    }
}
