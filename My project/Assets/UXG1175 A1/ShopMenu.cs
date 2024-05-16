using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace A1
{
    public class ShopMenu : MenuBase
    {
        [SerializeField]
        private List<Button> itemButtonList;
        [SerializeField]
        private TextMeshProUGUI pageText, selectionText;
        [SerializeField]
        private Button buyButton, buy5Button;

        [SerializeField]
        protected Button leftButton, rightButton;

        protected int page;
        protected int totalPages;
        protected int currentSelection;

        private List<Item> itemList;

        public override void SetupUI(A1Controller controller)
        {
            //retrieve item list to display
            itemList = Game.GetItemList();

            //calculate total pages
            totalPages = Mathf.Max(1, Mathf.CeilToInt((float)itemList.Count / (float)itemButtonList.Count));
            page = 1;

            base.SetupUI(controller);

            UpdateUI();
        }

        public override void UpdateUI(params string[] input)
        {
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
                case "Buy1_button":
                    {
                        //buy 1
                        int itemIndex = (page - 1) * itemButtonList.Count + currentSelection;

                        //Task 4b: Buy 1 item.
                        //Call a function you wrote in A1Controller to buy 1 of the selected item.
                        //The item is itemList[itemIndex].
                        //TASK 4b START

                        //TASK 4b END
                    }
                    break;
                case "Buy5_button":
                    {
                        //buy 5
                        int itemIndex = (page - 1) * itemButtonList.Count + currentSelection;

                        //Task 4c: Buy 5 items.
                        //Call a function you wrote in A1Controller to buy 5 of the selected item.
                        //The item is itemList[itemIndex].
                        //TASK 4c START

                        //TASK 4c END
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
            //show buttons
            for (int i = 0; i < itemButtonList.Count; i++)
            {
                int itemIndex = (page - 1) * itemButtonList.Count + i;
                if (itemList.Count > itemIndex)
                {
                    //index exists, show item
                    Item item = itemList[itemIndex];
                    itemButtonList[i].GetComponentInChildren<TextMeshProUGUI>().text = item.GetName();
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

            if (itemList.Count > itemIndex)
            {
                //item exists
                Item item = itemList[itemIndex];
                int cost = item.GetCost();

                //show selection text
                selectionText.text = "Name: " + item.GetName() + " (" + item.GetItemType() + ")";
                selectionText.text += "\n<i>" + item.GetDesc() + "</i>";
                selectionText.text += "\n" + item.GetStatString();
                selectionText.text += "\nCost: $" + cost;

                if (!Game.GetPlayer().CheckMoney(cost))
                {
                    //not enough money
                    buyButton.interactable = false;
                    buyButton.GetComponentInChildren<TextMeshProUGUI>().text = "Buy 1 (Not Enough Money)";
                }
                else
                {
                    buyButton.interactable = true;
                    buyButton.GetComponentInChildren<TextMeshProUGUI>().text = "Buy 1 ($" + cost + ")";
                }

                if (!Game.GetPlayer().CheckMoney(cost * 5))
                {
                    //not enough money
                    buy5Button.interactable = false;
                    buy5Button.GetComponentInChildren<TextMeshProUGUI>().text = "Buy 5 (Not Enough Money)";
                }
                else
                {
                    buy5Button.interactable = true;
                    buy5Button.GetComponentInChildren<TextMeshProUGUI>().text = "Buy 5 ($" + (cost * 5) + ")";
                }

                for (int i = 0; i < itemButtonList.Count; i++)
                {
                    itemButtonList[i].GetComponent<Outline>().enabled = currentSelection == i;
                }
            }
            else
            {
                //no item selected
                selectionText.text = "";

                buyButton.interactable = false;
                buyButton.GetComponentInChildren<TextMeshProUGUI>().text = "Buy 1";
                buy5Button.interactable = false;
                buy5Button.GetComponentInChildren<TextMeshProUGUI>().text = "Buy 5";

                for (int i = 0; i < itemButtonList.Count; i++)
                {
                    itemButtonList[i].GetComponent<Outline>().enabled = false;
                }
            }
        }
    }
}