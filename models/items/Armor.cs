namespace Roguelike {

    public delegate void ArmorEffect<T>(T value);

    abstract class Armor<T> : Item{
        public string effectDescription;
        public ArmorEffect<T> effect;

        public Armor(string title, string effectDescription, ArmorEffect<T> effect) : base(title) {
            this.effectDescription = effectDescription;
            this.effect = effect;
        }
    }

    class Shield<T> : Armor<Hero> {
        public Shield() : base(
            title: "Щит",
            effectDescription: "Увеличивает защиту на 1 единицу",
            effect: (hero) => {
                hero.defence = hero.defence + 1; 
            }
        ) {}
    }

        class BreastPlate<T> : Armor<Hero> {
        public BreastPlate() : base(
            title: "Нагрудник",
            effectDescription: "Увеличивает защиту на 3 единицы",
            effect: (hero) => {
                hero.defence = hero.defence + 3; 
            }
        ) {}
    }

        class Armour<T> : Armor<Hero> {
        public Armour() : base(
            title: "Доспехи",
            effectDescription: "Увеличивает защиту на 5 единиц",
            effect: (hero) => {
                hero.defence = hero.defence + 5; 
            }
        ) {}
    }
}