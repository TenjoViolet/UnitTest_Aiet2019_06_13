using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestLab1.ODT;
using UnitTestLab1.Repository;

namespace UnitTestLab1.Service
{
    public class TeacherService
    {
        ITeacherRepository _teacherRepos;
        public class QualificationDefine
        {
            public static int Age => 65;
            public static int MinHourLimit => 60;
            public static int MaxHourLimit => 80;
        }


        public TeacherService(ITeacherRepository teacherRepository)
        {
            _teacherRepos = teacherRepository;
        }

        /// <summary>
        /// 條件年紀不可大於65 , 內聘不限時數 , 外聘60提示訊息 80不可排課
        /// </summary>
        /// <returns></returns>
        public List<Teacher> CheckTeacherQualifications()
        {
            var teachers = _teacherRepos.SelectTeachers();
            
            foreach (var teacher in teachers)
            {
                if (teacher.Age > QualificationDefine.Age)
                    teacher.CheckResult = QualificationsResult.AgeFaild;
                else if (teacher.Type == TeacherType.內聘)
                    teacher.CheckResult = QualificationsResult.NoProblem;
                else if (teacher.Type == TeacherType.外聘 && teacher.Hour > QualificationDefine.MaxHourLimit)
                    teacher.CheckResult = QualificationsResult.MaxHourFaild;
                else if (teacher.Type == TeacherType.外聘 && teacher.Hour > QualificationDefine.MinHourLimit)
                    teacher.CheckResult = QualificationsResult.MinHourFaild;
                else
                    teacher.CheckResult = QualificationsResult.NoProblem;
            }

            return teachers;
        }
    }
   

}
