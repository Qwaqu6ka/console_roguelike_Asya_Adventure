namespace Roguelike {

    class CombatScreen : IKeyController {
        public int? lastPlayerHit = null;
        public int? lastEnemyHit = null;

        public Enemy enemy = null!;
        private MapScreen mapScreen = null!;

        private MutableLiveData<bool> _isHeroAttacking = new MutableLiveData<bool>(false);
        public LiveData<bool> isHeroAttacking {
            get { return _isHeroAttacking; }
        }

        private MutableLiveData<bool> _isEnemyAttacking = new MutableLiveData<bool>(false);
        public LiveData<bool> isEnemyAttacking {
            get { return _isEnemyAttacking; }
        }

        private MutableLiveData<bool> _isPlayerLoose = new MutableLiveData<bool>(false);
        public LiveData<bool> isPlayerLoose {
            get { return _isPlayerLoose; }
        }

        private static MutableLiveData<Enemy?> _defeatedEnemy = new MutableLiveData<Enemy?>(null);
        public static LiveData<Enemy?> defeatedEnemy {
            get { return _defeatedEnemy; }
        }

        public CombatScreen(MapScreen mapScreen) {
            this.mapScreen = mapScreen;
        }

        public void startFight(Enemy enemy) {
            this.enemy = enemy;
            _defeatedEnemy.data = null;
            _isPlayerLoose.data = false;
        }

        public void onKeyPressed(ConsoleKeyInfo charKey) {
            switch (charKey.Key) {
                case ConsoleKey.I:
                    App.openInventoryScreen();
                    break;
                case ConsoleKey.H:
                    makeHit();
                    break;
            }
        }

        private void makeHit() {
            Hero hero = App.hero;

            lastPlayerHit = null;
            lastEnemyHit = null;

            _isHeroAttacking.data = true;
            _isHeroAttacking.data = false;

            int heroHit = 
                hero.minAttack + new System.Random().Next(hero.maxAttack - hero.minAttack);
            lastPlayerHit = Math.Max(heroHit - enemy.armor, 1);

            enemy.hp -= lastPlayerHit ?? throw new InvalidOperationException("lastPlayerHit is not intitialized");
            
            if (enemy.hp <= 0) {
                onPlayersWin();
            }
            else {
                _isEnemyAttacking.data = true;
                _isEnemyAttacking.data = false;
                
                int enemyHit =
                    enemy.minAttack + new System.Random().Next(enemy.maxAttack - enemy.minAttack);
                lastEnemyHit = Math.Max(enemyHit - hero.defence, 1);

                hero.hp -= lastEnemyHit ?? throw new InvalidOperationException("lastEnemyHit is not intitialized");;
                if (hero.hp <= 0) {
                    onPlayersLoose();
                }
            }
        }

        private void onPlayersWin() {
            _defeatedEnemy.data = enemy;
        }

        private void onPlayersLoose() {
            _isPlayerLoose.data = true;
        }
    }
}