using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestLab1.ODT;

namespace UnitTestLab1.Service
{

    public class StubOrderService : OrderService
    {
        private IBookDao _bookDao;
        private List<Order> _orders;
        public StubOrderService(IBookDao boolDao)
        {
            _bookDao = boolDao;
        }
        protected override List<Order> GetOrders()
        { 
            return _orders;
        }


        public  void SetOrders(List<Order> orders)
        {
            _orders = orders;
        }

        public void SetBookDao(IBookDao bookDao)
        {
            _bookDao = bookDao;
        }

        protected override IBookDao GetBookDao()
        {
            return _bookDao;
        }


        //public override void SyncBookOrders()
        //{
        //    base.SyncBookOrders();
        //}
    }
}
