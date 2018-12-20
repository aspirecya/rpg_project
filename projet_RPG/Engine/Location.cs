using System;
using projet_RPG.Engine;

namespace projet_RPG {
    public class Location {

        public int id;
        public string name;
        public string desc;
        public Enemy enemyInLocation;
        public Item itemInLocation;
        public Location northLocation;
        public Location southLocation;
        public Location eastLocation;
        public Location westLocation;

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//


        public bool HasAnItem { get { return itemInLocation != null; } }
        public bool HasAnEnemy { get { return enemyInLocation != null; } }


        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//

        public Location(int id, string name, string desc,
                        Enemy enemyInLocation = null) {
            this.id = id;
            this.name = name;
            this.desc = desc;
            this.enemyInLocation = enemyInLocation;
        }

        public void RemoveItemFromLocation() {
            this.itemInLocation = null;
        }
    }
}
