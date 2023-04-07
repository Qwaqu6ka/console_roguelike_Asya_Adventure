namespace Roguelike {
    class Coordinates : ICloneable {
        public int x { get; set; }
        public int y { get; set; }

        public Coordinates(int x, int y) {
            this.x = x;
            this.y = y;
        }

        public int distTo(Coordinates coords) {
            return Convert.ToInt32(
                Math.Sqrt(Math.Pow(Math.Abs(coords.x - this.x), 2) + Math.Pow(Math.Abs(coords.y - this.y), 2))
            );
        }

        public static Coordinates randomGenerate(
            int upBorder, 
            int rightBorder, 
            int downBorder = 0,
            int leftBorder = 0
        ) {
            int x = leftBorder + new System.Random().Next(rightBorder - leftBorder);
            int y = downBorder + new System.Random().Next(upBorder - downBorder);
            return new Coordinates(x, y);
        }

        public object Clone() {
            return new Coordinates(this.x, this.y);
        }

        public override bool Equals(object obj) {
            return Equals(obj as Coordinates);
        }

        public bool Equals(Coordinates other) {
            return other != null &&
                this.x == other.x &&
                this.y == other.y;
        }

        public override int GetHashCode() {
            return HashCode.Combine(x, y);
        }
    }
}