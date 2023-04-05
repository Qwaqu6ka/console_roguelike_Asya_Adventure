namespace Roguelike {
    class Hero {
        public int hp;
        public int maxHP;
        public int attack;
        public int defence;
        public int numOfCoins;

        public Hero(int hp, int maxHP, int attack, int defence, int numOfCoins) {
            this.hp = hp;
            this.maxHP = maxHP;
            this.attack = attack;
            this.defence = defence;
            this.numOfCoins = numOfCoins;
        }
    }
}