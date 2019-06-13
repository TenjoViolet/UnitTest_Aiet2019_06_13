using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using UnitTestLab1.ODT;

namespace UnitTestLab1.Service
{
    //假物件分兩種
    //stub:虛設常式
    //mock:模擬物件
    public class OrderService
    {
        private string _filePath = @"C:\temp\joey.csv";

        /// <summary>
        /// 篩選出Book類的送到遠端API
        /// </summary>
        public virtual void SyncBookOrders()
        {
            var orders = this.GetOrders();

            // only get orders of book
            var ordersOfBook = orders.Where(x => x.Type == "Book");

            var bookDao = GetBookDao();
            foreach (var order in ordersOfBook)
            {
                bookDao.Insert(order);
            }
        }

        protected virtual IBookDao GetBookDao()
        {
            return new BookDao();

        }


        /// <summary>
        /// 從csv取得訂單資料
        /// </summary>
        /// <returns></returns>
        protected virtual List<Order> GetOrders()
        {
            // parse csv file to get orders
            var result = new List<Order>();

            // directly depend on File I/O
            using (StreamReader sr = new StreamReader(this._filePath, Encoding.UTF8))
            {
                int rowCount = 0;

                while (sr.Peek() > -1)
                {
                    rowCount++;

                    var content = sr.ReadLine();

                    // Skip CSV header line
                    if (rowCount > 1)
                    {
                        string[] line = content.Trim().Split(',');

                        result.Add(this.Mapping(line));
                    }
                }
            }

            return result;
        }

        private Order Mapping(string[] line)
        {
            var result = new Order
            {
                ProductName = line[0],
                Type = line[1],
                Price = Convert.ToInt32(line[2]),
                CustomerName = line[3]
            };

            return result;
        }
    }

    public class BookDao : IBookDao
    {
      public void Insert(Order order)
        {
            var myContent = JsonConvert.SerializeObject(order);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var client = new HttpClient();
            client.PostAsync("http://api.joey.io/Order", byteContent);
        }
    }
}