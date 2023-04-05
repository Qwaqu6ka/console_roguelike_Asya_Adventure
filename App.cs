namespace Roguelike {
    static class App {

        // static bool isKeyboardAvailable = true;
        private static MutableLiveData<Screen> _activeScreen = new MutableLiveData<Screen>(Screen.Start);
        public static LiveData<Screen> activeScreen {
            get {
                return _activeScreen;
            }
        }
        public static MapScreen mapScreen = null!;
        public static StartScreen startScreen = null!;

        static void Main() {
            Console.CursorVisible = false;

            mapScreen = new MapScreen();
            startScreen = new StartScreen();

            ViewRouter viewRouter = new ViewRouter();

            KeyController keyController = new KeyController();

            while (true) {
                Console.Clear();

                viewRouter.draw();

                keyController.onKeyPressed(Console.ReadKey());
            }
        }

        public static void openMapScreen() {
            _activeScreen.data = Screen.Map;
        }
    }

    enum Screen {
        Start,
        Map,
        Combat,
        Shop,
        Inventory
    }
}
