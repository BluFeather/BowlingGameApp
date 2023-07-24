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

        public static readonly DependencyProperty FrameViewModelProperty =
            DependencyProperty.Register(
                name: "Frame",
                propertyType: typeof(FrameViewModel),
                ownerType: typeof(FrameUserControl),
                typeMetadata: new FrameworkPropertyMetadata(typeof(FrameViewModel)));
    }
}
