using System;
using System.Collections.Generic;
using System.Linq;
using projet_RPG.Engine;

namespace projet_RPG {
    public static class WorldInitialization {

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//


        public static readonly List<Item> worldItems = new List<Item>();
        public static List<Weapon> worldWeapons { get { return worldItems.OfType<Weapon>().ToList(); } }
        public static readonly List<Location> worldLocations = new List<Location>();
        public static readonly List<Enemy> worldEnemies = new List<Enemy>();

        static WorldInitialization() {
            InitWorldItems();
            InitWorldMonsters();
            InitWorldMap();
        }


        // constantes des items du jeu

        // potions
        public const int ITEM_HEALTH_POTION = 1;
        public const int ITEM_MEDIUM_HEALTH_POTION = 2;

        // weapons
        public const int ITEM_WOODEN_SWORD = 1;
        public const int ITEM_IRON_SWORD = 2;
        public const int ITEM_WOODEN_SHIELD = 3;

        // constantes des mobs du monde
        public const int ENEMY_HERETIC = 1;
        public const int ENEMY_ZOMBIE = 2;
        public const int ENEMY_SKELETON = 3;
        public const int ENEMY_ORC = 4;
        public const int ENEMY_BIGSNAKE = 5;

        // constantes des zones du monde
        public const int LOC_HOME = 1;
        public const int LOC_CHAPEL = 2;
        public const int LOC_CASTLE = 3;
        public const int LOC_TOWNHALL = 4;
        public const int LOC_DESERT = 5;


        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//


        public static Item GetItem(int id)
        {
            foreach (Item i in worldItems) { if (i.id == id) return i; }
            return null;
        }

        public static Potion GetPotion(int id)
        {
            foreach (Item i in worldItems) { if (i.id == id) return (Potion)i; }
            return null;
        }

        public static Weapon GetWeapon(int id)
        {
            foreach (Weapon w in worldWeapons) { if (w.id == id) return w; }
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


        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//

        public static void InitWorldItems() {
            // potions
            worldItems.Add(new Potion(ITEM_HEALTH_POTION, "Potion de vie", "Une concoction bizarre qui vous donne 10 hp", 10, Potion.PotionType.heal, 10));
            worldItems.Add(new Potion(ITEM_MEDIUM_HEALTH_POTION, "Potion de vie moyenne", "Une petite bouteille qui contiens un liquide rouge, vous redonne 40 hp", 30, Potion.PotionType.heal, 40));

            // weapons
            worldItems.Add(new Weapon(ITEM_WOODEN_SWORD, "Epee en bois", "Une épee courte en bois, pas terrible mais ça fait mal.", 8, 1, 4));
            worldItems.Add(new Weapon(ITEM_IRON_SWORD, "Epee en fer", "Une petite amélioration de l'épée en bois, mais toujour aussi nul.", 14, 1, 8));

        }


        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//


        public static void InitWorldMonsters() {
            worldEnemies.Add(new Enemy(ENEMY_HERETIC, "Heretique", 3, 1, 3, 10));
            worldEnemies.Add(new Enemy(ENEMY_ZOMBIE, "Zombie", 6, 2, 8, 15));
            worldEnemies.Add(new Enemy(ENEMY_SKELETON, "Squelette", 3, 10, 8, 20));
            worldEnemies.Add(new Enemy(ENEMY_ORC, "Orc", 12, 8, 10, 25));
            worldEnemies.Add(new Enemy(ENEMY_BIGSNAKE, "Giga Cobra", 20, 10, 50, 50));

        }


        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//


        public static void InitWorldMap() {
            Location home = new Location(LOC_HOME, "Maison", @"Faudrait peut-être penser à ranger...
                           (   )
                          (    )
                           (    )
                          (    )
                            )  )
                           (  (                  /\
                            (_)                 /  \  /\
                    ________[_]________      /\/    \/  \
           /\      /\        ______    \    /   /\/\  /\/\
          /  \    //_\       \    /\    \  /\/\/    \/    \
   /\    / /\/\  //___\       \__/  \    \/
  /  \  /\/    \//_____\       \ |[]|     \
 /\/\/\/       //_______\       \|__|      \
/      \      /XXXXXXXXXX\                  \
        \    /_I_II  I__I_\__________________\
               I_I|  I__I_____[]_|_[]_____I
               I_II  I__I_____[]_|_[]_____I
               I II__I  I     XXXXXXX     I
            ~~~~~""   ""~~~~~~~~~~~~~~~~~~~~~~~~
            ");


            Location chapel = new Location(LOC_CHAPEL, "Chapelle", @"Un chapelle lugubre...
             .
            -|-
             |
            /A\
           //^\\
         ,// _ \\,
         |/`/_\`\|
          |  ,  |
          | /^\ |
          |//'\\|
        ,//` _ `\\,
      ,//` .'|'. `\\,
    ,//`   |-|-|   `\\,
  ,//`     [_|_]     `\\,
  |/T                 T\|
    |  _   __ __   _  |
    | /_\ |  |  | /_\ |
    | |_| | .|. | |_| |
    |     |__|__|     |
    '----[_______]----'
          =======
         ======
      ======

            ");


            Location castle = new Location(LOC_CASTLE, "Chateau", @"Le chateau du roi des orcs

                 |>>>                        |>>>
                    |                           |
                _  _|_  _                   _  _|_  _
               | |_| |_| |                 | |_| |_| |
               \  .      /                 \ .    .  /
                \    ,  /                   \    .  /
                 | .   |_   _   _   _   _   _| ,   |
                 |    .| |_| |_| |_| |_| |_| |  .  |
                 | ,   | .    .     .      . |    .|
                 |   . |  .     . .   .  ,   |.    |
     ___----_____| .   |.   ,  _______   .   |   , |---~_____
_---~            |     |  .   /+++++++\    . | .   |         ~---_
                 |.    | .    |+++++++| .    |   . |              ~-_
              __ |   . |   ,  |+++++++|.  . _|__   |                 ~-_
     ____--`~    '--~~__ .    |++++ __|----~    ~`---,              ___^~-__
-~--~                   ~---__|,--~'                  ~~----_____-~'   `~----~


            ");


            Location townhall = new Location(LOC_TOWNHALL, "Mairie", @"Quelqu'un peut vous donner des indications ici


        +                           +
       /\                          /\
      /  \                        /  \
     /\/\/\                      /\/\/\
     ||||||                      ||||||
     ::::::                      ::::::
    /,-.,-.\         +          /,-.,-.\
    (|_||_|)         /\         (|_||_|)
   _::____::_        )(        _::____::_
   `+------+'      |'  `|      `+------+'
    |,-.,-.|     __;----:__     |,-.,-.|
    || || ||  ,-'  ,----.  `-.  || || ||
   ,-^-^^-^+,'    ;      :    `.+^-^^-^-.
  ,--^-^-+`+-^-^-+'-^--^-`+-^-^-+'+-^-^--.
  | |    | |-----||------||-----| |    | |
  | |    | | ,-. ||  ()  || ,-. | |    | |
  | |    | | `-' ||  ii  || `-' | |    | |
  | |    | |_,'._||,||||.||_,'._| |    | |
  | |    | |=====||======||=====| |    | |
  | |    | ||,-.||||,--.||||,-.|| |    | |
  | |    | ||| |||||    ||||| ||| |    | |
  |_|____|_|||_|||||____|||||_|||_|____|_|  


            ");


            Location desert = new Location(LOC_DESERT, "Etendue désertique", @"C'est une mauvaise idée de s'aventurer aussi loin si vous n'êtes pas prêt...


                /||\
                ||||
                ||||                      _____.-..-.
                |||| /|\               .-~@@/ / q  p \
           /|\  |||| |||             .'@ _@/..\-.__.-/
           |||  |||| |||            /@.-~/|~~~`\|__|/
           |||  |||| |||            |'--<||     '~~'
           |||  |||| d||            |>--<\@\
           |||  |||||||/            \>---<\@`\.
           ||b._||||~~'              `\>---<`\@`\.
           \||||||||                   `\>----<`\@`\.
            `~~~||||               _     `\>-----<`\@`\.
                ||||              (_)      `\>-----<`\.@`\.
                ||||              (_)        `\>------<`\.@`\.
~~~~~~~~~~~~~~~~||||~~~~~~~~~~~~~~(__)~~~~~~~~~`\>-------<`\.@`\~~~~~~~~~~~~~
  \/..__..--  . |||| \/  .  ..____( _)@@@--..____\..--\@@@/~`\@@>-._   \/ .
\/         \/ \/    \/     / - -\@@@@--@/- - \@@@/ - - \@/- -@@@@/- \.   --._
   .   \/    _..\/-...--.. |- - -\@@/ - -\@@@@/~~~~\@@@@/- - \@@/- - |   .\/
        .  \/              | - - -@@ - - -\@@/- - - \@@/- - - @@- - -|      .
. \/             .   \/     ~-.__ - - - - -@@- - - - @@- - - - -__.-~  . \/
   __...--..__..__       .  \/   ~~~--..____- - - - -____..--~~~    \/_..--..
\/  .   .    \/     \/    __..--... \/      ~~~~~~~~~     \/ . \/  .


            ");




            worldLocations.Add(home);
            worldLocations.Add(chapel);
            worldLocations.Add(castle);
            worldLocations.Add(townhall);
            worldLocations.Add(desert);


            home.itemInLocation = GetItem(ITEM_HEALTH_POTION);
            townhall.itemInLocation = GetItem(ITEM_MEDIUM_HEALTH_POTION);

            chapel.enemyInLocation = GetEnemy(ENEMY_HERETIC);
            castle.enemyInLocation = GetEnemy(ENEMY_ORC);
            desert.enemyInLocation = GetEnemy(ENEMY_BIGSNAKE);



            // map logics, cf. dessin map pour réstituer la disposition

            home.northLocation = desert;
            home.southLocation = chapel;
            home.eastLocation = townhall;
            home.westLocation = castle;


            chapel.northLocation = home;


            castle.eastLocation = home;


            // townhall.northLocation = ;
            // townhall.southLocation = ;
            // townhall.eastLocation = ;
            townhall.westLocation = home;

            // desert.northLocation = ;
            desert.southLocation = home;
            // desert.eastLocation = ;
            // desert.westLocation = ;

        }
    }
}