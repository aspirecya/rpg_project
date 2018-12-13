using System;
namespace projet_RPG {
    public class Location {

        public enum LocationType { GRASS, ROCK, CHEST, HOUSE }

        public string name;
        public string desc;
        public char visualisation;
        public LocationType type;
        public bool canWalkThrough;

        public Location(string name, string desc, LocationType type) {
            this.name = name;
            this.desc = desc;
            this.type = type;

            switch (type) {
                case LocationType.GRASS:
                    this.visualisation = 'G';
                    break;
                case LocationType.ROCK:
                    this.visualisation = 'R';
                    break;
                case LocationType.CHEST:
                    this.visualisation = 'C';
                    break;
                case LocationType.HOUSE:
                    this.visualisation = 'H';
                    break;
            }
        }
    }
}
