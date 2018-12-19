using System;
namespace projet_RPG.Engine {
    public class Weapon : Item {

        public int minDmg;
        public int maxDmg;

        public Weapon(int id, string name, string desc, float value, int minDmg, int maxDmg) : base(id, name, desc, value) {
            this.minDmg = minDmg;
            this.maxDmg = maxDmg;
        }
    }
}
