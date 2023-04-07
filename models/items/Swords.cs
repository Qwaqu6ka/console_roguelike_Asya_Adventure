namespace Roguelike {

    abstract class Sword : SellableItem {
        public string effectDescription;
        public int attackPoints;

        public Sword(string title, string effectDescription, int cost, int attackPoints) : base(
            title: title, 
            cost: cost
        ) {
            this.effectDescription = effectDescription;
            this.attackPoints = attackPoints;
        }
    }

    class WoodenSword : Sword {
        public WoodenSword() : base(
            title: "Деревянный меч",
            effectDescription: "Увеличивает атаку на 2 единицы",
            cost: 3,
            attackPoints: 2
        ) {}
    }

        class IronSword : Sword {
        public IronSword() : base(
            title: "Железный меч",
            effectDescription: "Увеличивает атаку на 4 единицы",
            cost: 5,
            attackPoints: 4
        ) {}
    }

        class MagicSword : Sword {
        public MagicSword() : base(
            title: "Волшебный меч",
            effectDescription: "Увеличивает атаку на 7 единиц",
            cost: 7,
            attackPoints: 7
        ) {}
    }
}