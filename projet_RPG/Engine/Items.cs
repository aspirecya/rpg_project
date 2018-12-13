using System;
namespace projet_RPG {
    public abstract class Items {
        public string name;
        public string desc;
        public float value;
        public float weight;

        public Items(string name, string desc, float value, float weight) {
            this.name = name;
            this.desc = desc;
            this.value = value;
            this.weight = weight;
        }

        public virtual void Pickup() {}

        public virtual void Use() {}
    }
}
