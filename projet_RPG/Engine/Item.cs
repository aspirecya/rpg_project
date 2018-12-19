using System;
using projet_RPG.Engine;

namespace projet_RPG {
    public class Item {
        public int id;
        public string name;
        public string desc;
        public float value;

        public Item(int id, string name, string desc, float value) {
            this.id = id;
            this.name = name;
            this.desc = desc;
            this.value = value;
        }
    }
}
