using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace A1
{
    public class PlayerMenu : MenuBase
    {
        [SerializeField]
        private TextMeshProUGUI pageText, selectionText;
        [SerializeField]
        private List<Button> itemButtonList;
        [SerializeField]
        private Button sellButton, sell5Button;

        [SerializeField]
        protected Button leftButton, rightButton;

        protected int page;
        protected int totalPages;
        protected int currentSelection;

        private List<PlayerItem> playerItemList;

        public override void SetupUI(A1Controller controller)
        {
            //retrieve player item list to display
            playerItemList = Game.GetPlayer().GetPlayerItemList();

            //calculate total pages
            totalPages = Mathf.Max(1, Mathf.CeilToInt((float) playerItemList.Count / (float) itemButtonList.Count));
            page = 1;

            base.SetupUI(controller);

            UpdateUI();
        }

        public override void UpdateUI(params string[] input)
        {
            playerItemList = Game.GetPlayer().GetPlayerItemList();
            totalPages = Mathf.Max(1, Mathf.CeilToInt((float)playerItemList.Count / (float)itemButtonList.Count));
            UpdatePage(0);
        }

        public void UpdatePage(int dir)
        {
            //navigate page
            if (dir < 0)
            {
                page -= 1;
                currentSelection = 0;
            }
            else if (dir > 0)
            {
                page += 1;
                currentSelection = 0;
            }

            //if out of page range
            if (page > totalPages)
            {
                page = totalPages;
                currentSelection = 0;
            }

            //update page buttons
            leftButton.interactable = (page > 1);
            rightButton.interactable = (page < totalPages);

            ShowPage();
            UpdateSelection();
        }

        public override void ProcessClickName(string clickName)
        {
            switch (clickName)
            {
                case "Left_button":
                    {
                        UpdatePage(-1);
                    }
                    break;
                case "Right_button":
                    {
                        UpdatePage(1);
                    }
                    break;
                case "Sell1_button":
                    {
                        //sell 1
                        int itemIndex = (page - 1) * itemButtonList.Count + currentSelection;

                        //Task 4d: Sell 1 item.
                        //Call a function you wrote in A1Controller to sell 1 of the selected item.
                        //The item is playerItemList[itemIndex].
                        //TASK 4d START

                        //TASK 4d END
                    }
                    break;
                case "Sell5_button":
                    {
                        //sell 5
                        int itemIndex = (page - 1) * itemButtonList.Count + currentSelection;

                        //Task 4e: Sell 5 items.
                        //Call a function you wrote in A1Controller to sell 5 of the selected item.
                        //The item is playerItemList[itemIndex].
                        //TASK 4e START

                        //TASK 4e END
                    }
                    break;
                default:
                    {
                        string[] nameSplit = clickName.Split('_');
                        switch (nameSplit[0])
                        {
                            case "Item":
                                {
                                    SelectItem(int.Parse(nameSplit[1]) - 1);
                                }
                                break;
                        }
                    }
                    break;
            }
        }

        private void SelectItem(int selectIndex)
        {
            currentSelection = selectIndex;

            UpdateSelection();
        }

        private void ShowPage()
        {
            Player player = Game.GetPlayer();

            //show buttons
            for (int i = 0; i < itemButtonList.Count; i++)
            {
                int itemIndex = (page - 1) * itemButtonList.Count + i;
                if (playerItemList.Count > itemIndex)
                {
                    //index exists, show item
                    PlayerItem playerItem = playerItemList[itemIndex];
                    Item item = Game.GetItemByRefId(playerItem.GetItemId());

                    if (item.GetCanStack())
                    {
                        itemButtonList[i].GetComponentInChildren<TextMeshProUGUI>().text = item.GetName() + "\nx" + playerItem.GetCount();
                    }
                    else
                    {
                        itemButtonList[i].GetComponentInChildren<TextMeshProUGUI>().text = item.GetName();
                    }

                    itemButtonList[i].interactable = true;
                }
                else
                {
                    //no such index
                    itemButtonList[i].GetComponentInChildren<TextMeshProUGUI>().text = "-";
                    itemButtonList[i].interactable = false;
                }
            }

            pageText.text = "(Page " + page + "/" + totalPages + ")";
        }

        private void UpdateSelection()
        {
            int itemIndex = (page - 1) * itemButtonList.Count + currentSelection;
            if (playerItemList.Count > itemIndex)
            {
                //item exists
                PlayerItem playerItem = playerItemList[itemIndex];
                Item item = Game.GetItemByRefId(playerItem.GetItemId());

                //show selection text
                selectionText.text = "Name: " + item.GetName();
                selectionText.text += "\n<i>" + item.GetDesc() + "</i>";
                selectionText.text += "\n" + item.GetStatString();

                //Task 2: Update Sell buttons
                //Edit the Sell 1 and Sell 5 buttons such that they display differently
                //if the item can be sold in bulk and if the player has enough items to be sold.
                //Use relevant functions in Item/Potion/Weapon/PlayerItem classes to get the information needed.
                //Refer to the assignment document for details about how the display should look.
                //TASK 2 START

                //show sell button
                sellButton.interactable = true;
                sellButton.GetComponentInChildren<TextMeshProUGUI>().text = "Sell 1 ($" + item.GetSellPrice() + ")";

                //hide sell 5 button
                sell5Button.gameObject.SetActive(false);

                //TASK 2 END

                //show item button selected states 
                for (int i = 0; i < itemButtonList.Count; i++)
                {
                    itemButtonList[i].GetComponent<Outline>().enabled = currentSelection == i;
                }
            }
            else
            {
                //no item selected
                selectionText.text = "";

                sellButton.interactable = false;
                sellButton.GetComponentInChildren<TextMeshProUGUI>().text = "Sell 1";

                sell5Button.gameObject.SetActive(true);
                sell5Button.interactable = false;
                sell5Button.GetComponentInChildren<TextMeshProUGUI>().text = "Sell 5";

                for (int i = 0; i < itemButtonList.Count; i++)
                {
                    itemButtonList[i].GetComponent<Outline>().enabled = false;
                }
            }
        }
    }
}