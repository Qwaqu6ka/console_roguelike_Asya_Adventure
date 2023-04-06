namespace Roguelike {

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

        private List<Map> maps;

        private Map _activeMap = null!;
        public Map activeMap {
            get { return _activeMap; }
        }

        public MapScreen() {
            maps = App.properties.maps;
            getNextRandomMap();
        }

        private bool isCellAllowed(Coordinates cell) {
            List<string> map = activeMap.map;
            foreach (string symbol in App.properties.forbidenSymbols) {
                if (map[cell.y][cell.x] == symbol[0]) {
                    return false;
                } 
            }
            return true;
        }

        public void onKeyPressed(ConsoleKeyInfo charKey) {
            switch (charKey.Key) {
                case ConsoleKey.UpArrow:
                    if (isCellAllowed(new Coordinates(playerCoords.x, playerCoords.y - 1))) {
                        _playerCoords.y--;
                    }
                    break;

                case ConsoleKey.DownArrow:
                    if (isCellAllowed(new Coordinates(playerCoords.x, playerCoords.y + 1))) {
                        _playerCoords.y++;
                    }
                    break;

                case ConsoleKey.LeftArrow:
                    if (isCellAllowed(new Coordinates(playerCoords.x - 1, playerCoords.y))) {
                        _playerCoords.x--;
                    }
                    break;

                case ConsoleKey.RightArrow:
                    if (isCellAllowed(new Coordinates(playerCoords.x + 1, playerCoords.y))) {
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
            char cell = activeMap.map[playerCoords.y][playerCoords.x];

            switch (cell) {
                case '▒':
                    getNextRandomMap();
                    break;
            }

            _isItemNear.data = checkNearbyCells(playerCoords, '$');
            _isEnemyNear.data = checkNearbyCells(playerCoords, 'Ü');
        }

        // Проверяет клетку и окрестности на наличие какой-либо сущности
        private bool checkNearbyCells(Coordinates cell, char entity) {
            int x = cell.x, y = cell.y;
            List<string> map = activeMap.map;

            if (map[y][x] == entity ||
                y > 0 && map[y - 1][x] == entity ||
                y < map.Count - 1 && map[y + 1][x] == entity ||
                x > 0 && map[y][x - 1] == entity ||
                x < map[0].Length - 1 && map[y][x + 1] == entity ||
                y > 0 && x < map[0].Length - 1 && map[y - 1][x + 1] == entity ||
                y < map.Count - 1 && x < map[0].Length - 1 && map[y + 1][x + 1] == entity ||
                y < map.Count - 1 && x > 0 && map[y + 1][x - 1] == entity ||
                y > 0 && x > 0 && map[y - 1][x - 1] == entity)
                return true;

            return false;
        }

        private void getNextRandomMap() {
            int nextMapIndex = new System.Random().Next(maps.Count);
            _activeMap = (Map)maps[nextMapIndex].Clone();
            _playerCoords = activeMap.startCoords;

        }
    }
}