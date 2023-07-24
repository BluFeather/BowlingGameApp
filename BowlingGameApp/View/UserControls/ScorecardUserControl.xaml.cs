using BowlingGameApp.ViewModel;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Frame = BowlingGameApp.Model.Frame;

namespace BowlingGameApp.View.UserControls
{
    public partial class ScorecardUserControl : UserControl
    {
        public ScorecardUserControl()
        {
            InitializeComponent();
        }

        public List<Frame> Frames
        {
            get => (List<Frame>)GetValue(FramesProperty);
            set => SetValue(FramesProperty, value);
        }

        private static readonly DependencyProperty FramesProperty =
            DependencyProperty.Register(
                name: "Frames",
                propertyType: typeof(List<Frame>),
                ownerType: typeof(ScorecardUserControl),
                typeMetadata: new FrameworkPropertyMetadata(default(List<Frame>)));
    }
}
