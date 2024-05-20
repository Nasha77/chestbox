using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A1
{
    public class ChestItem
    {
        private string id;
        private string setId;
        private string itemId;
        private int itemCount;

        public ChestItem(string id, string setId, string itemId, int itemCount) 
        {
            this.id = id;
            this.setId = setId;
            this.itemId = itemId;
            this.itemCount = itemCount;
        }

        public string GetSetId()
        {
            return setId;
        }

        public string GetItemId()
        {
            return itemId;
        }

        public int GetItemCount()
        {
            return itemCount;
        }
    }
}