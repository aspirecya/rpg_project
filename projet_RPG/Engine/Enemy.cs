using System;
using projet_RPG.Engine;

namespace projet_RPG.Engine {
    public class Enemy : Character {
        public int id;
        public int maxDmg;
        public int minDmg;
        public int goldReward;
        public int expReward;

        public Enemy(int id, string name, int maxDmg, int minDmg, int goldReward, int expReward) : base(name) {
            this.id = id;
            this.goldReward = goldReward;
            this.expReward = expReward;
            this.maxDmg = maxDmg;
            this.minDmg = minDmg;
        }
    }
}
