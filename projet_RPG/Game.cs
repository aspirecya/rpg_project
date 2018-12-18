using System;
using projet_RPG.Engine;

namespace projet_RPG
{
    public class Game
    {
        private static Player player;
        private Enemy enemyToFight;


        public static void Main(string[] args)
        {
            Introduction();

            Console.WriteLine("Tapez 'aide' pour voir la liste des commandes");
            Console.WriteLine("");

            ShowCurrentLocation();

            while (true) {
                Console.Write(">");
                
                string input = Console.ReadLine();

                if (input == null) {
                    continue;
                }

                // on convertis juste le input en minuscule pour faciliter la vie
                string action = input.ToLower();
                
                if (action == "quitter") {
                    Environment.Exit(0);
                }

                // If the user typed something, try to determine what to do
                PlayerAction(action);
            }

        }

        private static void PlayerAction(string input)
        {
            if (input.Contains("aide") || input == "?")
            {
                ShowHelp();
            }
            else if (input == "stats")
            {
                ShowPlayerStats();
            }
            else if (input == "regarder")
            {
                ShowCurrentLocation();
            }
            else if (input.Contains("nord"))
            {
                if (player.playerLocation.northLocation == null)
                {
                    Console.WriteLine("Impossible d'aller vers le nord");
                }
                else
                {
                    player.GoNorth();
                    ShowCurrentLocation();
                }
            }
            else if (input.Contains("est"))
            {
                if (player.playerLocation.eastLocation == null)
                {
                    Console.WriteLine("Impossible d'aller vers l'est");
                }
                else
                {
                    player.GoEast();
                    ShowCurrentLocation();
                }
            }
            else if (input.Contains("sud"))
            {
                if (player.playerLocation.southLocation == null)
                {
                    Console.WriteLine("Impossible d'aller vers le sud");
                }
                else
                {
                    player.GoSouth();
                    ShowCurrentLocation();
                }
            }
            else if (input.Contains("ouest"))
            {
                if (player.playerLocation.eastLocation == null)
                {
                    Console.WriteLine("Impossible d'aller vers l'ouest");
                }
                else
                {
                    player.GoWest();
                    ShowCurrentLocation();
                }
            }
            else if (input == "inventaire")
            {
                foreach (ItemInInventory inventoryItem in player.playerInventory)
                {
                    Console.WriteLine("{0}: {1}", inventoryItem.item.name, inventoryItem.quantity);
                }
            }
            else if (input.Contains("attaquer") || input.Contains("attaque"))
            {
                // AttackMonster();
            }
            else if (input.StartsWith("equip "))
            {
                // EquipWeapon(input);
            }
            else if (input.StartsWith("drink "))
            {
                // DrinkPotion(input);
            }
            else
            {
                Console.WriteLine("Commande incorrecte");
                Console.WriteLine("Tapez 'aide' pour voir la liste des commandes");
            }

            // Write a blank line, to keep the UI a little cleaner
            Console.WriteLine("");
        }


        internal static void Introduction()
        {
            Console.WriteLine("Vous vous reveillez... quel est votre nom?");
            player = Player.MakeStartingPlayer(Console.ReadLine());

        }

        static void ShowCurrentLocation()
        {
            Console.WriteLine("Vous êtes actuellement {0}", player.playerLocation.name);

            if (player.playerLocation.desc != "")
            {
                Console.WriteLine(player.playerLocation.desc);
            }
        }

        private static void ShowHelp()
        {
            Console.WriteLine("Commandes:");
            Console.WriteLine("stats");
            Console.WriteLine("regarder");
            Console.WriteLine("inventaire");
            Console.WriteLine("attaque(r)");
            Console.WriteLine("Equip <weapon name> - Set your current weapon");
            Console.WriteLine("Drink <potion name> - Drink a potion");
            Console.WriteLine("nord");
            Console.WriteLine("sud");
            Console.WriteLine("est");
            Console.WriteLine("ouest");
            Console.WriteLine("quitter");
        }

        static void ShowPlayerStats()
        {
            Console.WriteLine("{0}", player.name);
            Console.WriteLine("HP: {0}/{1}", player.hp, player.maxhp);
            Console.WriteLine("STR: {0}\tDEF: {1}\tMAGIC: {2}", player.str, player.def, player.magic);
            Console.WriteLine("LEVEL: {0}\tEXP: {1}", player.Level, player.exp);
            Console.WriteLine("GOLD: {0}", player.gold);
        }

        // TODO: faire déplacement() -> get la case, tester le contenu, faire le traitement (combat, pickup...etc)
        // TODO: startgame()
    }
}