namespace Roguelike {
    class KeyController {
        private MapScreen mapScreen;

        public KeyController(MapScreen mapScreen) {
            this.mapScreen = mapScreen;
        }

        public void onKeyPressed(ConsoleKeyInfo charKey) {
            IKeyController controller = App.activeScreen.data switch {
                Screen.Map       => mapScreen,
                Screen.Combat    => mapScreen,
                Screen.Shop      => mapScreen,
                Screen.Inventory => mapScreen,
                Screen.Menu      => mapScreen,
                _ => throw new ArgumentOutOfRangeException("Not expected screen: {App.activeScreen}")
            };
            controller.onKeyPressed(charKey);
        }
    }

    interface IKeyController {
        public void onKeyPressed(ConsoleKeyInfo charKey); //? private
    }
}