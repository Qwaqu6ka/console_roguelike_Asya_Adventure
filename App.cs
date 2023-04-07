namespace Roguelike {
    
    using System.Text.Json;
    using Roguelike.Json;

    static class App {

        public static GameStatus gameStatus = GameStatus.InProcess;

        private static MutableLiveData<Screen> _activeScreen = new MutableLiveData<Screen>(Screen.Start);
        public static LiveData<Screen> activeScreen { 
            get { return _activeScreen; } 
        }

        public static Hero hero = null!;
        public static Properties properties = null!;
        public static MapScreen mapScreen = null!;
        public static StartScreen startScreen = null!;
        public static InventoryScreen inventoryScreen = null!;
        public static CombatScreen combatScreen = null!;
        public static EndScreen endScreen = null!;

        private const string SETTINGS_FILE = "properties.json";

        static void Main() {
            readSettings();
            restartGame();
            
            combatScreen.isPlayerLoose.observe((yes) => {
                if (yes) openLooseScreen();
            });

            ViewRouter viewRouter = new ViewRouter();
            KeyController keyController = new KeyController();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.CursorVisible = false;
            

            while (true) {
                viewRouter.draw();
                keyController.onKeyPressed(Console.ReadKey());
            }
        }

        public static void openMapScreen() {
            _activeScreen.data = Screen.Map;
        }

        public static void openInventoryScreen() {
            inventoryScreen.openedFrom = activeScreen.data;
            _activeScreen.data = Screen.Inventory;
        }

        public static void backToCombatScreen() {
            _activeScreen.data = Screen.Combat;
        }
        public static void openCombatScreen(Enemy enemy) {
            combatScreen.startFight(enemy);
            _activeScreen.data = Screen.Combat;
        }

        public static void openWinScreen() {
            gameStatus = GameStatus.Win;
            _activeScreen.data = Screen.End;
        }

        public static void openLooseScreen() {
            gameStatus = GameStatus.Lose;
            _activeScreen.data = Screen.End;
        }

        public static void restartGame() {
            hero = new Hero();
            gameStatus = GameStatus.InProcess;
            initScreens();
            _activeScreen.data = Screen.Start;
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
            combatScreen = new CombatScreen(mapScreen);
            endScreen = new EndScreen();
        }
    }

    enum Screen {
        Start,
        Map,
        Combat,
        Shop,
        Inventory,
        End
    }

    enum GameStatus {
        InProcess,
        Lose,
        Win
    }
}
