namespace Roguelike {

    public delegate void SwordEffect<T>(T value);

    abstract class Sword<T> : Item{
        public string effectDescription;
        public SwordEffect<T> effect;

        public Sword(string title, string effectDescription, SwordEffect<T> effect) : base(title) {
            this.effectDescription = effectDescription;
            this.effect = effect;
        }
    }

    class WoodenSword<T> : Sword<Hero> {
        public WoodenSword() : base(
            title: "Деревянный меч",
            effectDescription: "Увеличивает атаку на 2 единицы",
            effect: (hero) => {
                hero.attack = hero.attack + 2; 
            }
        ) {}
    }

        class IronSword<T> : Sword<Hero> {
        public IronSword() : base(
            title: "Железный меч",
            effectDescription: "Увеличивает атаку на 4 единицы",
            effect: (hero) => {
                hero.attack = hero.attack + 4; 
            }
        ) {}
    }

        class MagicSword<T> : Sword<Hero> {
        public MagicSword() : base(
            title: "Волшебный меч",
            effectDescription: "Увеличивает атаку на 7 единиц",
            effect: (hero) => {
                hero.attack = hero.attack + 7; 
            }
        ) {}
    }
}