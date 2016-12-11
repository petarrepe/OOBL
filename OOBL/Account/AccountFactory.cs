using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOBL
{
    public static class AccountFactory
    {
        public static Account GetAccount(AccountManager.AccountTypes type)
        {
            switch (type)
            {
                case AccountManager.AccountTypes.Administrator:
                    return new AdministratorAccount();

                case AccountManager.AccountTypes.Regular:
                    return new Account();

                default:
                    throw new NotSupportedException();
            }
        }
    }
}
