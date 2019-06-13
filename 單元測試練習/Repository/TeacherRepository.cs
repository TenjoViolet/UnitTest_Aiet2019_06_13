using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestLab1.ODT;

namespace UnitTestLab1.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        public List<Teacher> SelectTeachers()
        {
            //假裝是資料庫抓資料
            var teachers = new List<Teacher>
            {
                new Teacher { Name="T1", Age=66,Hour=61 ,Type=TeacherType.內聘 ,CheckResult=QualificationsResult.NotYetChecked },
                new Teacher { Name="T2",Age=46,Hour=85 ,Type=TeacherType.內聘 ,CheckResult=QualificationsResult.NotYetChecked},
                new Teacher { Name="T3",Age=34,Hour=61 ,Type=TeacherType.外聘 ,CheckResult=QualificationsResult.NotYetChecked},
                new Teacher { Name="T4",Age=41,Hour=50 ,Type=TeacherType.外聘 ,CheckResult=QualificationsResult.NotYetChecked},
                new Teacher { Name="T5",Age=31,Hour=81 ,Type=TeacherType.外聘 ,CheckResult=QualificationsResult.NotYetChecked}
           };

            return teachers;
        }
    }
}