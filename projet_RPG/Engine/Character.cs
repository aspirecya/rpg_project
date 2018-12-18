using System;
using projet_RPG.Engine;

namespace projet_RPG {
    public abstract class Character {
        public string name;
        public float maxhp;
        public float hp;
        public int str;
        public int def;
        public int magic;

        public Character(string name) {
            this.name = name;
            this.maxhp = 10;
            this.hp = 10;
            this.str = 1;
            this.def = 1;
            this.magic = 1;
        }

        public void Attack(Character target) {
            target.hp -= str;
        }

        public bool isDead() {
            return hp <= 0;
        }

        public Character CompareStrength(Character h1, Character h2) {
            if(h1.str > h2.str) { return h1; } else { return h2; }
        }
    }
}
