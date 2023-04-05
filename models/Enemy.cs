namespace Roguelike {
    abstract class Enemy {
        public readonly int hp;
        public readonly int armor;
        public readonly int maxAttack;
        public readonly int minAttack;
        public string name;
        public bool isBlind = false;

        public Enemy(int hp, int armor, int maxAttack, int minAttack, string name) {
            this.hp = hp;
            this.armor = armor;
            this.maxAttack = maxAttack;
            this.minAttack = minAttack;
            this.name = name;
        }

        abstract public void mapMove(); // TODO: продумать сигнатуру
    }

    class Forgetful : Enemy {
        public Forgetful() : base(
            name: "Забывака",
            hp: 6, 
            armor: 2, 
            maxAttack: 2,
            minAttack: 1
        ) {}

        override public void mapMove() {
            
        }
        
    }

    class Tracker : Enemy {
        public Tracker() : base(
            name: "Следопыт",
            hp: 5, 
            armor: 3, 
            maxAttack: 3,
            minAttack: 1
        ) {}

        override public void mapMove() {
            
        }
        
    }
}