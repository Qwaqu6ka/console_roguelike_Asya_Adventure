namespace Roguelike {

    class ViewRouter {

        private View viewToShow = null!;

        public ViewRouter() {
            App.activeScreen.observe((screen) => {
                viewToShow = screen switch {
                    Screen.Start     => new StartView(App.startScreen),
                    Screen.Map       => new MapView(App.mapScreen),
                    Screen.Combat    => new CombatView(App.combatScreen),
                    Screen.Shop      => new MapView(App.mapScreen),
                    Screen.Inventory => new InventoryView(App.inventoryScreen),
                    Screen.End       => new EndView(),
                    _ => throw new ArgumentOutOfRangeException("Not expected screen: {App.activeScreen}")
                };
            });
        }

        public void draw() {
            Console.Clear();
            viewToShow.draw();
        }
    }

    abstract class View {
        abstract public void draw();
    }
}
