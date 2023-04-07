namespace Roguelike {

    class MapScreen : IKeyController {
        private Coordinates _playerCoords = null!;
        public Coordinates playerCoords {
            get { return _playerCoords; }
        }

        private Map _activeMap = null!;
        public Map activeMap {
            get { return _activeMap; }
        }

        public HashSet<Enemy> enemies = null!;

        public HashSet<Item> items = null!;

        private List<Map> maps;
        private Map finalMap = App.properties.finalBattle;

        private int mapCounter = 0;

        public MapScreen() {
            maps = App.properties.maps;
            getNextRandomMap();

            CombatScreen.defeatedEnemy.observe((enemy) => {
                if (enemy != null)
                    removeEnemy(enemy);
            });
        }

        private void removeEnemy(Enemy enemy) {
            enemies.Remove(enemy);
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
            checkForFight();
            checkItem();
            checkExit();
        }

        private void checkItem() {  // TODO
            if (playerCoords.Equals(activeMap.finishCoords))
                getNextRandomMap();
        }

        private void checkExit() {
            if (playerCoords.Equals(activeMap.finishCoords))
                getNextRandomMap();
        }

        private void checkForFight() {
            foreach (Enemy enemy in enemies) {
                if (playerCoords.distTo(enemy.coords) <= 1) {
                    App.openCombatScreen(enemy);
                }
            }
        }

        private bool isCellAllowed(Coordinates cell) {
            foreach (string symbol in App.properties.forbidenSymbols) {
                if (activeMap.at(cell) == symbol[0]) {
                    return false;
                } 
            }
            return true;
        }

        private void getNextRandomMap() {
            if (mapCounter == App.properties.levelsToFinalBoss) {
                App.openWinScreen();
                return;
            }

            mapCounter++;
            if (mapCounter < App.properties.levelsToFinalBoss) {
                int nextMapIndex = new System.Random().Next(maps.Count);
                _activeMap = (Map)maps[nextMapIndex].Clone();
            }
            else {
                _activeMap = (Map)finalMap.Clone();
            }
            
            _playerCoords = activeMap.startCoords;
            
            getEnemies();
            giveEnemiesRandomCoords();
            getItems();
        }

        private void getItems() {   // TODO:
            items = new HashSet<Item>();
            int nextItemCount = new System.Random()
                .Next(App.properties.itemsSpawnMaxCount + 1);
            
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
                            randCoords.distTo(enemy1.coords) <= minDist
                        ) {
                            isCoordUnique = false;
                            break;
                        }
                    }
                    if (enemy.coords.distTo(playerCoords) <= minDist)
                        isCoordUnique = false;
                        
                } while (!isCoordUnique);

                enemy.coords = randCoords;
            }
        }
    }
}