using BowlingGameApp.Model;
using BowlingGameApp.ViewModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;

namespace BowlingGameApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Game = BowlingGameInstance.GameInstance;
            RollSparesGame();
        }

        private BowlingGame Game { get; }

        public List<Frame> Frames
        {
            get => Game.Frames;
        }

        private void RollSparesGame()
        {
            for (int roll = 0; roll < 21; roll++)
            {
                Game.AddRoll(5);
            }
        }
    }
}
