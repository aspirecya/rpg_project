using System;
using System.Collections.Generic;
using projet_RPG.Engine;

namespace projet_RPG {
    public class Player : Character {
        public List<Inventory> playerInventory;
        public Location playerLocation;

        public Player(string name) : base(name) {
            playerInventory = new List<Inventory>();
        }

        public override string ToString()
        {
            return "NAME: " + this.name +
                   " HP: " + this.hp +
                   " STR: " + this.str +
                   " STA: " + this.sta +
                   " DEF: " + this.def;

        }
    }
}
