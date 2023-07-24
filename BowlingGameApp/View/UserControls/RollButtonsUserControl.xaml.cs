using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace BowlingGameApp.View.UserControls
{
    public partial class RollButtonsUserControl : UserControl
    {
        public RollButtonsUserControl()
        {
            InitializeComponent();
        }

        public event EventHandler<int>? ScoreReceived;

        protected virtual void OnScoreReceived(int value)
        {
            ScoreReceived?.Invoke(this, value);
        }

        public void SetMaxEnabledButton(int highestNumberEnabled)
        {
            List<bool> isEnabledList = new();
            for (int index = 0; index < 11; index++)
            {
                isEnabledList.Add(index <= highestNumberEnabled);
            }

            ButtonZeroIsEnabled = isEnabledList[0];
            ButtonOneIsEnabled = isEnabledList[1];
            ButtonTwoIsEnabled = isEnabledList[2];
            ButtonThreeIsEnabled = isEnabledList[3];
            ButtonFourIsEnabled = isEnabledList[4];
            ButtonFiveIsEnabled = isEnabledList[5];
            ButtonSixIsEnabled = isEnabledList[6];
            ButtonSevenIsEnabled = isEnabledList[7];
            ButtonEightIsEnabled = isEnabledList[8];
            ButtonNineIsEnabled = isEnabledList[9];
            ButtonTenIsEnabled = isEnabledList[10];
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


        public bool ButtonZeroIsEnabled
        {
            get { return (bool)GetValue(ButtonZeroIsEnabledProperty); }
            set { SetValue(ButtonZeroIsEnabledProperty, value); }
        }

        public static readonly DependencyProperty ButtonZeroIsEnabledProperty =
            DependencyProperty.Register("ButtonZeroIsEnabled", typeof(bool), typeof(RollButtonsUserControl), new PropertyMetadata(default(bool)));



        public bool ButtonOneIsEnabled
        {
            get { return (bool)GetValue(ButtonOneIsEnabledProperty); }
            set { SetValue(ButtonOneIsEnabledProperty, value); }
        }

        public static readonly DependencyProperty ButtonOneIsEnabledProperty =
            DependencyProperty.Register("ButtonOneIsEnabled", typeof(bool), typeof(RollButtonsUserControl), new PropertyMetadata(default(bool)));



        public bool ButtonTwoIsEnabled
        {
            get { return (bool)GetValue(ButtonTwoIsEnabledProperty); }
            set { SetValue(ButtonTwoIsEnabledProperty, value); }
        }

        public static readonly DependencyProperty ButtonTwoIsEnabledProperty =
            DependencyProperty.Register("ButtonTwoIsEnabled", typeof(bool), typeof(RollButtonsUserControl), new PropertyMetadata(default(bool)));



        public bool ButtonThreeIsEnabled
        {
            get { return (bool)GetValue(ButtonThreeIsEnabledProperty); }
            set { SetValue(ButtonThreeIsEnabledProperty, value); }
        }

        public static readonly DependencyProperty ButtonThreeIsEnabledProperty =
            DependencyProperty.Register("ButtonThreeIsEnabled", typeof(bool), typeof(RollButtonsUserControl), new PropertyMetadata(default(bool)));



        public bool ButtonFourIsEnabled
        {
            get { return (bool)GetValue(ButtonFourIsEnabledProperty); }
            set { SetValue(ButtonFourIsEnabledProperty, value); }
        }

        public static readonly DependencyProperty ButtonFourIsEnabledProperty =
            DependencyProperty.Register("ButtonFourIsEnabled", typeof(bool), typeof(RollButtonsUserControl), new PropertyMetadata(default(bool)));



        public bool ButtonFiveIsEnabled
        {
            get { return (bool)GetValue(ButtonFiveIsEnabledProperty); }
            set { SetValue(ButtonFiveIsEnabledProperty, value); }
        }

        public static readonly DependencyProperty ButtonFiveIsEnabledProperty =
            DependencyProperty.Register("ButtonFiveIsEnabled", typeof(bool), typeof(RollButtonsUserControl), new PropertyMetadata(default(bool)));



        public bool ButtonSixIsEnabled
        {
            get { return (bool)GetValue(ButtonSixIsEnabledProperty); }
            set { SetValue(ButtonSixIsEnabledProperty, value); }
        }

        public static readonly DependencyProperty ButtonSixIsEnabledProperty =
            DependencyProperty.Register("ButtonSixIsEnabled", typeof(bool), typeof(RollButtonsUserControl), new PropertyMetadata(default(bool)));



        public bool ButtonSevenIsEnabled
        {
            get { return (bool)GetValue(ButtonSevenIsEnabledProperty); }
            set { SetValue(ButtonSevenIsEnabledProperty, value); }
        }

        public static readonly DependencyProperty ButtonSevenIsEnabledProperty =
            DependencyProperty.Register("ButtonSevenIsEnabled", typeof(bool), typeof(RollButtonsUserControl), new PropertyMetadata(default(bool)));



        public bool ButtonEightIsEnabled
        {
            get { return (bool)GetValue(ButtonEightIsEnabledProperty); }
            set { SetValue(ButtonEightIsEnabledProperty, value); }
        }

        public static readonly DependencyProperty ButtonEightIsEnabledProperty =
            DependencyProperty.Register("ButtonEightIsEnabled", typeof(bool), typeof(RollButtonsUserControl), new PropertyMetadata(default(bool)));



        public bool ButtonNineIsEnabled
        {
            get { return (bool)GetValue(ButtonNineIsEnabledProperty); }
            set { SetValue(ButtonNineIsEnabledProperty, value); }
        }

        public static readonly DependencyProperty ButtonNineIsEnabledProperty =
            DependencyProperty.Register("ButtonNineIsEnabled", typeof(bool), typeof(RollButtonsUserControl), new PropertyMetadata(default(bool)));



        public bool ButtonTenIsEnabled
        {
            get { return (bool)GetValue(ButtonTenIsEnabledProperty); }
            set { SetValue(ButtonTenIsEnabledProperty, value); }
        }

        public static readonly DependencyProperty ButtonTenIsEnabledProperty =
            DependencyProperty.Register("ButtonTenIsEnabled", typeof(bool), typeof(RollButtonsUserControl), new PropertyMetadata(default(bool)));
    }
}
