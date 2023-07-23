namespace BowlingGameApp.Model
{
    public static class BowlingGameInstance
    {
        static BowlingGameInstance()
        {
            GameInstance = new BowlingGame();
            GameInstance.NewGame();
        }

        public static BowlingGame GameInstance { get; }
    }
}
