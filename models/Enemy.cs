namespace Roguelike {
    abstract class Enemy: ICloneable {
        public readonly int hp;
        public readonly int armor;
        public readonly int maxAttack;
        public readonly int minAttack;
        public string name;
        public bool isBlind = false;
        public Coordinates coords = new Coordinates(0, 0);

        public Enemy(int hp, int armor, int maxAttack, int minAttack, string name) {
            this.hp = hp;
            this.armor = armor;
            this.maxAttack = maxAttack;
            this.minAttack = minAttack;
            this.name = name;
        }

        abstract public object Clone();

        abstract public void mapMove(); // TODO: продумать сигнатуру
    }

    class Forgetful : Enemy {
        public Forgetful() : base(
            name: App.properties.enemyDefaultStats.Forgetful.name,
            hp: App.properties.enemyDefaultStats.Forgetful.hp, 
            armor: App.properties.enemyDefaultStats.Forgetful.armor, 
            maxAttack: App.properties.enemyDefaultStats.Forgetful.maxAttack,
            minAttack: App.properties.enemyDefaultStats.Forgetful.minAttack
        ) {}

        public override object Clone() {
            return new Forgetful();
        }

        override public void mapMove() {
            
        }
        
    }

    class Tracker : Enemy {
        public Tracker() : base(
            name: App.properties.enemyDefaultStats.Forgetful.name,
            hp: App.properties.enemyDefaultStats.Forgetful.hp, 
            armor: App.properties.enemyDefaultStats.Forgetful.armor, 
            maxAttack: App.properties.enemyDefaultStats.Forgetful.maxAttack,
            minAttack: App.properties.enemyDefaultStats.Forgetful.minAttack
        ) {}

        public override object Clone() {
            return new Tracker();
        }

        override public void mapMove() {
            
        }
        
    }

    class EnemyGlossary {
        private List<Enemy> enemyGlossary = new List<Enemy>() {
            new Tracker(),
            new Forgetful()
        };

        public Enemy getRandomEnemy() {
            int randomIndex = new System.Random().Next(enemyGlossary.Count);
            return (Enemy)enemyGlossary[randomIndex].Clone();
        }
    }
}