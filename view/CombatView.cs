namespace Roguelike {

    using System.Threading.Tasks;

    class CombatView : View {   //TODO: сделать EndScreen

        private CombatScreen combatScreen = null!;    
        private List<string> defaultCombatScreen = App.properties.screens.combat.defaultBattle;
        private List<string> enemyAttackScreen = App.properties.screens.combat.enemyAttack;
        private List<string> enemyVictoryScreen = App.properties.screens.combat.enemyVictory;
        private List<string> heroAttackScreen = App.properties.screens.combat.heroAttack;
        private List<string> heroVictoryScreen = App.properties.screens.combat.heroVictory;

        private bool isEnemyAttacking = false;
        private bool isHeroAttacking = false;
        private bool isPlayerLoose = false;
        private bool isEnemyLoose = false;

        public CombatView(CombatScreen combatScreen) {
            this.combatScreen = combatScreen;
            combatScreen.isEnemyAttacking.observe((yes) => {
                if (yes) this.isEnemyAttacking = true;
            });
            combatScreen.isHeroAttacking.observe((yes) => {
                if (yes) this.isHeroAttacking = true;
            });
            combatScreen.isPlayerLoose.observe((yes) => {
                if (yes) this.isEnemyLoose = true;
            });
            CombatScreen.defeatedEnemy.observe((enemy) => {
                if (enemy != null) {
                    isEnemyLoose = true;
                }
            });
        }

        public override async void draw() {

            if (isHeroAttacking)
                drawScreenDelay(heroAttackScreen);
            
            if (isEnemyAttacking)
                drawScreenDelay(enemyAttackScreen);
            else if (isEnemyLoose)
                drawScreenDelay(heroVictoryScreen);
                
            if (isPlayerLoose)
                drawScreenDelay(enemyVictoryScreen);
            

            if (isEnemyLoose)
                App.openMapScreen();
            else
                drawScreen(defaultCombatScreen);

            isEnemyAttacking = isHeroAttacking = isPlayerLoose = isEnemyLoose = false;
        }

        private void drawScreenDelay(List<string> screen) {
            Task task = Task.Run(async delegate {
                    drawScreen(screen);
                    await Task.Delay(App.properties.animationDelayMillis);
                });
            task.Wait();
            Console.Clear();
        }

        private void drawScreen(List<string> screen) {
            for (int y = 0; y < screen.Count; y++) {
                for (int x = 0; x < screen[0].Length; x++) {
                    Console.Write(screen[y][x]);
                }
                Console.WriteLine();
            }

            Hero hero = App.hero;
            Console.WriteLine("Лесник:");
            Console.Write("Здоорвье: {0}/{1}", hero.hp, hero.maxHP);
            Console.Write("  Сила атаки: {0}-{1}", hero.minAttack, hero.maxAttack);
            Console.WriteLine("  Защита: {0}", hero.defence);

            Enemy enemy = combatScreen.enemy;
            Console.WriteLine("{0}:", enemy.name);
            Console.Write("Здоровье: {0}/{1}", enemy.hp, enemy.maxHP);
            Console.Write("  Сила атаки: {0}-{1}", enemy.minAttack, enemy.maxAttack);
            Console.WriteLine("  Защита: {0}", enemy.armor);
        }
    }
}