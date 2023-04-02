namespace Roguelike {
    class Program {
        static void Main(string[] args) {
            Console.CursorVisible = false;
            MapService mapService = new MapService();

            while(true) {
                Console.Clear();

                mapService.drawMap();
                mapService.drawBag();

                ConsoleKeyInfo charKey = Console.ReadKey();
                mapService.moveHero(charKey);
            }
        }
    }
}
