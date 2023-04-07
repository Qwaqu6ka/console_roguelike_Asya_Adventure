namespace Roguelike {
    class InventoryScreen : IKeyController {

        public Screen openedFrom;
        public HashSet<Item> inventory = new HashSet<Item>();

        public void addItem(Item item) {
            inventory.Add(item);
        }

        public void onKeyPressed(ConsoleKeyInfo charKey) {
            if (charKey.Key == ConsoleKey.Escape) {
                if (openedFrom == Screen.Map)
                    App.openMapScreen();
                else if (openedFrom == Screen.Combat)
                    App.backToCombatScreen();
            }

            // switch (charKey.Key) {
                
            // }
        }   
    }
}