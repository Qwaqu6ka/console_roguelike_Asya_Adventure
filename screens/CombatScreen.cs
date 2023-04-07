namespace Roguelike {

    class CombatScreen : IKeyController {

        public int? lastPlayerHit = null;
        public int? lastEnemyHit = null;

        private Enemy enemy = null!;

        public void startFight(Enemy enemy) {
            this.enemy = enemy;
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

            int heroHit = 
                hero.minAttack + new System.Random().Next(hero.maxAttack - hero.minAttack);
            lastPlayerHit = Math.Max(heroHit - enemy.armor, 1);

            enemy.hp -= lastPlayerHit ?? throw new InvalidOperationException("lastPlayerHit is not intitialized");
            if (enemy.hp <= 0) {
                onPlayersWin();
            }
            
            int enemyHit =
                enemy.minAttack + new System.Random().Next(enemy.maxAttack - enemy.minAttack);
            lastEnemyHit = Math.Max(enemyHit - hero.defence, 1);
            if (hero.hp <= 0) {
                onPlayersLoose();
            }
        }

        private void onPlayersWin() {
            App.openWinScreen();
        }

        private void onPlayersLoose() {
            App.openLooseScreen();
        }
    }
}