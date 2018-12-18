using System;
using projet_RPG.Engine;

namespace projet_RPG {
    public abstract class Item {
        public int id;
        public string name;
        public string desc;
        public float value;
        public float weight;

        public Item(int id, string name, string desc, float value, float weight) {
            this.id = id;
            this.name = name;
            this.desc = desc;
            this.value = value;
            this.weight = weight;
        }

        public virtual void Pickup() {}

        public virtual void Use() {}
    }
}
