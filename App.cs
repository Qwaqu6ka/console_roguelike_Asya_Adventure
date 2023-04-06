namespace Roguelike {
    
    using System.Text.Json;
    using Roguelike.Json;

    static class App {

        private static MutableLiveData<Screen> _activeScreen = new MutableLiveData<Screen>(Screen.Start);
        public static LiveData<Screen> activeScreen {
            get {
                return _activeScreen;
            }
        }

        public static Properties properties = null!;
        public static MapScreen mapScreen = null!;
        public static StartScreen startScreen = null!;
        public static InventoryScreen inventoryScreen = null!;

        private const string SETTINGS_FILE = "123.json";

        static void Main() {
            readSettings();
            initScreens();

            ViewRouter viewRouter = new ViewRouter();
            KeyController keyController = new KeyController();

            Console.CursorVisible = false;

            while (true) {
                Console.Clear();

                viewRouter.draw();

                keyController.onKeyPressed(Console.ReadKey());
            }
        }

        public static void openMapScreen() {
            _activeScreen.data = Screen.Map;
        }

        public static void openInventoryScreen() {
            _activeScreen.data = Screen.Inventory;
        }

        private static void readSettings() {
            using (StreamReader r = new StreamReader(SETTINGS_FILE)) {
                string json = r.ReadToEnd();
                properties = JsonSerializer.Deserialize<Properties>(json) ?? 
                    throw new JsonException("Unable deserealize Json");
            }
        }

        private static void initScreens() {
            mapScreen = new MapScreen();
            startScreen = new StartScreen();
            inventoryScreen = new InventoryScreen();
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
