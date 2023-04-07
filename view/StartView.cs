namespace Roguelike {
    class StartView : View {
        StartScreen startScreen;
        List<string> welcomeScreen = App.properties.screens.welcome;
        List<string> storyScreen = App.properties.screens.story;
        List<string> instructionsScreen = App.properties.screens.instructions;

        public StartView(StartScreen startScreen) {
            this.startScreen = startScreen;
        }
        override public void draw() {

            List<string> screenToShow;

            if (startScreen.state == StartScreen.ScreenType.Welcome) {
                screenToShow = welcomeScreen;
            }
            else if (startScreen.state == StartScreen.ScreenType.Story) {
                screenToShow = storyScreen;
            }
            else if (startScreen.state == StartScreen.ScreenType.Instructions) {
                screenToShow = instructionsScreen;
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