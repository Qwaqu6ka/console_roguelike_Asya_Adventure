namespace Roguelike {
    class Coordinates : ICloneable {
        public int x { get; set; }
        public int y { get; set; }

        public Coordinates(int x, int y) {
            this.x = x;
            this.y = y;
        }

        public object Clone() {
            return new Coordinates(this.x, this.y);
        }
    }
}