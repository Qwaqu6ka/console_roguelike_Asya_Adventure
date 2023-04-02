namespace Roguelike {

    class Coordinates : ICloneable {
        public int x, y;

        public Coordinates(int x, int y) {
            this.x = x;
            this.y = y;
        }

        public object Clone() {
            return new Coordinates(this.x, this.y);
        }
    }

    class Map {

        public char[,] map;
        public Coordinates startCoords;
        public Coordinates finishCoords;

        public Map(char[,] map, Coordinates startCoords, Coordinates finishCoords) {
            this.map = map;
            this.startCoords = startCoords;
            this.finishCoords = finishCoords;
        }
    }

    class MapService {
        private Coordinates playerCoords = new Coordinates(0, 0);

        private char[] bag = new char[1];   // bag
        private Coordinates bagCoords = new Coordinates(0, 0);  // bag

        private int activeMapIndex = -1;

        public MapService() {
            getNextRandomMap();
        }

        public void drawMap() {

            Console.SetCursorPosition(0, 0);

            Map currentMap = maps[activeMapIndex];
            int rows = currentMap.map.GetUpperBound(0) + 1;
            int columns = currentMap.map.GetUpperBound(1) + 1;

            for (int y = 0; y < rows; y++) {
                for (int x = 0; x < columns; x++) {
                    if (x == playerCoords.x && y == playerCoords.y)
                        Console.Write('@');
                    else
                        Console.Write(currentMap.map[y, x]);
                }
                Console.WriteLine();
            }
        }

        public void drawBag() {
            Console.SetCursorPosition(bagCoords.x, bagCoords.y);
            Console.Write("Сумка: ");
            for (int i = 0; i < bag.Length; i++) {
                Console.Write(bag[i] + " ");
            }

            Console.WriteLine();
            Console.WriteLine(playerCoords.x);
            Console.WriteLine(playerCoords.y);
        }

        public void moveHero(ConsoleKeyInfo charKey) {
            char[,] map = maps[activeMapIndex].map;
            switch (charKey.Key) {
                case ConsoleKey.UpArrow:
                    if (map[playerCoords.y - 1, playerCoords.x] != '#') {
                        playerCoords.y--;
                    }
                    break;

                case ConsoleKey.DownArrow:
                    if (map[playerCoords.y + 1, playerCoords.x] != '#') {
                        playerCoords.y++;
                    }
                    break;

                case ConsoleKey.LeftArrow:
                    if (map[playerCoords.y, playerCoords.x - 1] != '#') {
                        playerCoords.x--;
                    }
                    break;

                case ConsoleKey.RightArrow:
                    if (map[playerCoords.y, playerCoords.x + 1] != '#') {
                        playerCoords.x++;
                    }
                    break;
            }

            checkCell();
        }

        private void checkCell() {
            char cell = maps[activeMapIndex].map[playerCoords.y, playerCoords.x];

            switch (cell) {
                case 'X':
                    addItemToBag(); // bag
                    break;
                
                case 'E':
                    getNextRandomMap();
                    break;
            }
        }

        private void addItemToBag() {   // bag
            char[,] map = maps[activeMapIndex].map;

            map[playerCoords.y, playerCoords.x] = 'o';
            char[] tempBag = new char[bag.Length + 1];
            for (int i = 0; i < bag.Length; i++) {
                tempBag[i] = bag[i];
            }
            tempBag[tempBag.Length - 1] = 'X';
            bag = tempBag;
        }

        private void getNextRandomMap() {
            int nextMapIndex;
            do {
                nextMapIndex = new System.Random().Next(maps.Length);
            } while (nextMapIndex == activeMapIndex);

            activeMapIndex = nextMapIndex;

            playerCoords = (Coordinates)maps[activeMapIndex].startCoords.Clone();

            bagCoords.y = maps[activeMapIndex].map.GetUpperBound(0) + 3;    // bag
        }

        private Map[] maps = {
            new Map(new char[,] {
                { '#','#','#','#','#','#','E','#','#','#','#','#','#','#','#','#','#'},
                { '#',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
                { '#',' ','#',' ','X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X','#'},
                { '#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
                { '#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
                { '#',' ',' ',' ',' ',' ',' ',' ','#','#','#',' ',' ',' ',' ',' ','#'},
                { '#',' ','#',' ',' ',' ',' ',' ','#','X','#',' ',' ',' ',' ',' ','#'},
                { '#',' ','#',' ',' ',' ',' ',' ','#',' ','#',' ',' ',' ',' ',' ','#'},
                { '#',' ','#',' ',' ',' ',' ',' ','#',' ','#',' ',' ',' ',' ',' ','#'},
                { '#',' ','#',' ',' ',' ',' ',' ','#',' ','#',' ',' ',' ',' ',' ','#'},
                { '#',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
                { '#',' ','#','#','#','#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
                { '#',' ',' ','X',' ','#',' ',' ',' ',' ',' ',' ',' ','X',' ',' ','#'},
                { '#',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
                { '#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#'}
                }, new Coordinates(13, 4), new Coordinates(6, 0)
            ),
            new Map(new char[,] {
                { '#','E','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#'},
                { '#',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
                { '#',' ','#',' ','X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X','#'},
                { '#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
                { '#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
                { '#',' ',' ',' ',' ',' ',' ',' ','#','#','#',' ',' ',' ',' ',' ','#'},
                { '#',' ',' ',' ',' ',' ',' ',' ',' ','X',' ',' ',' ',' ',' ',' ','#'},
                { '#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
                { '#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
                { '#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
                { '#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
                { '#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
                { '#',' ',' ','X',' ','#',' ',' ',' ',' ',' ',' ',' ','X',' ',' ','#'},
                { '#',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
                { '#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#'}
                }, new Coordinates(15, 1), new Coordinates(1, 0)
            ),
            // Чтобы добавить новые карты, нужно скопировать верхнюю конструкцию и вставить вместо этого комментария
            //  Две цифры в конце - стартовые координаты конкретно на этой карте
        };
    }
}