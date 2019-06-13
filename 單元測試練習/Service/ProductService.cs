using System;
using System.Data;
using System.Data.SqlClient;

namespace UnitTestLab1
{
    public class ProductService
    {
        public ProductService()
        {
        }

        /// <summary>
        /// 蘋果買2顆 , 香蕉一串 ,芭樂3顆 共135
        /// </summary>
        /// <returns></returns>
        public decimal CulcFruitsPrice()
        {
            var dt = new DataTable();
            var connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
            using (var sqlConn = new SqlConnection(connString))
            {
                var sql = "select * from Product where Type = N'水果'";
                using (var sqlCmd = new SqlCommand(sql, sqlConn))
                {
                    sqlConn.Open();

                    dt.Load(sqlCmd.ExecuteReader());
                }
            }

            var totalPrice = 0m;
            foreach (DataRow row in dt.Rows)
            {
                if (row["Name"].ToString() == "蘋果")
                    totalPrice += Convert.ToDecimal(row["Price"]) * 2;
                else if (row["Name"].ToString() == "香蕉")
                    totalPrice += Convert.ToDecimal(row["Price"]) * 1;
                else if (row["Name"].ToString() == "芭樂")
                    totalPrice += Convert.ToDecimal(row["Price"]) * 3;
            }

            return totalPrice;
        }
    }
}