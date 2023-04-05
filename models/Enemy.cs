namespace Roguelike {
    abstract class Enemy {
        public readonly int hp;
        public readonly int armor;
        public readonly int maxAttack;
        public readonly int minAttack;

        public Enemy(int hp, int armor, int maxAttack, int minAttack) {
            this.hp = hp;
            this.armor = armor;
            this.maxAttack = maxAttack;
            this.minAttack = minAttack;
        }

        abstract public void mapMove(); // TODO: продумать сигнатуру
    }

    class Zombie : Enemy {
        public Zombie() : base(
            hp: 5, 
            armor: 10, 
            maxAttack: 5,
            minAttack: 5
        ) {}

        override public void mapMove() {
            
        }
        
    }
}