using System;
using projet_RPG.Engine;

namespace projet_RPG {
    public class Game {
        private static Player player;
        private Enemy enemyToFight;

        void movePlayer(Location newPlayerLocation) {
            if(player.playerLocation.northLocation == null || player.playerLocation.southLocation == null || player.playerLocation.eastLocation == null || player.playerLocation.westLocation == null) {

            }
            else if (newPlayerLocation.enemyInLocation != null) {
                Console.WriteLine("You creep slowly in the area and then suddenly... a wild " + newPlayerLocation.enemyInLocation.name + " who wants to destroy you!");

                Enemy enemyInMemory = Init.GetEnemy(newPlayerLocation.enemyInLocation.id);
                enemyToFight = new Enemy(enemyInMemory.id, enemyInMemory.name, enemyInMemory.hp, enemyInMemory.str, enemyInMemory.def, enemyInMemory.goldReward, enemyInMemory.expReward);

            }
        }

        static void gameMenu() {
            Console.WriteLine("1. START GAME \n2. QUIT");
            int choice = int.Parse(Console.ReadLine());

            switch(choice)
            {
                case 1:
                    startGame();
                    break;
                
                case 2:
                    Environment.Exit(0);
                    break;

            }
        }

        static void startGame() {
            Console.WriteLine("Vous vous reveillez... quel est votre nom?");
            player = new Player(Console.ReadLine());

            Console.WriteLine(player.ToString());
        }

        public static void Main(string[] args) {
            gameMenu();
        }

        // TODO: faire déplacement() -> get la case, tester le contenu, faire le traitement (combat, pickup...etc)
        // TODO: startgame()
    }
}
