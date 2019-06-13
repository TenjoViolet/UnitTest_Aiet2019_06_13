using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestLab1
{
     public class MemberService
    {
        public string ValidateMember(string account, string password)
        {
            var dt = new DataTable();
            var connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
            using (var sqlConn = new SqlConnection(connString))
            {
                var sql = "select * from Member where account=@account ";
                using (var sqlCmd = new SqlCommand(sql, sqlConn))
                {
                    sqlConn.Open();

                    sqlCmd.Parameters.AddWithValue("account", account);
                    dt.Load(sqlCmd.ExecuteReader());
                }
            }

            if (dt.Rows.Count == 0)
            {
                return "No Account!";
            }
            else if (dt.Rows[0]["password"].ToString() != password)
            {
                return "Password Error!";
            }
            else
            {
                return "Success!";
            }
        }

    }
}
