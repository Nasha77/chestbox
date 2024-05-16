using System.Collections;
using System.Collections.Generic;

namespace A1
{
    public static class Game
    {
        private static Player player;
        private static List<Item> itemList;
        private static List<ChestItem> chestItemList;

        public static Player GetPlayer()
        {
            return player;
        }

        public static void SetPlayer(Player aPlayer)
        {
            player = aPlayer;
        }

        public static List<Item> GetItemList()
        {
            return itemList;
        }

        public static void SetItemList(List<Item> aList)
        {
            itemList = aList;
        }

        public static Item GetItemByRefId(string refId)
        {
            return itemList.Find(x => x.GetId() == refId);
        }

        public static List<ChestItem> GetChestItemList()
        {
            return chestItemList;
        }

        public static void SetChestItemList(List<ChestItem> aList)
        {
            chestItemList = aList;
        }

        public static List<ChestItem> GetChestItemSet(string setId)
        {
            return chestItemList.FindAll(x => x.GetSetId() == setId);
        }
    }
}