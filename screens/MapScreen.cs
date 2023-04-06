namespace Roguelike {

    // TODO: добаить считывание карт с файла
    class MapScreen : IKeyController { // Todo: перенести логику сумки в другой класс
        private MutableLiveData<bool> _isItemNear = new MutableLiveData<bool>(false);
        public LiveData<bool> isItemNear {
            get {
                return _isItemNear;
            }
        }

        private MutableLiveData<bool> _isEnemyNear = new MutableLiveData<bool>(false);
        public LiveData<bool> isEnemyNear {
            get {
                return _isEnemyNear;
            }
        }

        private Coordinates _playerCoords = null!;
        public Coordinates playerCoords {
            get { return _playerCoords; }
        }


        // private char[] bag = new char[1];   // bag
        // private Coordinates bagCoords = new Coordinates(0, 0);  // bag

        private Map _activeMap = null!;
        public Map activeMap {
            get { return _activeMap; }
        }

        public MapScreen() {
            getNextRandomMap();
        }

        // public void drawBag() {
        //     Console.SetCursorPosition(bagCoords.x, bagCoords.y);
        //     Console.Write("Сумка: ");
        //     for (int i = 0; i < bag.Length; i++) {
        //         Console.Write(bag[i] + " ");
        //     }

        //     Console.WriteLine();
        //     Console.WriteLine(playerCoords.x);
        //     Console.WriteLine(playerCoords.y);
        // }

        public void onKeyPressed(ConsoleKeyInfo charKey) {
            char[,] map = activeMap.map;
            switch (charKey.Key) {
                case ConsoleKey.UpArrow:
                    if (map[playerCoords.y - 1, playerCoords.x] != '#') {
                        _playerCoords.y--;
                    }
                    break;

                case ConsoleKey.DownArrow:
                    if (map[playerCoords.y + 1, playerCoords.x] != '#') {
                        _playerCoords.y++;
                    }
                    break;

                case ConsoleKey.LeftArrow:
                    if (map[playerCoords.y, playerCoords.x - 1] != '#') {
                        _playerCoords.x--;
                    }
                    break;

                case ConsoleKey.RightArrow:
                    if (map[playerCoords.y, playerCoords.x + 1] != '#') {
                        _playerCoords.x++;
                    }
                    break;
                
                case ConsoleKey.I:
                    App.openInventoryScreen();
                    break;

                
            }
            changeState();
        }

        private void changeState() {
            char cell = activeMap.map[playerCoords.y, playerCoords.x];

            switch (cell) {
                // case 'X':
                //     addItemToBag(); // bag
                //     break;
                
                case 'E':
                    getNextRandomMap();
                    break;
            }

            _isItemNear.data = checkNearbyCells(playerCoords, '$');
            _isEnemyNear.data = checkNearbyCells(playerCoords, 'Ü');
        }

        // Проверяет клетку и окрестности на наличие какой-либо сущности
        private bool checkNearbyCells(Coordinates cell, char entity) {
            int x = cell.x, y = cell.y;
            char[,] map = activeMap.map;

            if (map[y, x] == entity ||
                y > 0 && map[y - 1, x] == entity ||
                y < map.GetUpperBound(0) && map[y + 1, x] == entity ||
                x > 0 && map[y, x - 1] == entity ||
                x < map.GetUpperBound(1) && map[y, x + 1] == entity ||
                y > 0 && x < map.GetUpperBound(1) && map[y - 1, x + 1] == entity ||
                y < map.GetUpperBound(0) && x < map.GetUpperBound(1) && map[y + 1, x + 1] == entity ||
                y < map.GetUpperBound(0) && x > 0 && map[y + 1, x - 1] == entity ||
                y > 0 && x > 0 && map[y - 1, x - 1] == entity)
                return true;

            return false;
        }

        // private void addItemToBag() {   // bag
        //     char[,] map = maps[activeMapIndex].map;

        //     map[playerCoords.y, playerCoords.x] = 'o';
        //     char[] tempBag = new char[bag.Length + 1];
        //     for (int i = 0; i < bag.Length; i++) {
        //         tempBag[i] = bag[i];
        //     }
        //     tempBag[tempBag.Length - 1] = 'X';
        //     bag = tempBag;
        // }

        private void getNextRandomMap() {
            int nextMapIndex = new System.Random().Next(maps.Length);
            _activeMap = (Map)maps[nextMapIndex].Clone();
            _playerCoords = activeMap.startCoords;
            // bagCoords.y = maps[activeMapIndex].map.GetUpperBound(0) + 3;    // bag
        }

        private Map[] maps = {     // Todo: сделать считывание из json
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
        };
    }
}