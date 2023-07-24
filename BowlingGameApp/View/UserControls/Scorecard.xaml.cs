using System.Windows;
using System.Windows.Controls;

namespace BowlingGameApp.View.UserControls
{
    public partial class Scorecard : UserControl
    {
        public Scorecard()
        {
            InitializeComponent();
        }

        public string RollOne
        {
            get { return (string)GetValue(RollOneProperty); }
            set { SetValue(RollOneProperty, value); }
        }

        public static readonly DependencyProperty RollOneProperty =
            DependencyProperty.Register("RollOne", typeof(string), typeof(Scorecard), new PropertyMetadata(default(string)));



        public string RollTwo
        {
            get { return (string)GetValue(RollTwoProperty); }
            set { SetValue(RollTwoProperty, value); }
        }

        public static readonly DependencyProperty RollTwoProperty =
            DependencyProperty.Register("RollTwo", typeof(string), typeof(Scorecard), new PropertyMetadata(default(string)));



        public string RollThree
        {
            get { return (string)GetValue(RollThreeProperty); }
            set { SetValue(RollThreeProperty, value); }
        }

        public static readonly DependencyProperty RollThreeProperty =
            DependencyProperty.Register("RollThree", typeof(string), typeof(Scorecard), new PropertyMetadata(default(string)));



        public string RollFour
        {
            get { return (string)GetValue(RollFourProperty); }
            set { SetValue(RollFourProperty, value); }
        }

        public static readonly DependencyProperty RollFourProperty =
            DependencyProperty.Register("RollFour", typeof(string), typeof(Scorecard), new PropertyMetadata(default(string)));



        public string RollFive
        {
            get { return (string)GetValue(RollFiveProperty); }
            set { SetValue(RollFiveProperty, value); }
        }

        public static readonly DependencyProperty RollFiveProperty =
            DependencyProperty.Register("RollFive", typeof(string), typeof(Scorecard), new PropertyMetadata(default(string)));



        public string RollSix
        {
            get { return (string)GetValue(RollSixProperty); }
            set { SetValue(RollSixProperty, value); }
        }

        public static readonly DependencyProperty RollSixProperty =
            DependencyProperty.Register("RollSix", typeof(string), typeof(Scorecard), new PropertyMetadata(default(string)));



        public string RollSeven
        {
            get { return (string)GetValue(RollSevenProperty); }
            set { SetValue(RollSevenProperty, value); }
        }

        public static readonly DependencyProperty RollSevenProperty =
            DependencyProperty.Register("RollSeven", typeof(string), typeof(Scorecard), new PropertyMetadata(default(string)));



        public string RollEight
        {
            get { return (string)GetValue(RollEightProperty); }
            set { SetValue(RollEightProperty, value); }
        }

        public static readonly DependencyProperty RollEightProperty =
            DependencyProperty.Register("RollEight", typeof(string), typeof(Scorecard), new PropertyMetadata(default(string)));



        public string RollNine
        {
            get { return (string)GetValue(RollNineProperty); }
            set { SetValue(RollNineProperty, value); }
        }

        public static readonly DependencyProperty RollNineProperty =
            DependencyProperty.Register("RollNine", typeof(string), typeof(Scorecard), new PropertyMetadata(default(string)));



        public string RollTen
        {
            get { return (string)GetValue(RollTenProperty); }
            set { SetValue(RollTenProperty, value); }
        }

        public static readonly DependencyProperty RollTenProperty =
            DependencyProperty.Register("RollTen", typeof(string), typeof(Scorecard), new PropertyMetadata(default(string)));



        public string RollEleven
        {
            get { return (string)GetValue(RollElevenProperty); }
            set { SetValue(RollElevenProperty, value); }
        }

        public static readonly DependencyProperty RollElevenProperty =
            DependencyProperty.Register("RollEleven", typeof(string), typeof(Scorecard), new PropertyMetadata(default(string)));



        public string RollTwelve
        {
            get { return (string)GetValue(RollTwelveProperty); }
            set { SetValue(RollTwelveProperty, value); }
        }

        public static readonly DependencyProperty RollTwelveProperty =
            DependencyProperty.Register("RollTwelve", typeof(string), typeof(Scorecard), new PropertyMetadata(default(string)));



        public string RollThirteen
        {
            get { return (string)GetValue(RollThirteenProperty); }
            set { SetValue(RollThirteenProperty, value); }
        }

        public static readonly DependencyProperty RollThirteenProperty =
            DependencyProperty.Register("RollThirteen", typeof(string), typeof(Scorecard), new PropertyMetadata(default(string)));



        public string RollFourteen
        {
            get { return (string)GetValue(RollFourteenProperty); }
            set { SetValue(RollFourteenProperty, value); }
        }

        public static readonly DependencyProperty RollFourteenProperty =
            DependencyProperty.Register("RollFourteen", typeof(string), typeof(Scorecard), new PropertyMetadata(default(string)));



        public string RollFifteen
        {
            get { return (string)GetValue(RollFifteenProperty); }
            set { SetValue(RollFifteenProperty, value); }
        }

        public static readonly DependencyProperty RollFifteenProperty =
            DependencyProperty.Register("RollFifteen", typeof(string), typeof(Scorecard), new PropertyMetadata(default(string)));



        public string RollSixteen
        {
            get { return (string)GetValue(RollSixteenProperty); }
            set { SetValue(RollSixteenProperty, value); }
        }

        public static readonly DependencyProperty RollSixteenProperty =
            DependencyProperty.Register("RollSixteen", typeof(string), typeof(Scorecard), new PropertyMetadata(default(string)));



        public string RollSeventeen
        {
            get { return (string)GetValue(RollSeventeenProperty); }
            set { SetValue(RollSeventeenProperty, value); }
        }

        public static readonly DependencyProperty RollSeventeenProperty =
            DependencyProperty.Register("RollSeventeen", typeof(string), typeof(Scorecard), new PropertyMetadata(default(string)));



        public string RollEighteen
        {
            get { return (string)GetValue(RollEighteenProperty); }
            set { SetValue(RollEighteenProperty, value); }
        }

        public static readonly DependencyProperty RollEighteenProperty =
            DependencyProperty.Register("RollEighteen", typeof(string), typeof(Scorecard), new PropertyMetadata(default(string)));



        public string RollNineteen
        {
            get { return (string)GetValue(RollNineteenProperty); }
            set { SetValue(RollNineteenProperty, value); }
        }

        public static readonly DependencyProperty RollNineteenProperty =
            DependencyProperty.Register("RollNineteen", typeof(string), typeof(Scorecard), new PropertyMetadata(default(string)));



        public string RollTwenty
        {
            get { return (string)GetValue(RollTwentyProperty); }
            set { SetValue(RollTwentyProperty, value); }
        }

        public static readonly DependencyProperty RollTwentyProperty =
            DependencyProperty.Register("RollTwenty", typeof(string), typeof(Scorecard), new PropertyMetadata(default(string)));



        public string RollTwentyOne
        {
            get { return (string)GetValue(RollTwentyOneProperty); }
            set { SetValue(RollTwentyOneProperty, value); }
        }

        public static readonly DependencyProperty RollTwentyOneProperty =
            DependencyProperty.Register("RollTwentyOne", typeof(string), typeof(Scorecard), new PropertyMetadata(default(string)));



        public string FrameOneRunningValue
        {
            get { return (string)GetValue(FrameOneRunningValueProperty); }
            set { SetValue(FrameOneRunningValueProperty, value); }
        }

        public static readonly DependencyProperty FrameOneRunningValueProperty =
            DependencyProperty.Register("FrameOneRunningValue", typeof(string), typeof(Scorecard), new PropertyMetadata(default(string)));



        public string FrameTwoRunningValue
        {
            get { return (string)GetValue(FrameTwoRunningValueProperty); }
            set { SetValue(FrameTwoRunningValueProperty, value); }
        }

        public static readonly DependencyProperty FrameTwoRunningValueProperty =
            DependencyProperty.Register("FrameTwoRunningValue", typeof(string), typeof(Scorecard), new PropertyMetadata(default(string)));



        public string FrameThreeRunningValue
        {
            get { return (string)GetValue(FrameThreeRunningValueProperty); }
            set { SetValue(FrameThreeRunningValueProperty, value); }
        }

        public static readonly DependencyProperty FrameThreeRunningValueProperty =
            DependencyProperty.Register("FrameThreeRunningValue", typeof(string), typeof(Scorecard), new PropertyMetadata(default(string)));



        public string FrameFourRunningValue
        {
            get { return (string)GetValue(FrameFourRunningValueProperty); }
            set { SetValue(FrameFourRunningValueProperty, value); }
        }

        public static readonly DependencyProperty FrameFourRunningValueProperty =
            DependencyProperty.Register("FrameFourRunningValue", typeof(string), typeof(Scorecard), new PropertyMetadata(default(string)));



        public string FrameFiveRunningValue
        {
            get { return (string)GetValue(FrameFiveRunningValueProperty); }
            set { SetValue(FrameFiveRunningValueProperty, value); }
        }

        public static readonly DependencyProperty FrameFiveRunningValueProperty =
            DependencyProperty.Register("FrameFiveRunningValue", typeof(string), typeof(Scorecard), new PropertyMetadata(default(string)));



        public string FrameSixRunningValue
        {
            get { return (string)GetValue(FrameSixRunningValueProperty); }
            set { SetValue(FrameSixRunningValueProperty, value); }
        }

        public static readonly DependencyProperty FrameSixRunningValueProperty =
            DependencyProperty.Register("FrameSixRunningValue", typeof(string), typeof(Scorecard), new PropertyMetadata(default(string)));



        public string FrameSevenRunningValue
        {
            get { return (string)GetValue(FrameSevenRunningValueProperty); }
            set { SetValue(FrameSevenRunningValueProperty, value); }
        }

        public static readonly DependencyProperty FrameSevenRunningValueProperty =
            DependencyProperty.Register("FrameSevenRunningValue", typeof(string), typeof(Scorecard), new PropertyMetadata(default(string)));



        public string FrameEightRunningValue
        {
            get { return (string)GetValue(FrameEightRunningValueProperty); }
            set { SetValue(FrameEightRunningValueProperty, value); }
        }

        public static readonly DependencyProperty FrameEightRunningValueProperty =
            DependencyProperty.Register("FrameEightRunningValue", typeof(string), typeof(Scorecard), new PropertyMetadata(default(string)));



        public string FrameNineRunningValue
        {
            get { return (string)GetValue(FrameNineRunningValueProperty); }
            set { SetValue(FrameNineRunningValueProperty, value); }
        }

        public static readonly DependencyProperty FrameNineRunningValueProperty =
            DependencyProperty.Register("FrameNineRunningValue", typeof(string), typeof(Scorecard), new PropertyMetadata(default(string)));



        public string FrameTenRunningValue
        {
            get { return (string)GetValue(FrameTenRunningValueProperty); }
            set { SetValue(FrameTenRunningValueProperty, value); }
        }

        public static readonly DependencyProperty FrameTenRunningValueProperty =
            DependencyProperty.Register("FrameTenRunningValue", typeof(string), typeof(Scorecard), new PropertyMetadata(default(string)));
    }
}
