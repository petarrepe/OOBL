using System;
using System.Collections.Generic;
using System.Text;

namespace OOBL
{
    public class Account
    {
        private int currentlyChosenAction;
        internal AccountManager.AccountTypes typeOfAccount;
        public bool? ActionRequiresSavingData { get; private set; }
        protected Dictionary<string, int> optionsWithCode = new Dictionary<string, int>()
        {
            {"Kreiraj novi račun" , 1 },
            {"Ispiši izvješće za dan" , 2},
            {"Ispiši izvješće o artiklima" , 3},
            { "Promijeni artikle" , 4},
            { "Poništavanje računa" , 5},
        };

        public Account()
        {
            this.typeOfAccount = AccountManager.AccountTypes.Regular;
        }

        internal virtual string ShowOptions()
        { 
            StringBuilder sb = new StringBuilder();
            foreach (var entry in optionsWithCode)
            {
                sb.AppendLine(string.Format("{0, -30}",entry.Key) + " " + entry.Value);
            }

            return sb.ToString();
        }

        internal void PerformAction()
        {
            IActionState actionState = ActionStateFactory.GetActionState(currentlyChosenAction);
            ActionRequiresSavingData = actionState.PerformOperation();
        }

        internal bool ValidOption(string input)
        {
            int result;
            int.TryParse(input, out result);

            if (result > 0 && result < optionsWithCode.Count + 1) // +1 jer su opcije 1-index
            {
                if (result > 3 && result < 6 && !(this is AdministratorAccount))
                {
                    return false;
                }
                else
                {
                    SetCurrentAction(result);
                    return true;
                }
            }
            else return false;

        }

        private void SetCurrentAction(int result)
        {
            currentlyChosenAction = result;
        }
    }
}
