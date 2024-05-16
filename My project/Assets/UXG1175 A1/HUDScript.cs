using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace A1
{
    public class HUDScript : MenuBase
    {
        [SerializeField]
        private TextMeshProUGUI playerInfoText, itemGetText;
        [SerializeField]
        private int maxItemGet = 3;

        private List<string> itemGetList = new List<string>();

        public override void SetupUI(A1Controller controller)
        {
            base.SetupUI(controller);

            UpdateUI();
        }

        public override void UpdateUI(params string[] input)
        {
            //update inventory count and money
            playerInfoText.text = "Total Items: " + Game.GetPlayer().GetPlayerItemCount() + "\nMoney: $" + Game.GetPlayer().GetMoney();

            foreach (string inputString in input)
            {
                //add new item message
                itemGetList.Add(inputString);
            }

            UpdateItemGet();
        }

        public override void ProcessClickName(string clickName)
        {
            switch (clickName)
            {
                case "Shop_button":
                    {
                        gameController.ToggleMenu("Shop_panel");
                    }
                    break;
                case "Inventory_button":
                    {
                        gameController.ToggleMenu("Inventory_panel");
                    }
                    break;
            }
        }

        public void UpdateItemGet()
        {
            //remove overflow messages
            if (itemGetList.Count > maxItemGet)
            {
                itemGetList.RemoveRange(0, itemGetList.Count - maxItemGet);
            }

            //show last few messages
            itemGetText.text = "";
            foreach (string itemMsg in itemGetList)
            {
                itemGetText.text += itemMsg + "\n";
            }
        }
    }
}