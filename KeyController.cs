namespace Roguelike {
    class KeyController {

        public void onKeyPressed(ConsoleKeyInfo charKey) {
            IKeyController controller = App.activeScreen.data switch {
                Screen.Map       => App.mapScreen,
                Screen.Combat    => App.mapScreen,
                Screen.Shop      => App.mapScreen,
                Screen.Inventory => App.inventoryScreen,
                Screen.Start     => App.startScreen,
                _ => throw new ArgumentOutOfRangeException("Not expected screen: {App.activeScreen}")
            };
            controller.onKeyPressed(charKey);
        }
    }

    interface IKeyController {
        public void onKeyPressed(ConsoleKeyInfo charKey);
    }
}