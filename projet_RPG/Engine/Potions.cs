using System;
namespace projet_RPG
{
    public class Potions : Item {

        public enum PotionType { heal, defense, attack };
        public PotionType type;

        public Potions(int id, string name, string desc, float value, float weight, PotionType type) : base(id, name, desc, value, weight) {
            this.type = type;
        }
    }
}
