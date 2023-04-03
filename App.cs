namespace Roguelike {
    static class App {

        // static bool isKeyboardAvailable = true;
        private static MutableLiveData<Screen> _activeScreen = new MutableLiveData<Screen>(Screen.Menu);
        public static LiveData<Screen> activeScreen {
            get {
                return _activeScreen;
            }
        }
        public static MapService mapService = new MapService();


        static void Main(string[] args) {
            Console.CursorVisible = false;

            KeyController keyController = new KeyController(mapService);

            while(true) {
                Console.Clear();

                mapService.drawMap();   // TODO: убрать, сделать class View

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
