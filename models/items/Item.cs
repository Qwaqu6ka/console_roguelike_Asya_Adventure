namespace Roguelike {

    abstract class Item {
        string title;
        
        public Item(string title) {
            this.title = title;
        }
    }

    abstract class SellableItem : Item {
        public int cost;

        public SellableItem(string title, int cost) : base(title) {
            this.cost = cost;
        }
    }
}
