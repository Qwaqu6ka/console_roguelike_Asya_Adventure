namespace Roguelike {
    class KeyController {
        private MapService mapService;

        public KeyController(MapService mapService) {
            this.mapService = mapService;
        }

        public void onKeyPressed(ConsoleKeyInfo charKey) {
            IKeyController controller = App.activeScreen switch {
                Screen.Map       => mapService,
                Screen.Combat    => mapService,
                Screen.Shop      => mapService,
                Screen.Inventory => mapService,
                Screen.Menu      => mapService,
                _ => throw new ArgumentOutOfRangeException("Not expected screen: {App.activeScreen}")
            };
            controller.onKeyPressed(charKey);
        }
    }

    interface IKeyController {
        public void onKeyPressed(ConsoleKeyInfo charKey);
    }
}