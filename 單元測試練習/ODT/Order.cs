using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestLab1.ODT
{
    public class Order
    {
        public string Type { get;  set; }
        public string ProductName { get;  set; }
        public int Price { get; internal set; }
        public string CustomerName { get;  set; }
    }
}
