namespace Roguelike {

    class MapScreen : IKeyController {
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
        private HashSet<Enemy> enemies = null!;

        private Map _activeMap = null!;
        public Map activeMap {
            get { return _activeMap; }
        }

        public MapScreen() {
            maps = App.properties.maps;
            getNextRandomMap();
        }

        public void onKeyPressed(ConsoleKeyInfo charKey) {
            List<string> map = activeMap.map;
            switch (charKey.Key) {
                case ConsoleKey.UpArrow:
                    if (map[playerCoords.y - 1][playerCoords.x] != '#') {
                        _playerCoords.y--;
                    }
                    break;

                case ConsoleKey.DownArrow:
                    if (map[playerCoords.y + 1][playerCoords.x] != '#') {
                        _playerCoords.y++;
                    }
                    break;

                case ConsoleKey.LeftArrow:
                    if (map[playerCoords.y][playerCoords.x - 1] != '#') {
                        _playerCoords.x--;
                    }
                    break;

                case ConsoleKey.RightArrow:
                    if (map[playerCoords.y][playerCoords.x + 1] != '#') {
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
            
            getEnemies();
        }

        private void getEnemies() {
            enemies = new HashSet<Enemy>();
            // int nextEnemyCount = new System.Random()
            //     .Next(App.properties.enemyGenerationParams.maxEnemies + 1);
            int nextEnemyCount = 1;
            EnemyGlossary enemyGlossary = new EnemyGlossary();
            for (int i = 0; i < nextEnemyCount; ++i) {
                enemies.Add(enemyGlossary.getRandomEnemy());
            }
            
            foreach (Enemy enemy in enemies) {
                bool isCoordUnique = true;
                do {
                    Coordinates coords = 
                        Coordinates.randomGenerate(activeMap.map.Count, activeMap.map[0].Length);
                    
                    while (activeMap.map[coords.y][coords.x])

                    int minDist = App.properties.enemyGenerationParams.distanceBetweenEnemies;
                    foreach (Enemy enemy1 in enemies) {
                        if (enemy != enemy1 && enemy.coords.distTo(enemy1.coords) <= minDist) {
                            isCoordUnique = false;
                            break;
                        }
                    }

                } while (!isCoordUnique);
            }
        }
    }
}