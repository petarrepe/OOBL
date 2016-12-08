using System;

namespace OOBL
{
    class BillState : IActionState
    {
        private Util.Actions billAction;
        private delegate void Delegate();
        private Bill bill = new Bill();

        public BillState(Util.Actions action)
        {
            this.billAction = action;
        }

        public void Exit()
        {
            throw new NotImplementedException();
        }

        public void PerformOperation()
        {
            if (billAction == Util.Actions.NewBill)
            {
                CreateNewBill();
            }
            else if (billAction == Util.Actions.BillDeletion)
            {
                DeleteBill();
            }
        }

        private void DeleteBill()
        {
            throw new NotImplementedException();
        }

        private void CreateNewBill()
        {
            bill = new Bill();
            Delegate dl = new Delegate(BillDelegate);


            dl();
        }
        public void BillDelegate()
        {
            bill.calculateBillInformation();
        }
    }
}
