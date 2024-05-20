using System.Collections;
using System.Collections.Generic;

namespace A1
{
    public class PlayerItem
    {
        private string inventoryId;
        private string itemId;
        private int count;

        public PlayerItem(string inventoryId, string itemId, int initCount)
        {
            this.inventoryId = inventoryId;
            this.itemId = itemId;
            this.count = initCount;
        }

        public string GetInventoryId()
        {
            return inventoryId;
        }

        public string GetItemId()
        {
            return itemId;
        }

        public int GetCount()
        {
            return count;
        }

        public void SetCount(int amt)
        {
            count = amt;
        }

        public void AddCount(int amt)
        {
            count += amt;
        }

        public void ReduceCount(int amt)
        {
            count -= amt;
        }

        public bool CheckCount(int amt)
        {
            //returns true if count is more than or equal to amt
            return count >= amt;
        }
    }
}