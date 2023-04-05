namespace Roguelike {
    class Hero {
        public int hp;
        public int maxHP;
        public int minAttack;
        public int maxAttack;
        public int defence;
        public int numOfCoins;
        public int armor;
        public int sword;

        public Hero(int hp, int maxHP, int minAttack, int maxAttack, int defence, int numOfCoins, int armor, int sword) {
            this.hp = hp;
            this.maxHP = maxHP;
            this.minAttack = minAttack;
            this.maxAttack = maxAttack;
            this.defence = defence;
            this.numOfCoins = numOfCoins;
            this.armor = armor;
            this.sword =sword;
        }

        public void equipArmor(Item Armor) {

        }

        public void equipSword(Item Sword) {

        }
    }
}