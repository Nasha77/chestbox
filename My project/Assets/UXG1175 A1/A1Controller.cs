using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A1
{
    public class A1Controller : MonoBehaviour
    {
        public List<Object> uiPrefabList;
        public Transform uiCanvas;

        [SerializeField]
        private List<string> initialUIList;

        [SerializeField]
        private List<Item> itemObjList;

        private List<MenuBase> uiList;

        // Start is called before the first frame update
        void Start()
        {
            Game.SetPlayer(new Player("1", 100));

            //Add items to shop and to chests
            MakeDatabase();

            uiList = new List<MenuBase>();

            //Load initial UI prefabs 
            foreach (string initUI in initialUIList)
            {
                LoadUIPrefab(initUI);
            }

            //Setup all chest scripts
            foreach (ChestScript chest in FindObjectsOfType<ChestScript>())
            {
                chest.SetupChest(this);
            }
        }

        public void MakeDatabase()
        {
            List<Item> itemList = new List<Item>();

            itemList.Add(new Potion("1001", "Health Potion I", "Weak HP potion.", 10, 7, "HP", 10));
            itemList.Add(new Weapon("2001", "Wooden Sword", "Beware of splinters.", 30, 20, 8));

            //Task 5a: Add more items to the item list for the shop.
            //Add at least 2 more of each type of item to the list.
            //Check the Weapon and Potion classes for the fields needed for the constructors.
            //If the task in MyItem script is attempted, 2 items of that type should be added as well.
            //The items should all be added to the same itemList.
            //TASK START

            //TASK END

            Game.SetItemList(itemList);

            List<ChestItem> chestItemList = new List<ChestItem>();

            //chest 11
            chestItemList.Add(new ChestItem("11001", "11", "1001", 1));
            chestItemList.Add(new ChestItem("11002", "11", "1001", 2));
            chestItemList.Add(new ChestItem("11003", "11", "1001", 3));

            //chest 12
            chestItemList.Add(new ChestItem("12001", "12", "1001", 2));
            chestItemList.Add(new ChestItem("12002", "12", "2001", 1));

            //chest 13
            chestItemList.Add(new ChestItem("13001", "13", "2001", 1));

            //Task 5b: Add more chests.
            //Add at least 1 more chest with existing and new items added to them.
            //At least 1 added chest should contain more than 1 item.
            //Check the ChestItem class for the fields needed for the constructor.
            //The chest items should all be added to the same chestItemList.
            //Also add new chest GameObjects using your newly added chests in A1Scene as child objects to ChestRoot.
            //Refer to existing chest GameObjects in the scene to see how to use the ChestScript.
            //TASK 5b START

            //TASK 5b END

            Game.SetChestItemList(chestItemList);
        }

        public void LoadUIPrefab(string uiPrefabName)
        {
            //Find UI prefab reference in prefab list
            Object uiPrefab = uiPrefabList.Find(x => x.name == uiPrefabName);

            if (uiPrefab != null)
            {
                //instantiate UI prefab
                GameObject uiObj = Instantiate(uiPrefab, uiCanvas) as GameObject;
                uiObj.name = uiPrefabName;
                uiObj.GetComponent<MenuBase>().SetupUI(this);
            }
        }

        public void AddUIScript(MenuBase uiBase)
        {
            //add script to UI list
            uiList.Add(uiBase);
        }

        public void RemoveUIScript(MenuBase uiBase)
        {
            //remove UI script when menu closed
            uiList.Remove(uiBase);
        }

        public void UpdateAllUI(params string[] input)
        {
            //Task 1c: Update UI scripts.
            //Update all UI by running UpdateUI function on all UI scripts (HUDScript, ShopMenu, PlayerMenu).
            //TASK 1c START

            //TASK 1c END
        }

        public void ToggleMenu(string menuName)
        {
            //Find menu script
            MenuBase menuScript = uiList.Find(x => x.name == menuName);
            if (menuScript != null)
            {
                //close menu if open
                menuScript.CloseUI();
            }
            else
            {
                //open menu if closed
                LoadUIPrefab(menuName);
            }
        }

        //Task 3b: Write functions to buy, sell and get items
        //You may write multiple functions to buy/sell/get single and multiple items,
        //or write a single function that can work for single or multiple items.
        //Use the functions you have written in Player class to add and remove items,
        //as well as AddMoney and ReduceMoney functions as needed.
        //When items are bought/sold/gotten from chests, call UpdateAllUI function
        //to display a message to show messages in the action log.
        //Refer to the document for details on what messages should be shown.
        //TASK 3b START

        //TASK 3b END
    }
}