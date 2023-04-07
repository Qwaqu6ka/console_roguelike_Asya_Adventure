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

        public HashSet<Enemy> enemies = null!;
        private List<Map> maps;

        private Map _activeMap = null!;
        public Map activeMap {
            get { return _activeMap; }
        }

        public MapScreen() {
            maps = App.properties.maps;
            getNextRandomMap();
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

        public bool isCellOccupiedByEnemy(Coordinates coords) {
            foreach (Enemy enemy in enemies) {
                if (enemy.coords.Equals(coords))
                    return true;
            }
            return false;
        }

        private void changeState() {
            char cell = activeMap.at(playerCoords);

            switch (cell) {
                case '▒':
                    getNextRandomMap();
                    break;
            }

            _isItemNear.data = checkNearbyCells(playerCoords, '$');
            _isEnemyNear.data = checkNearbyCells(playerCoords, 'Ü');
        }

        private bool isCellAllowed(Coordinates cell) {
            foreach (string symbol in App.properties.forbidenSymbols) {
                if (activeMap.at(cell) == symbol[0]) {
                    return false;
                } 
            }
            return true;
        }

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
            giveEnemiesRandomCoords();
        }

        private void getEnemies() {
            enemies = new HashSet<Enemy>();
            int nextEnemyCount = new System.Random()
                .Next(App.properties.enemyGenerationParams.maxEnemies + 1);
            EnemyGlossary enemyGlossary = new EnemyGlossary();
            for (int i = 0; i < nextEnemyCount; ++i) {
                enemies.Add(enemyGlossary.getRandomEnemy());
            }
        }

        private void giveEnemiesRandomCoords() {
            foreach (Enemy enemy in enemies) {

                bool isCoordUnique = true;
                Coordinates randCoords = new Coordinates(0, 0);

                do {
                    isCoordUnique = true;
                    
                    do {
                        randCoords = Coordinates.randomGenerate(activeMap.map.Count, activeMap.map[0].Length);
                    } while (!isCellAllowed(randCoords));

                    int minDist = App.properties.enemyGenerationParams.distanceBetweenEnemies;
                    foreach (Enemy enemy1 in enemies) {
                        if (!enemy.Equals(enemy1) && 
                            !enemy1.coords.Equals(Enemy.defaultCoords) && 
                            enemy.coords.distTo(enemy1.coords) <= minDist
                        ) {
                            isCoordUnique = false;
                            break;
                        }
                    }
                } while (!isCoordUnique);

                enemy.coords = randCoords;
            }
        }
    }
}