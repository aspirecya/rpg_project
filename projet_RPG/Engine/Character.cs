using System;
namespace projet_RPG {
    public abstract class Character {
        public string name;
        public float hp;
        public int str;
        public int sta;
        public int def;
        public int magic;

        public Character(string name) {
            this.name = name;
            this.hp = 100;
            this.str = 1;
            this.sta = 1;
            this.def = 1;
            this.magic = 1;
            this.bag = new Items[10];
        }

        public virtual void Attack(Character target) {
            target.hp -= str;
        }


        public Character CompareStrength(Character h1, Character h2) {
            if(h1.str > h2.str) { return h1; } else { return h2; }
        }

        public override string ToString() {
            return "NAME: " + this.name +
                   " HP: " + this.hp +
                   " STR: " + this.str +
                   " STA: " + this.sta +
                   " DEF: " + this.def;

        }
    }
}
