namespace Roguelike {
    class InventoryScreen : IKeyController{

        public HashSet<Item> inventory = new HashSet<Item>();

        public void addItem(Item item) {
            inventory.Add(item);
        }

        public void onKeyPressed(ConsoleKeyInfo charKey) {
            if (charKey.Key == ConsoleKey.Escape) {
                App.openMapScreen();
            }

            // switch (charKey.Key) {
                
            // }
        }   
    }
}