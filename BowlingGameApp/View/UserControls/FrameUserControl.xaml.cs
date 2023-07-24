using System.Windows;
using System.Windows.Controls;

namespace BowlingGameApp.View.UserControls
{
    public partial class FrameUserControl : UserControl
    {
        public FrameUserControl()
        {
            InitializeComponent();
        }

        public string FrameNumber
        {
            get => (string)GetValue(FrameNumberProperty);
            set => SetValue(FrameNumberProperty, value);
        }

        public string RollOne
        {
            get => (string)GetValue(RollOneProperty);
            set => SetValue(RollOneProperty, value);
        }

        public string RollTwo
        {
            get => (string)GetValue(RollTwoProperty);
            set => SetValue(RollTwoProperty, value);
        }

        public string OverallScore
        {
            get => (string)GetValue(OverallScoreProperty);
            set => SetValue(OverallScoreProperty, value);
        }

        private static readonly DependencyProperty FrameNumberProperty =
            DependencyProperty.Register(
                name: "FrameNumber",
                propertyType: typeof(string),
                ownerType: typeof(FrameUserControl),
                typeMetadata: new FrameworkPropertyMetadata(default(string)));

        private static readonly DependencyProperty RollOneProperty =
            DependencyProperty.Register(
                name: "RollOne",
                propertyType: typeof(string),
                ownerType: typeof(FrameUserControl),
                typeMetadata: new FrameworkPropertyMetadata(default(string)));

        private static readonly DependencyProperty RollTwoProperty =
            DependencyProperty.Register(
                name: "RollTwo",
                propertyType: typeof(string),
                ownerType: typeof(FrameUserControl),
                typeMetadata: new FrameworkPropertyMetadata(default(string)));

        private static readonly DependencyProperty OverallScoreProperty =
            DependencyProperty.Register(
                name: "OverallScore",
                propertyType: typeof(string),
                ownerType: typeof(FrameUserControl),
                typeMetadata: new FrameworkPropertyMetadata(default(string)));
    }
}
