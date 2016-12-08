using System;

namespace OOBL
{
    public static class ActionStateFactory
    {
        public static IActionState GetActionState(int type)
        {
            switch (type)
            {
                case 1 :
                    return new BillState(Util.Actions.NewBill);
                case 2:
                    return new ReportsState(Util.Actions.ReportForDay);
                case 3:
                    return new ReportsState(Util.Actions.ReportForArticles);
                case 4:
                    return new ArticlesState(Util.Actions.ArticlesEdit);
                case 5:
                    return new BillState(Util.Actions.BillDeletion);

                default:
                    throw new NotSupportedException();
            }
        }
    }
}
