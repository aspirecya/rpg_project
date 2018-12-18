using System;
using projet_RPG.Engine;

namespace projet_RPG.Engine {
    public class ItemInInventory {

        public Item item;
        public int quantity;

        public ItemInInventory(Item item, int quantity) {
            this.item = item;
            this.quantity = quantity;
        }
    }
}
