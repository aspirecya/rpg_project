using System;
namespace projet_RPG {
    public class Potion : Item {

        public enum PotionType { heal, defense, attack };
        public PotionType type;
        public int statBoost;

        public Potion(int id, string name, string desc, float value, PotionType type, int statBoost) : base(id, name, desc, value) {
            this.type = type;
            this.statBoost = statBoost;
        }
    }
}
