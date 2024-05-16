using System.Collections;
using System.Collections.Generic;

namespace A1
{
    public class Item
    {
        private string id;
        private string name;
        private string desc;
        private string itemType;
        private bool canStack;
        private int cost;
        private int sellPrice;

        public Item(string id, string name, string desc, string itemType, bool canStack, int cost, int sellPrice)
        {
            this.id = id;
            this.name = name;
            this.desc = desc;
            this.itemType = itemType;
            this.canStack = canStack;
            this.cost = cost;
            this.sellPrice = sellPrice;
        }

        public string GetId()
        {
            return id;
        }

        public string GetName()
        {
            return name;
        }

        public string GetDesc()
        {
            return desc;
        }

        public string GetItemType()
        {
            return itemType;
        }

        public bool GetCanStack()
        {
            return canStack;
        }

        public int GetCost()
        {
            return cost;
        }

        public int GetSellPrice()
        {
            return sellPrice;
        }

        public virtual string GetStatString()
        {
            return "";
        }
    }
}