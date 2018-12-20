using System;
namespace projet_RPG.Engine
{
    public class Quest {

        int id;
        string name;
        string desc;
        int expReward;
        int goldReward;
        Item itemreward;

        public Quest(int id, string name, string desc, int expReward, int goldReward, Item itemReward = null) {
            this.id = id;
            this.name = name;
            this.desc = desc;
            this.expReward = expReward;
            this.goldReward = goldReward;
        }
    }
}
