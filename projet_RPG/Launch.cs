using System;
namespace projet_RPG {
    public class Launch {
        public static void Main(string[] args) {
            Console.WriteLine("test:");
            Fighter c1 = new Fighter("Yo");
            Console.WriteLine(c1.ToString());
        }
    }
}
