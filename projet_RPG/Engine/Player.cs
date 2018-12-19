using System;
using System.Linq;
using System.Collections.Generic;
using projet_RPG.Engine;

namespace projet_RPG {
    public class Player : Character {
        public List<ItemInInventory> playerInventory;
        public List<Weapon> playerWeapons { get { return playerInventory.Where(invItem => invItem.item is Weapon).Select(invItem => invItem.item as Weapon).ToList(); } }
        public List<Potion> playerPotions { get { return playerInventory.Where(invItem => invItem.item is Potion).Select(invItem => invItem.item as Potion).ToList(); } }
        public List<Item> playerItems { get { return playerInventory.Where(invItem => invItem.item is Item).Select(invItem => invItem.item as Item).ToList(); } }
        public Location playerLocation;
        public Weapon currentWeapon;
        public Enemy currentEnemy;
        public int gold;
        public int exp;
        public int level { get { return ((exp / 100) + 1); } }

        public Player(string name) : base(name) {
            this.gold = 0;
            this.exp = 0;
            playerInventory = new List<ItemInInventory>();
        }

        public static Player MakeStartingPlayer(string name)
        {
            Player player = new Player(name);
            Weapon defaultWeapon = WorldInit.GetWeapon(WorldInit.I_WOODEN_SWORD);
            player.currentWeapon = defaultWeapon;
            player.playerLocation = WorldInit.GetLocation(WorldInit.L_START_ZONE);

            return player;
        }

        public void AssignThisLocationsEnemy(Location location) {
            currentEnemy = location.enemyInLocation;
        }

        public void GoTo(Location location) {
            playerLocation = location;
            AssignThisLocationsEnemy(location);
        }

        public void GoNorth() {
            if (playerLocation.northLocation != null) {
                GoTo(playerLocation.northLocation);
            }
        }

        public void GoEast() {
            if (playerLocation.eastLocation != null) {
                GoTo(playerLocation.eastLocation);
            }
        }

        public void GoSouth() {
            if (playerLocation.southLocation != null) {
                GoTo(playerLocation.southLocation);
            }
        }

        public void GoWest() {
            if (playerLocation.westLocation != null) {
                GoTo(playerLocation.westLocation);
            }
        }

        public void Respawn() {
            GoTo(WorldInit.GetLocation(WorldInit.L_START_ZONE));
        }

        public void AddItemToInventory(Item itemToAdd) {
            foreach (ItemInInventory itemInInv in playerInventory) {
                if (itemInInv.item.id == itemToAdd.id) {
                    itemInInv.quantity++;
                    return; // on veut sortir de la fonction car les traitements sont faits
                }
            }
            playerInventory.Add(new ItemInInventory(itemToAdd, 1));
        }

        public void RemoveItemFromInventory(Item itemToRemove) {
            foreach (ItemInInventory itemInInv in playerInventory.ToList()) { 
                if (itemInInv.item.id == itemToRemove.id) {
                    itemInInv.quantity--;
                    if(itemInInv.quantity == 0) {
                        playerInventory.Remove(itemInInv);
                    }
                }
            }
        }

        public void Attack(Weapon weapon) {
            int dmg = RandomNumberGenerator.GenerateNumber(weapon.minDmg, weapon.maxDmg) - def;

            if (dmg == 0) {
                Console.WriteLine("Vous ratez lamentablement votre tentative d'attaque contre {0}...", currentEnemy.name);
            }
            else {
                currentEnemy.hp -= dmg + str;
                Console.WriteLine("Vous infligez {0} points de dégats a {1}, ça pique...", dmg, currentEnemy.name);
            }

            currentEnemy.Attack(this);

            if(currentEnemy.isDead()) {
                Console.WriteLine("Vous avez tuer {0}.\n+{1} EXP\n+{2} GOLD", currentEnemy.name, currentEnemy.expReward, currentEnemy.goldReward);
                AddExperience(currentEnemy.expReward);
                gold += currentEnemy.goldReward;
                currentEnemy = null;
            }
        }

        public void Equip(int id) {
            foreach (Weapon w in playerWeapons) {
                if (w.id == id) {
                    currentWeapon = w;
                    Console.WriteLine("Vous équipez votre {0}", w.name);
                }
                else {
                    Console.WriteLine("Aucun ID d'arme reconnu.");
                    Game.ShowPlayerWeapons();
                }
            }
            Console.WriteLine("Vous n'avez aucune arme.");
        }

        public void Drink(int id) {

            foreach (Potion p in playerPotions) {
                if (p.id == id) {
                    switch (p.type) {
                        case Potion.PotionType.heal:
                            Heal(p.statBoost);
                            RemoveItemFromInventory(p);
                            break;

                            // case Potion.PotionType.attack:
                            //     break;

                            // case Potion.PotionType.defense:
                            //     break;
                    }
                }
                else {
                    Console.WriteLine("Aucun ID de potion reconnu.");
                    Game.ShowPlayerPotions();
                }
            }
            Console.WriteLine("Vous n'avez aucune potion.");
        }

        public void AddExperience(int expToAdd) {
            exp += expToAdd;
            maxhp = (level * 10);
            str = (level * 10);
            def = (level * 10);
            Console.WriteLine("Votre experience augmente... +{0} exp", expToAdd);
        }

        public void Heal(float hpToHeal) {
            hp += hpToHeal;
            Console.WriteLine("Vous sentez votre vitalité grimper... +{0} hp", hpToHeal);
        }

        public void FullHeal() {
            hp = maxhp;
        }
    }
}
