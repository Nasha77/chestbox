using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace A1
{
    public class ChestScript : MonoBehaviour
    {
        public string chestSetId;
        private A1Controller gameController;
        private List<ChestItem> chestItemList;

        public void SetupChest(A1Controller controller)
        {
            gameController = controller;
            chestItemList = Game.GetChestItemSet(chestSetId);
        }

        public void OnMouseDown()
        {
            //when chest is clicked
            if (!EventSystem.current.IsPointerOverGameObject() && chestItemList.Count > 0)
            {
                //randomize a ChestItem in the list
                int randomIndex = Random.Range(0, chestItemList.Count);
                ChestItem chestItem = chestItemList[randomIndex];

                //Task 4a: Get item from chest
                //Call your function in A1Controller to add the randomly selected items from the chest to player inventory.
                //You can check the ChestItem class to see what fields are accessible.
                //TASK 4a START

                //TASK 4a END
            }
        }
    }
}