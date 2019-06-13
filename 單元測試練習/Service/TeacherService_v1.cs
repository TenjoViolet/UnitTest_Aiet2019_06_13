using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestLab1.ODT;

namespace UnitTestLab1.Service
{
    public class TeacherService_v1
    {
        public class QualificationDefine
        {
            public static int Age => 65;
            public static int MinHourLimit => 60;
            public static int MaxHourLimit => 80;
        }

        /// <summary>
        /// 驗證年紀不可大於65 , 內聘不限時數 , 外聘60提示80不可排
        /// </summary>
        /// <returns></returns>
        public List<Teacher> CheckTeacherQualifications()
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

            var conditions = new TeacherQualificationsCondition();
            foreach (var teacher in teachers)
            {
                conditions.GetConditions().FirstOrDefault(p => p.Key(teacher)).Value(teacher);
                //if (teacher.Age > QualificationDefine.Age)
                //    teacher.CheckResult = QualificationsResult.AgeFaild;
                //else if (teacher.Type == TeacherType.內聘)
                //    teacher.CheckResult = QualificationsResult.NoProblem;
                //else if (teacher.Type == TeacherType.外聘 && teacher.Hour > QualificationDefine.MaxHourLimit)
                //    teacher.CheckResult = QualificationsResult.MaxHourFaild;
                //else if (teacher.Type == TeacherType.外聘 && teacher.Hour > QualificationDefine.MinHourLimit)
                //    teacher.CheckResult = QualificationsResult.MinHourFaild;
                //else
                //    teacher.CheckResult = QualificationsResult.NoProblem;
            }

            return teachers;
        }
    }

    public class TeacherQualificationsCondition
    {
        public Dictionary<Func<Teacher, bool>, Action<Teacher>> GetConditions()
        {
            var dic = new Dictionary<Func<Teacher, bool>, Action<Teacher>>();

            dic.Add(
                (teacher) => teacher.Age > TeacherService.QualificationDefine.Age
            , (teacher) => teacher.CheckResult = QualificationsResult.AgeFaild);

            dic.Add((teacher) => teacher.Type == TeacherType.內聘
            , (teacher) => teacher.CheckResult = QualificationsResult.NoProblem);

            dic.Add((teacher) => teacher.Type == TeacherType.外聘
            && teacher.Hour > TeacherService.QualificationDefine.MinHourLimit
            && teacher.Hour < TeacherService.QualificationDefine.MaxHourLimit
            , (teacher) => teacher.CheckResult = QualificationsResult.MinHourFaild);

            dic.Add((teacher) => teacher.Type == TeacherType.外聘
            && teacher.Hour > TeacherService.QualificationDefine.MaxHourLimit
            , (teacher) => teacher.CheckResult = QualificationsResult.MaxHourFaild);

            //else
            dic.Add((teacher) => true, (teacher) => teacher.CheckResult = QualificationsResult.NoProblem);

            return dic;
        }
    }

}


