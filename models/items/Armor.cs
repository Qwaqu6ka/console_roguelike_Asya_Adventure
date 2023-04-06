namespace Roguelike {

    abstract class Armor : SellableItem {
        public string effectDescription;
        public int defencePoint;

        public Armor(string title, string effectDescription, int defencePoint, int cost) : base(
            title: title, 
            cost: cost
        ) {
            this.effectDescription = effectDescription;
            this.defencePoint = defencePoint;
        }
    }

    class Shield : Armor {
        public Shield() : base(
            title: "Щит",
            effectDescription: "Увеличивает защиту на 1 единицу",
            defencePoint: 1,
            cost: 4
        ) {}
    }

        class BreastPlate : Armor {
        public BreastPlate() : base(
            title: "Нагрудник",
            effectDescription: "Увеличивает защиту на 3 единицы",
            defencePoint: 3,
            cost: 7
        ) {}
    }

        class Armour : Armor {
        public Armour() : base(
            title: "Доспехи",
            effectDescription: "Увеличивает защиту на 5 единиц",
            defencePoint: 5,
            cost: 10
        ) {}
    }
}