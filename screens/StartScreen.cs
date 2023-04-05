namespace Roguelike {
    class StartScreen : IKeyController {

        public StartScreens state = StartScreens.Welcome;

        public void onKeyPressed(ConsoleKeyInfo charKey) {
            if ((charKey.Key == ConsoleKey.Spacebar) && (state != StartScreens.Story)) {
                state = StartScreens.Story;
            } else if ((charKey.Key == ConsoleKey.Spacebar) && (state == StartScreens.Story)) {
                App.openMapScreen();
            }
        }

        public enum StartScreens {
            Welcome,
            Story
        }
    }
}
