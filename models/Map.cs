namespace Roguelike {

    class Map : ICloneable {

        public char[,] map;
        public Coordinates startCoords;
        public Coordinates finishCoords;

        public Map(char[,] map, Coordinates startCoords, Coordinates finishCoords) {
            this.map = map;
            this.startCoords = startCoords;
            this.finishCoords = finishCoords;
        }

        public object Clone() {
            return new Map(
                (char[,])this.map.Clone(), 
                (Coordinates)this.startCoords.Clone(), 
                (Coordinates)this.finishCoords.Clone()
            );
        }
    }
}
