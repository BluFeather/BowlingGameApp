using BowlingGameApp.ViewModel;
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

        public FrameViewModel Frame
        {
            get => (FrameViewModel)GetValue(FrameViewModelProperty);
            set => SetValue(FrameViewModelProperty, value);
        }

        public string FrameNumber
        {
            get => Frame.FrameNumber;
        }

        public string RollOne
        {
            get => Frame.RollOne;
        }

        public string RollTwo
        {
            get => Frame.RollTwo;
        }

        public string RollThree
        {
            get => Frame.RollThree;
        }

        public string RunningScore
        {
            get => Frame.RunningScore;
        }

        public static readonly DependencyProperty FrameViewModelProperty =
            DependencyProperty.Register(
                name: "Frame",
                propertyType: typeof(FrameViewModel),
                ownerType: typeof(FrameUserControl),
                typeMetadata: new FrameworkPropertyMetadata(typeof(FrameViewModel)));
    }
}
