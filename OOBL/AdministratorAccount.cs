using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOBL
{
    class AdministratorAccount : Account
    {
        public AdministratorAccount()
        {
            this.typeOfAccount = AccountManager.AccountTypes.Administrator;
        }
        //internal override string ShowOptions()
        //{
        //    StringBuilder sb = new StringBuilder();
        //    foreach (var entry in optionsWithCode)
        //    {
        //        sb.AppendLine(entry.Key + " " + entry.Value);
        //    }

        //    return sb.ToString();
        //}
    }
}
