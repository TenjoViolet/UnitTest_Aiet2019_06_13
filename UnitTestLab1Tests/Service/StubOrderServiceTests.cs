using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestLab1.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using UnitTestLab1.ODT;

namespace UnitTestLab1.Service.Tests
{
    [TestClass()]
    public class StubOrderServiceTests
    {
        [TestMethod()]
        public void SyncBookOrdersTest_Book有兩筆應該Insert兩次()
        {
            var mockBookDao = Substitute.For<IBookDao>();
            var subOrderService = new StubOrderService(mockBookDao);
            subOrderService.SetOrders(new List<Order>
            {
                new Order{ ProductName="p1", Type="Book" },
                new Order{ ProductName="p2", Type="Foods" },
                new Order{ ProductName="p3", Type="Tools" },
                new Order{ ProductName="p4", Type="Book" },
             });
            subOrderService.SyncBookOrders();
            mockBookDao.Received(2).Insert(Arg.Any<Order>());


        }

        [TestMethod()]
        public void SyncBookOrdersTest_Book有三筆應該Insert三次()
        {
            var mockBookDao = Substitute.For<IBookDao>();

            var subOrderService = new StubOrderService(mockBookDao);

            subOrderService.SetOrders(new List<Order>
            {
                new Order{ ProductName="p1", Type="Book" },
                new Order{ ProductName="p2", Type="Foods" },
                new Order{ ProductName="p3", Type="Tools" },
                new Order{ ProductName="p4", Type="Book" },
                 new Order{ ProductName="p5", Type="Book" },
            });

            subOrderService.SyncBookOrders();

            mockBookDao.Received(3).Insert(Arg.Any<Order>());
        }




    }
}