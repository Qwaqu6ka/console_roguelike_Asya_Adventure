namespace Roguelike {
    class Hero {
        public int hp = 5;
        public int maxHP = 5;
        public int minAttack = 5;
        public int maxAttack = 15;
        public int defence = 5;
        public int numOfCoins = 0;
        public Armor? armor;
        public Sword? sword;

        public void equipArmor(Armor armor) {
            if (this.armor != null) {
                defence -= armor.defencePoint;
                this.armor = armor;
                defence += armor.defencePoint;
            } else { 
                defence += armor.defencePoint;
                this.armor = armor;
            }
        }

        public void equipSword(Sword sword) {
            if (sword != null) {
                this.sword = sword;
                this.maxAttack += sword.attackPoints;
                this.minAttack += sword.attackPoints;

            }
        }
    }
}