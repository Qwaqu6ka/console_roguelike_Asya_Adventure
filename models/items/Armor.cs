namespace Roguelike {

    abstract class Armor<T> : Item{
        public string effectDescription;
        public int defencePoint;
        public int cost;

        public Armor(string title, string effectDescription, int defencePoint, int cost) : base(title) {
            this.effectDescription = effectDescription;
            this.defencePoint = defencePoint;
            this.cost = cost;
        }
    }

    class Shield<T> : Armor<Hero> {
        public Shield() : base(
            title: "Щит",
            effectDescription: "Увеличивает защиту на 1 единицу",
            defencePoint: 1,
            cost: 4
        ) {}
    }

        class BreastPlate<T> : Armor<Hero> {
        public BreastPlate() : base(
            title: "Нагрудник",
            effectDescription: "Увеличивает защиту на 3 единицы",
            defencePoint: 3,
            cost: 7
        ) {}
    }

        class Armour<T> : Armor<Hero> {
        public Armour() : base(
            title: "Доспехи",
            effectDescription: "Увеличивает защиту на 5 единиц",
            defencePoint: 5,
            cost: 10
        ) {}
    }
}