namespace Roguelike {
    class KeyController {

        private IKeyController controller = null!;

        public KeyController() {
            App.activeScreen.observe((screen) => {
                controller = screen switch {
                    Screen.Map       => App.mapScreen,
                    Screen.Combat    => App.combatScreen,
                    Screen.Shop      => App.mapScreen,
                    Screen.Inventory => App.inventoryScreen,
                    Screen.Start     => App.startScreen,
                    Screen.End       => App.endScreen,
                    _ => throw new ArgumentOutOfRangeException("Not expected screen: {App.activeScreen}")
                };
            });
        }

        public void onKeyPressed(ConsoleKeyInfo charKey) {
            controller.onKeyPressed(charKey);
        }
    }

    interface IKeyController {
        public void onKeyPressed(ConsoleKeyInfo charKey);
    }
}