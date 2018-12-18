using System;
using System.Collections.Generic;
using projet_RPG.Engine;

namespace projet_RPG {
    public class Player : Character {
        public List<ItemInInventory> playerInventory;
        public Location playerLocation;
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
            player.playerLocation = WorldInit.GetLocation(WorldInit.L_START_ZONE);

            return player;
        }

        public void GoTo(Location location) {
            playerLocation = location;
            // SetTheCurrentMonsterForTheCurrentLocation(location);
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

        public void AddItemToInventory(Item itemToAdd) {
            foreach (ItemInInventory itemInInv in playerInventory) {
                if (itemInInv.item.id == itemToAdd.id) {
                    itemInInv.quantity++;
                    return; // on veut sortir de la fonction car les traitements sont faits
                }
            }
            playerInventory.Add(new ItemInInventory(itemToAdd, 1));
        }

        public void RemoveItemFromInventory(Item itemToRemove, int quantity = 1) {
            foreach (ItemInInventory itemInInv in playerInventory) { 
                if (itemInInv.item.id == itemToRemove.id) {
                    itemInInv.quantity--;
                    if(itemInInv.quantity == 0) {
                        playerInventory.Remove(itemInInv);
                    }
                }
            }
        }

        public void AddExperience(int expToAdd) {
            exp += expToAdd;
            maxhp = (level * 10);
        }

        public void Heal(float hpToHeal) {
            hp += hpToHeal;
        }

        public void FullHeal() {
            hp = maxhp;
        }
    }
}
