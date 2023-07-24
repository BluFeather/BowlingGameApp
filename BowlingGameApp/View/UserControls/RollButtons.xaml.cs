using System;
using System.Diagnostics;
using System.Windows.Controls;

namespace BowlingGameApp.View.UserControls
{
    public partial class RollButtons : UserControl
    {
        public RollButtons()
        {
            InitializeComponent();
        }

        public event EventHandler<int> ScoreReceived;

        protected virtual void OnScoreReceived(int value)
        {
            ScoreReceived?.Invoke(this, value);
        }

        private void ZeroButton_OnClick(object sender, System.Windows.RoutedEventArgs e) => OnScoreReceived(0);
        private void OneButton_OnClick(object sender, System.Windows.RoutedEventArgs e) => OnScoreReceived(1);
        private void TwoButton_OnClick(object sender, System.Windows.RoutedEventArgs e) => OnScoreReceived(2);
        private void ThreeButton_OnClick(object sender, System.Windows.RoutedEventArgs e) => OnScoreReceived(3);
        private void FourButton_OnClick(object sender, System.Windows.RoutedEventArgs e) => OnScoreReceived(4);
        private void FiveButton_OnClick(object sender, System.Windows.RoutedEventArgs e) => OnScoreReceived(5);
        private void SixButton_OnClick(object sender, System.Windows.RoutedEventArgs e) => OnScoreReceived(6);
        private void SevenButton_OnClick(object sender, System.Windows.RoutedEventArgs e) => OnScoreReceived(7);
        private void EightButton_OnClick(object sender, System.Windows.RoutedEventArgs e) => OnScoreReceived(8);
        private void NineButton_OnClick(object sender, System.Windows.RoutedEventArgs e) => OnScoreReceived(9);
        private void TenButton_OnClick(object sender, System.Windows.RoutedEventArgs e) => OnScoreReceived(10);
    }
}
