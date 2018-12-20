using System;
using System.Collections.Generic;
using projet_RPG.Engine;

namespace projet_RPG.Engine {
    public class Enemy : Character {
        public int id;
        public int maxDmg;
        public int minDmg;
        public int goldReward;
        public int expReward;
        public List<Item> loot;

        public Enemy(int id, string name, int maxDmg, int minDmg, int goldReward, int expReward) : base(name) {
            this.id = id;
            this.goldReward = goldReward;
            this.expReward = expReward;
            this.maxDmg = maxDmg;
            this.minDmg = minDmg;
            this.loot = new List<Item>();
        }


        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//


        public void Attack(Player p) {
            int dmg = Engine.RandomNumberGenerator.GenerateNumber(minDmg, maxDmg);

            if (dmg == 0) {
                Console.WriteLine("{0} rate lamentablement sa tentative d'attaque contre vous...", name);
            }
            else {
                p.hp -= (dmg - def);
                Console.WriteLine("{0} vous inflige {1} points de dégats...", name, dmg);
            }
        }
    }
}
