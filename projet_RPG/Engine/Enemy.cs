using System;
using projet_RPG.Engine;

namespace projet_RPG.Engine {
    public abstract class Enemy {
        public string name;
        public float hp;
        public int str;
        public int def;
        public int goldReward;
        public int expReward;

        public Enemy(string name, float hp, int str, int def, int goldReward, int expReward)
        {
            this.name = name;
            this.hp = hp;
            this.str = str;
            this.def = def;
            this.goldReward = goldReward;
            this.expReward = expReward;
        }
    }
}
