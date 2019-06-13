using System;
using System.Data;
using System.Data.SqlClient;
using UnitTestLab1.Factory;
using UnitTestLab1.Service;

namespace UnitTestLab1
{
    //重構成可以單元測試驗證service.ValidateMember的邏輯
    //要遵循單元測試只測試一件事
    internal class Program
    {
        private static void Main(string[] args)
        {
            //var service = new Service();
            //var result = service.ValidateMember("admin", "admin123");

            var teacherService = ServiceFactory.GetTeacherService();
            var result = teacherService.CheckTeacherQualifications();
            Console.ReadKey();
        }

    }
}