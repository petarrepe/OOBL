using System;

namespace OOBL
{
    class ReportsState : IActionState
    {
        private Util.Actions reportForArticles;

        public ReportsState(Util.Actions reportForArticles)
        {
            this.reportForArticles = reportForArticles;
        }

        public void Exit()
        {
            throw new NotImplementedException();
        }

        public void PerformOperation()
        {
            throw new NotImplementedException();
        }
    }
}
