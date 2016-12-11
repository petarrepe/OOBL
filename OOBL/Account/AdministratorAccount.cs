namespace OOBL
{
    class AdministratorAccount : Account
    {
        public AdministratorAccount()
        {
            this.typeOfAccount = AccountManager.AccountTypes.Administrator;
        }
    }
}
