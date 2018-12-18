using System;
using System.Collections.Generic;
using projet_RPG.Engine;

namespace projet_RPG {
    public static class WorldInit {

        public static readonly List<Item> worldItems = new List<Item>();
        public static readonly List<Location> worldLocations = new List<Location>();
        public static readonly List<Enemy> worldEnemies = new List<Enemy>();

        static WorldInit() {
            InitWorldMap();
            InitWorldMonsters();
        }

        // constantes des zones du monde
        public const int L_START_ZONE = 1;
        public const int L_FOREST = 2;
        public const int L_BEACH = 3;
        public const int L_CAVE = 4;
        public const int L_CHAPEL = 5;

        // constantes des mobs du monde
        public const int E_CHAPEL_HERETIC = 1;

        // constantes des items du jeu


        public static Item GetItem(int id)
        {
            foreach (Item i in worldItems) { if (i.id == id) return i; }
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


        public static void InitWorldMonsters()
        {
            Enemy heretic = new Enemy(E_CHAPEL_HERETIC, "Heretique", 8, 1, 3, 3);

            worldEnemies.Add(heretic);
        }

        public static void InitWorldMap()
        {
            Location startZone = new Location(L_START_ZONE, "Maison", @" La baraque, le début de toutes aventures!
              ____||____
             ///////////\
            ///////////  \
            |    _    |  |
            |[] | | []|[]|
            |   | |   |  |
            ");
            worldLocations.Add(startZone);

            Location chapelZone = new Location(L_CHAPEL, "Chapelle", @" Une chapelle bien flippante, qui sait ce qu'elle renferme comme secrets...
                       +
                       /_\
             ,%%%______|O|
             %%%/_________\
             `%%| /\[][][]|%
            ___||_||______|%&,__

            ");
            worldLocations.Add(chapelZone);
            chapelZone.enemyInLocation = GetEnemy(E_CHAPEL_HERETIC);


            // map logics, cf. dessin map pour réstituer la disposition
            startZone.southLocation = chapelZone;
            chapelZone.northLocation = startZone;
        }
    }
}