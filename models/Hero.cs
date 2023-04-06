namespace Roguelike {
    class Hero {
        public int hp = App.properties.heroDefaultStats.defaultHP;
        public int maxHP = App.properties.heroDefaultStats.defaultHP;
        public int minAttack = App.properties.heroDefaultStats.defaultMinAttack;
        public int maxAttack = App.properties.heroDefaultStats.defaultMaxAttack;
        public int defence = App.properties.heroDefaultStats.defaultDefence;
        public int numOfCoins = 0;
        public Armor? armor;
        public Sword? sword;

        public void equipArmor(Armor armor) {
            
        }

        public void equipSword(Item Sword) {

        }
    }
}