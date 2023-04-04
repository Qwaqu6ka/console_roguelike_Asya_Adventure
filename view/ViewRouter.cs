namespace Roguelike {

    class ViewRouter {

        private View viewToShow;

        public ViewRouter() {
            App.activeScreen.observe((screen) => {
                viewToShow = screen switch {
                    Screen.Menu      => new MapView(App.mapScreen),
                    Screen.Map       => new MapView(App.mapScreen),
                    Screen.Combat    => new MapView(App.mapScreen),
                    Screen.Shop      => new MapView(App.mapScreen),
                    Screen.Inventory => new MapView(App.mapScreen),
                    _ => throw new ArgumentOutOfRangeException("Not expected screen: {App.activeScreen}")
                };
            });
        }

        public void draw() {
            viewToShow.draw();
        }
    }

    abstract class View {
        protected int _length;
        public int Length {
            get { return _length; }
        }

        protected int _height;
        public int Height {
            get { return _height; }
        }

        abstract public void draw();
    }
}
