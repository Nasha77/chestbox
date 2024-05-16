using System.Collections;
using System.Collections.Generic;

namespace A1
{
    public class Player
    {
        private string id;
        private int money;
        private List<PlayerItem> playerItemList;
        private int playerItemCount;

        public Player(string id, int initMoney)
        {
            this.id = id;
            this.money = initMoney;
            playerItemList = new List<PlayerItem>();
            playerItemCount = 0;
        }

        public int GetMoney()
        {
            return money;
        }

        public bool CheckMoney(int amt)
        {
            return money >= amt;
        }

        public void AddMoney(int amt)
        {
            money += amt;
        }

        public bool ReduceMoney(int amt)
        {
            //If enough money
            if (money >= amt)
            {
                //Reduce by given amount
                money -= amt;

                //Return operation success
                return true;
            }

            //Money not reduced, return failure
            return false;
        }

        public List<PlayerItem> GetPlayerItemList()
        {
            return playerItemList;
        }

        public int GetPlayerItemCount()
        {
            int total = 0;
            foreach (PlayerItem pItem in playerItemList)
            {
                total += pItem.GetCount(); 
            }

            return total;
        }

        //Task 3a: Write functions to add and remove items for the Player.
        //Write functions to add to and remove from playerItemList.
        //The functions must differentiate between stackable items and non-stackable items.
        //Item IDs should be unique to each stack of items added to the inventory.
        //Use the int playerItemCount variable defined in this class to track the number of items added to the list and generate unique IDs.
        //Note that when removing items, empty stacks should be removed from the list for the display to work correctly.
        //TASK 3a START

        //TASK 3a END
    }
}