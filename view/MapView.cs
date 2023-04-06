namespace Roguelike {

    class MapView : View {
        public int Length { get; }
        public int Height { get; }

        private MapScreen mapScreen;

        public MapView(MapScreen mapScreen) {
            this.mapScreen = mapScreen;
            Length = mapScreen.activeMap.map[0].Length;
            Height = mapScreen.activeMap.map.Count;
        }
        override public void draw() {
            Console.SetCursorPosition(0, 0);

            Map activeMap = mapScreen.activeMap;
            Coordinates playerCoords = mapScreen.playerCoords;

            int rows = activeMap.map.Count;
            int columns = activeMap.map[0].Length;

            for (int y = 0; y < rows; y++) {
                for (int x = 0; x < columns; x++) {
                    if (x == playerCoords.x && y == playerCoords.y)
                        Console.Write(App.properties.icons.hero);
                    else
                        Console.Write(activeMap.map[y][x]);
                }
                Console.WriteLine();
            }
        }
    }
}
