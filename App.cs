namespace Roguelike {
    static class App {

        // static bool isKeyboardAvailable = true;
        private static MutableLiveData<Screen> _activeScreen = new MutableLiveData<Screen>(Screen.Menu);
        public static LiveData<Screen> activeScreen {
            get {
                return _activeScreen;
            }
        }
        public static MapScreen mapScreen;

        static void Main() {
            Console.CursorVisible = false;

            mapScreen = new MapScreen();

            ViewRouter viewRouter = new ViewRouter();

            KeyController keyController = new KeyController(mapScreen);

            while(true) {
                Console.Clear();

                viewRouter.draw();

                keyController.onKeyPressed(Console.ReadKey());
            }
        }
    }

    enum Screen {
        Menu,
        Map,
        Combat,
        Shop,
        Inventory
    }
}
