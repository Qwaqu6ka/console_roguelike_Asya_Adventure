namespace Roguelike {
    static class App {

        // static bool isKeyboardAvailable = true;
        private static MutableLiveData<Screen> _activeScreen = new MutableLiveData<Screen>(Screen.Menu);
        public static LiveData<Screen> activeScreen {
            get {
                return _activeScreen;
            }
        }
        public static MapService mapService;

        static void Main() {
            Console.CursorVisible = false;

            mapService = new MapService();

            ViewRouter viewRouter = new ViewRouter();

            KeyController keyController = new KeyController(mapService);

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
