namespace Roguelike {

    public delegate void PotionEffect<T>(T value);

    abstract class Potion<T> : Item {
        public string effectDescription;
        public PotionEffect<T> effect;
        // public override void useItem() {
        //     effect.Invoke(any);
        // }

        public Potion(string title, string effectDescription, PotionEffect<T> effect) : base(title) {
            this.effectDescription = effectDescription;
            this.effect = effect;
        }
    }

    class InvisiblePotion : Potion<List<Enemy>> {
        public InvisiblePotion() : base(
            title: "Гриб-неведимка",
            effectDescription: "Прячет вас от врагов",
            effect: (enemyList) => {
                foreach (Enemy enemy in enemyList) {
                    enemy.isBlind = true;
                }
            }
        ) {}

        // public void useItem() {
        //     effect.Invoke
        // }
    }

    class HealPotion : Potion<Hero> {
        public HealPotion() : base(
            title: "Чудо-варево",
            effectDescription: "Восстанавливает 3 единицы здоровья",
            effect: (hero) => {
                hero.hp = Math.Min(hero.maxHP, hero.hp + 3);
            }
        ) {}
    }
}