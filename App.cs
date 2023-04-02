namespace Roguelike {
    static class App {

        // static bool isKeyboardAvailable = true;
        public static Screen activeScreen = Screen.Menu;
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
