namespace Roguelike {

    abstract class Sword<T> : Item{
        public string effectDescription;
        public int cost;

        public Sword(string title, string effectDescription, int cost) : base(title) {
            this.effectDescription = effectDescription;
            this.cost = cost;
        }
    }

    class WoodenSword<T> : Sword<Hero> {
        public WoodenSword() : base(
            title: "Деревянный меч",
            effectDescription: "Увеличивает атаку на 2 единицы",
            cost: 3
        ) {}
    }

        class IronSword<T> : Sword<Hero> {
        public IronSword() : base(
            title: "Железный меч",
            effectDescription: "Увеличивает атаку на 4 единицы",
            cost: 5
        ) {}
    }

        class MagicSword<T> : Sword<Hero> {
        public MagicSword() : base(
            title: "Волшебный меч",
            effectDescription: "Увеличивает атаку на 7 единиц",
            cost: 7
        ) {}
    }
}