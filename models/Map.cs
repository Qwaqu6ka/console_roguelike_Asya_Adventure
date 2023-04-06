namespace Roguelike {

    class Map : ICloneable {

        public List<string> map { get; set; }
        public Coordinates startCoords { get; set; }
        public Coordinates finishCoords { get; set; }

        public Map(List<string> map, Coordinates startCoords, Coordinates finishCoords) {
            this.map = map;
            this.startCoords = startCoords;
            this.finishCoords = finishCoords;
        }

        public char at(Coordinates coords) {
            return map[coords.y][coords.x];
        }

        public object Clone() {
            return new Map(
                new List<string>(this.map), 
                (Coordinates)this.startCoords.Clone(), 
                (Coordinates)this.finishCoords.Clone()
            );
        }
    }
}
