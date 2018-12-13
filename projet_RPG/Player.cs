using System;
namespace projet_RPG {
    public class Player {
        public string name { get; }
        public string p_class;
        public float hp { get; set; }
        public int str { get; set; }
        public int sta { get; set; }
        public int def { get; set; }
        public int magic { get; set; }

        public Player() {
        }



        public override string ToString()
        {
            return "NAME: " + this.name +
                   " JOB: " + this.p_class +
                   " HP: " + this.hp +
                   " STR: " + this.str +
                   " STA: " + this.sta +
                   " DEF: " + this.def;

        }
    }
}
