namespace BowlingGameApp.Model
{
    public static class BowlingGameInstance
    {
        static BowlingGameInstance()
        {
            GameInstance = new BowlingGame();
            GameInstance.ResetGame();
        }

        public static BowlingGame GameInstance { get; }
    }
}
