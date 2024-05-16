using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace A1
{
    public class MenuBase : MonoBehaviour
    {
        protected A1Controller gameController;

        public virtual void SetupUI(A1Controller controller)
        {
            gameController = controller;

            //Task 1a: Add UI script to controller
            gameController.AddUIScript(this);

            //Call a function in A1Controller to add this script to the list of current UI scripts.
            //This function is called when a UI is opened.
            //TASK 1a START

            //TASK 1a END
        }

        public virtual void CloseUI()
        {
            //Task 1b: Remove UI script from controller
            //Call a function in A1Controller to add this script to the list of current UI scripts.
            //This function is called when a UI is closed.
            //TASK 1b START

            //TASK 1b END

            Destroy(this.gameObject);
        }

        public virtual void UpdateUI(params string[] input)
        {

        }

        public void ProcessClick(GameObject clickObj)
        {
            ProcessClickName(clickObj.name);
        }

        public virtual void ProcessClickName(string clickName)
        {

        }
    }
}

