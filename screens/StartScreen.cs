namespace Roguelike {
    class StartScreen : IKeyController {

        public ScreenType state = ScreenType.Welcome;

        public void onKeyPressed(ConsoleKeyInfo charKey) {
            if ((charKey.Key == ConsoleKey.Spacebar) && (state != ScreenType.Story)) {
                state = ScreenType.Story;
            } else if ((charKey.Key == ConsoleKey.Spacebar) && (state == ScreenType.Story)) {
                App.openMapScreen();
            }
        }

        public enum ScreenType {
            Welcome,
            Story
        }
    }
}
