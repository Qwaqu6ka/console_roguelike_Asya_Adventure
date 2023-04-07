namespace Roguelike {

    class EndView : View {
        List<string> victoryScreen = App.properties.screens.gameVictory;
        List<string> defeatScreen = App.properties.screens.gameDefeat;

        override public void draw() {

            List<string> screenToShow;

            if (App.gameStatus == GameStatus.Win) {
                screenToShow = victoryScreen;
            } else if (App.gameStatus == GameStatus.Lose) {
                screenToShow = defeatScreen;
            } else {
                throw new InvalidOperationException("ScreenToShow must has value");
            }

            for (int y = 0; y < screenToShow.Count; y++) {
                for (int x = 0; x < screenToShow[0].Length; x++) {
                    Console.Write(screenToShow[y][x]);
                }
                Console.WriteLine();
            }
        }
    }
}