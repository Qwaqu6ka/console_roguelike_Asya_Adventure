namespace Roguelike {

    class MapView : View {

        private MapService mapService;

        public MapView(MapService mapService) {
            this.mapService = mapService;
        }
        override public void draw() {
            Console.SetCursorPosition(0, 0);

            Map activeMap = mapService.activeMap;
            Coordinates playerCoords = mapService.playerCoords;
            
            int rows = activeMap.map.GetUpperBound(0) + 1;
            int columns = activeMap.map.GetUpperBound(1) + 1;

            for (int y = 0; y < rows; y++) {
                for (int x = 0; x < columns; x++) {
                    if (x == playerCoords.x && y == playerCoords.y)
                        Console.Write('@');
                    else
                        Console.Write(activeMap.map[y, x]);
                }
                Console.WriteLine();
            }
        }
    }
}