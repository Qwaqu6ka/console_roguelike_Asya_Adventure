namespace Roguelike {
    class InventoryView : View{

        InventoryScreen inventoryScreen;
        public InventoryView(InventoryScreen inventoryScreen) {
            this.inventoryScreen = inventoryScreen;
        }

        public override void draw() {
            Console.WriteLine("Inventory");
            
        }
    }
}