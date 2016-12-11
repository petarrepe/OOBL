namespace OOBL
{
    public static class AccountManager
    {
        public static bool ValidLogin { get; private set; } = false;
        public static AccountTypes typeOfAccount { get; private set; }
        public enum AccountTypes{
            Administrator,
            Regular
        }
        public static void TryLogin(string password)
        {
            if (password == "0000")
            {
                ValidLogin = true;
                typeOfAccount = AccountTypes.Administrator;
            }

            else if (password == "1234")
            {
                ValidLogin = true;
                typeOfAccount = AccountTypes.Regular;
            }
        }
    }
}
