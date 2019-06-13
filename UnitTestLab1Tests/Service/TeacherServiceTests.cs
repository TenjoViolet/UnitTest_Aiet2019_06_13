using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestLab1.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using UnitTestLab1.Repository;
using UnitTestLab1.ODT;

namespace UnitTestLab1.Service.Tests
{
    [TestClass()]
    public class TeacherServiceTests
    {
        TeacherService _teacher;
        ITeacherRepository _stubTeacher;

        [TestInitialize]
        public void Initial()
        {
            _stubTeacher = Substitute.For<ITeacherRepository>();
             _teacher = new TeacherService(_stubTeacher);

        }

        private List<Teacher> CheckTeaher(string name ,int age , QualificationsResult result ,int hour , TeacherType type)
        {
            _stubTeacher.SelectTeachers().Returns(new List<Teacher>
            {
                new Teacher{ Name=name, Age=age, CheckResult = result, Hour=hour,Type=type }
            });

            return _teacher.CheckTeacherQualifications();

        }

        [TestMethod()]
        public void CheckTeacherQualificationsTest超過65歲回傳AgeFaild()
        {
            var result = CheckTeaher("T1", 66, QualificationsResult.AgeFaild, 50, TeacherType.內聘);
            var actual = result.FirstOrDefault().CheckResult ;
            Assert.AreEqual(ODT.QualificationsResult.AgeFaild, actual);
        }

        [TestMethod()]
        public void CheckTeacherQualificationsTest外聘超過60小時回傳MinHourFaild()
        {
            var result = CheckTeaher("T3", 61, QualificationsResult.MinHourFaild, 67, TeacherType.外聘);
            var actual = result.FirstOrDefault().CheckResult ;
            Assert.AreEqual(ODT.QualificationsResult.MinHourFaild, actual);
        }

        [TestMethod()]
        public void CheckTeacherQualificationsTest外聘超過80小時回傳MaxHourFaild()
        {
            var result = CheckTeaher("T5", 41, QualificationsResult.MaxHourFaild, 81, TeacherType.外聘);
            var actual = result.FirstOrDefault().CheckResult;
            Assert.AreEqual(ODT.QualificationsResult.MaxHourFaild, actual);
        }

        [TestMethod()]
        public void CheckTeacherQualificationsTest內聘65歲以下回傳NoProblem()
        {
            var result = CheckTeaher("T2", 64, QualificationsResult.MaxHourFaild, 1000, TeacherType.內聘);
            var actual = result.FirstOrDefault().CheckResult ;
            Assert.AreEqual(ODT.QualificationsResult.NoProblem, actual);
        }


    }
}