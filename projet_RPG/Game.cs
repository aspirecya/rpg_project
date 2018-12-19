using System;
using projet_RPG.Engine;

namespace projet_RPG {
    public class Game {
        private static Player player;

        public static void Main(string[] args) {
            Introduction();

            Console.WriteLine("Tapez 'aide' pour voir la liste des commandes");
            Console.WriteLine("");

            ShowCurrentLocation();

            while (true) {
                Console.Write("+");
                string input = Console.ReadLine();

                if (input == null) {
                    continue;
                }

                // on convertis l'input en minuscule pour faciliter la vie lors des comparaisons dans la logique PlayerAction()
                string action = input.ToLower();
                
                if (action == "quitter") {
                    Environment.Exit(0);
                }

                PlayerAction(action);
            }

        }

        private static void PlayerAction(string input) {
            if (input.Contains("nord")) {
                if (player.playerLocation.northLocation == null) {
                    Console.WriteLine("Impossible d'aller vers le nord");
                }
                else {
                    player.GoNorth();
                    ShowCurrentLocation();
                }
            }
            else if (input.Contains("est")) {
                if (player.playerLocation.eastLocation == null) {
                    Console.WriteLine("Impossible d'aller vers l'est");
                }
                else {
                    player.GoEast();
                    ShowCurrentLocation();
                }
            }
            else if (input.Contains("sud")) {
                if (player.playerLocation.southLocation == null) {
                    Console.WriteLine("Impossible d'aller vers le sud");
                }
                else {
                    player.GoSouth();
                    ShowCurrentLocation();
                }
            }
            else if (input.Contains("ouest")) {
                if (player.playerLocation.westLocation == null) {
                    Console.WriteLine("Impossible d'aller vers l'ouest");
                }
                else {
                    player.GoWest();
                    ShowCurrentLocation();
                }
            }
            else if (input.Contains("aide") || input == "?") {
                ShowHelp();
            }
            else if (input == "stats") {
                ShowPlayerStats();
            }
            else if (input == "regarder" || input == "voir") {
                ShowCurrentLocation();
            }
            else if (input == "ennemi") {
                if (player.currentEnemy == null) {
                    Console.WriteLine("Vous n'avez aucun ennemi en face de vous.");
                }
                else {
                    ShowPlayerEnemy();
                }
            }
            else if (input == "ramasser") { 
                if (!player.playerLocation.HasAnItem) {
                    Console.WriteLine("Il n'y a rien a ramasser");
                }
                else {
                    player.AddItemToInventory(player.playerLocation.itemInLocation);
                    player.playerLocation.RemoveItemFromLocation();
                    Console.WriteLine("Vous ramassez l'objet au sol et le mettez dans votre sac.");
                }
            }
            else if (input.Contains("arme")) {
                ShowPlayerWeapons();
            }
            else if (input.Contains("potion")) {
                ShowPlayerPotions();
            }
            else if (input == "inventaire" || input.Contains("inv")) {
                foreach (ItemInInventory inventoryItem in player.playerInventory) {
                    Console.WriteLine("{0}: {1}", inventoryItem.item.name, inventoryItem.quantity);
                }
            }
            else if (input.Contains("attaquer") || input == "attaque") {
                AttackMonster();
            }
            else if (input.StartsWith("equiper ") || input == "equiper") {
                EquipWeapon(input);
            }
            else if (input.StartsWith("boire ") || input == "boire" ) {
                DrinkPotion(input);
            }
            else if (input == "clear") {
                Console.Clear();
            }
            else if (input == "cheat") {
                player.AddExperience(1000);
            }
            else {
                Console.WriteLine("Commande incorrecte");
                Console.WriteLine("Tapez 'aide' pour voir la liste des commandes");
            }


            Console.WriteLine("");
        }

        static void Introduction() {
            Console.WriteLine("Vous vous reveillez... quel est votre nom?");
            player = Player.MakeStartingPlayer(Console.ReadLine());

        }

        static void AttackMonster() { 
            if (!player.playerLocation.HasAnEnemy) {
                Console.WriteLine("Il y a rien a attaquer ici");
            }
            else if (player.currentWeapon == null) {
                Console.WriteLine("Attaquer avec vos poings semble être une mauvaise idée...équipez une arme.");
                ShowPlayerWeapons();
            }
            else {
                player.Attack(player.currentWeapon);
            }
        }

        static void EquipWeapon(string input)
        {
            string id = input.Substring(7).Trim();

            if (!int.TryParse(id, out int weaponID)) {
                Console.WriteLine("Aucun ID d'arme reconnu.");
                ShowPlayerWeapons();
            }
            else {
                player.Equip(weaponID);
            }
        }

        static void DrinkPotion(string input) {
            string id = input.Substring(5).Trim();

            if(!int.TryParse(id, out int potionID)) {
                Console.WriteLine("Aucun ID de potion reconnu.");
                ShowPlayerPotions();
            }
            else {
                player.Drink(potionID);
            }
        }

        static void ShowCurrentLocation() {
            Console.WriteLine("{0}", player.playerLocation.name);

            if (player.playerLocation.desc != "") {
                Console.WriteLine(player.playerLocation.desc);
            }
            if (player.playerLocation.HasAnItem) {
                Console.WriteLine("Vous voyez {0} au sol...", player.playerLocation.itemInLocation.name);
            }
            if (player.playerLocation.HasAnEnemy) {
                Console.WriteLine("Vous voyez un {0} bouger au loin...", player.playerLocation.enemyInLocation.name);
                ShowPlayerEnemy();
            }
        }

        public static void ShowPlayerWeapons() {
            Console.WriteLine("Armes dans l'inventaire:");
            foreach (Weapon w in player.playerWeapons) {
                Console.WriteLine("(ID:{0}) - {1}", w.id, w.name);
            }
        }

        public static void ShowPlayerPotions() {
            Console.WriteLine("Potions dans l'inventaire:");
            foreach (Potion p in player.playerPotions) {
                Console.WriteLine("(ID:{0}) - {1}", p.id, p.name);
            }
        }

        static void ShowPlayerEnemy() {
            Console.WriteLine("{0}", player.currentEnemy.name);
            Console.WriteLine("HP: {0}", player.currentEnemy.hp);
            Console.WriteLine("DMG: {0}-{1}", player.currentEnemy.minDmg, player.currentEnemy.maxDmg);
        }

        private static void ShowHelp() {
            Console.WriteLine("Commandes:");
            Console.WriteLine("stats\t\tregarder\tennemi");
            Console.WriteLine("inventaire\tattaque(r)");
            Console.WriteLine("armes\t\tpotions");
            Console.WriteLine("equiper <idarme>\t\tboire <idpotion>");
            Console.WriteLine("nord\tsud");
            Console.WriteLine("ouest\test");
            Console.WriteLine("quitter");
        }

        static void ShowPlayerStats() {
            Console.WriteLine("{0}", player.name);
            Console.WriteLine("HP: {0}/{1}", player.hp, player.maxhp);
            Console.WriteLine("STR: {0}\tDEF: {1}\tMAGIC: {2}", player.str, player.def, player.magic);
            Console.WriteLine("LVL: {0}\tEXP: {1}\tGOLD: {2}", player.level, player.exp, player.gold);
            if(player.currentWeapon != null) {
                Console.WriteLine("ARME EQUIPEE: {0}", player.currentWeapon.name);
            }
        }
    }
}