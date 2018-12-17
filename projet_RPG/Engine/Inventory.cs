using System;
using projet_RPG.Engine;

namespace projet_RPG.Engine {
    public class Inventory {

        public Items item;
        public int quantity;

        public Inventory(Items item, int quantity) {
            this.item = item;
            this.quantity = quantity;
        }
    }
}
