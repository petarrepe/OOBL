using System;

namespace OOBL
{
    class ArticlesState : IActionState
    {
        private Util.Actions articlesAction;

        public ArticlesState(Util.Actions action)
        {
            this.articlesAction = action;
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
