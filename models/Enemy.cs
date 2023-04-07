namespace Roguelike {
    abstract class Enemy: ICloneable {
        public int hp;
        public readonly int maxHP;
        public readonly int armor;
        public readonly int maxAttack;
        public readonly int minAttack;
        public readonly string name;
        public readonly char symbolOnMap;
        public bool isBlind = false;

        public static Coordinates defaultCoords = new Coordinates(-100, -100);
        public Coordinates coords = defaultCoords;

        public Enemy(int hp, int armor, int maxAttack, int minAttack, string name, char symbolOnMap) {
            this.hp = hp;
            this.maxHP = hp;
            this.armor = armor;
            this.maxAttack = maxAttack;
            this.minAttack = minAttack;
            this.name = name;
            this.symbolOnMap = symbolOnMap;
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
            minAttack: App.properties.enemyDefaultStats.Forgetful.minAttack,
            symbolOnMap: App.properties.icons.Forgetful[0]
        ) {}

        public override object Clone() {
            return new Forgetful();
        }

        override public void mapMove() {
            
        }
        
    }

    class Tracker : Enemy {
        public Tracker() : base(
            name: App.properties.enemyDefaultStats.Tracker.name,
            hp: App.properties.enemyDefaultStats.Tracker.hp, 
            armor: App.properties.enemyDefaultStats.Tracker.armor, 
            maxAttack: App.properties.enemyDefaultStats.Tracker.maxAttack,
            minAttack: App.properties.enemyDefaultStats.Tracker.minAttack,
            symbolOnMap: App.properties.icons.Tracker[0]
        ) {}

        public override object Clone() {
            return new Tracker();
        }

        override public void mapMove() {
            
        }
        
    }

        class MushroomBoss : Enemy {
        public MushroomBoss() : base(
            name: "Повелитель леса",
            hp: 25, 
            armor: 5, 
            maxAttack: 6,
            minAttack: 3 ,
            symbolOnMap: 'B'
        ) {}

        public override object Clone() {
            return new MushroomBoss();
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