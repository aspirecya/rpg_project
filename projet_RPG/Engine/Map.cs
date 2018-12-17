using System;
using projet_RPG.Engine;

namespace projet_RPG {
    public class Map {

        public int height;
        public int length;
        public int MapSize;
        public string MapName;
        public Location[,] GameMap;

        public Map() {
            GameMap = new Location[length, height];

            for(int i = 0; i < length; i++) {
                for(int j = 0; j < height; j++) {
                    GameMap[i, j] = new Location();
                }
            }
        }
    }
}
