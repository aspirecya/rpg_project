using System;
using System.Collections.Generic;
using projet_RPG.Engine;

namespace projet_RPG {
    public class Init {

        // world location constants, they all start with L_
        const int L_START_ZONE = 1;
        const int L_FOREST = 2;
        const int L_BEACH = 3;
        const int L_CAVE = 4;
        const int L_CHAPEL = 5;

        // world enemies constants, they all start with E_
        const int E_CHAPEL_HERETIC = 1;

        // world items constants, starts with I_


        public static readonly List<Items> worldItems = new List<Items>();
        public static readonly List<Location> worldLocations = new List<Location>();
        public static readonly List<Enemy> worldEnemies = new List<Enemy>();


        public static Items GetItem(int id)
        {
            foreach (Items i in worldItems) { if (i.id == id) return i; }
            return null;
        }

        public static Enemy GetEnemy(int id)
        {
            foreach (Enemy e in worldEnemies) { if (e.id == id) return e; }
            return null;
        }
        public static Location GetLocation(int id)
        {
            foreach (Location l in worldLocations) { if (l.id == id) return l; }
            return null;
        }


        public static void initWorldMonsters()
        {
            Enemy heretic = new Enemy(E_CHAPEL_HERETIC, "Heretic", 100, 8, 5, 3, 3);

            worldEnemies.Add(heretic);
        }

        public static void initWorldMap()
        {
            Location startZone = new Location(L_START_ZONE, "Home", @" Your home, a starting point for every adventure!
                                                                              ____||____
                                                                             ///////////\
                                                                            ///////////  \
                                                                            |    _    |  |
                                                                            |[] | | []|[]|
                                                                            |   | |   |  |
            ");
            worldLocations.Add(startZone);

            Location chapelZone = new Location(L_CHAPEL, "Chapel", @" A creepy small chapel, who knows what secrets it holds...
                                                                                       +
                                                                                       /_\
                                                                             ,%%%______|O|
                                                                             %%%/_________\
                                                                             `%%| /\[][][]|%
                                                                            ___||_||______|%&,__

            ");
            worldLocations.Add(chapelZone);
            chapelZone.enemyInLocation = GetEnemy(E_CHAPEL_HERETIC);


            // map logics
            startZone.southLocation = chapelZone;
        }
    }
}