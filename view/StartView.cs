namespace Roguelike {
    class StartView : View {
        StartScreen startScreen;

        public StartView(StartScreen startScreen) {
            this.startScreen = startScreen;
        }
        override public void draw() {
            if (startScreen.state == StartScreen.StartScreens.Welcome) {
                Console.WriteLine("Welcome!");
            }
            else if (startScreen.state == StartScreen.StartScreens.Story) {
                Console.WriteLine("Story...");
            }
        }
    }
}