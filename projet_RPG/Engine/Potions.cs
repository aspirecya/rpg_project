using System;
namespace projet_RPG
{
    public class Potions : Items {

        public enum PotionType { heal, defense, attack };
        public PotionType type;

        public Potions(string name, string desc, float value, float weight, PotionType type) : base(name, desc, value, weight) {
            this.type = type;
        }
    }
}
