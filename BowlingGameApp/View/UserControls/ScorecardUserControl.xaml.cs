using BowlingGameApp.ViewModel;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace BowlingGameApp.View.UserControls
{
    public partial class ScorecardUserControl : UserControl
    {
        public ScorecardUserControl()
        {
            InitializeComponent();
        }

        public List<FrameViewModel> Frames
        {
            get => (List<FrameViewModel>)GetValue(FramesProperty);
            set => SetValue(FramesProperty, value);
        }

        private static readonly DependencyProperty FramesProperty =
            DependencyProperty.Register(
                name: "Frames",
                propertyType: typeof(List<FrameViewModel>),
                ownerType: typeof(ScorecardUserControl),
                typeMetadata: new FrameworkPropertyMetadata(default(List<FrameViewModel>)));
    }
}
