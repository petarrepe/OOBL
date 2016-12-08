using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOBL
{
    public class Account
    {
        public AccountManager.AccountTypes typeOfAccount;
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

        internal string ShowOptions()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var entry in optionsWithCode)
            {
                sb.AppendLine(string.Format("{0, -30}",entry.Key) + " " + entry.Value);
            }

            return sb.ToString();
        }
    }
}
