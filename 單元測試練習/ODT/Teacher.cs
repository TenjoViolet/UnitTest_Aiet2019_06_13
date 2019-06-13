using UnitTestLab1.Service;

namespace UnitTestLab1.ODT
{
    public enum TeacherType
    {
        內聘,
        外聘
    }

    public enum QualificationsResult
    {
        AgeFaild,
        MaxHourFaild,
        MinHourFaild,
        NoProblem,
        NotYetChecked
    }

    public class Teacher
    {
        public int Age { get;  set; }
        public int Hour { get;  set; }
        public TeacherType Type { get;  set; }
        public QualificationsResult CheckResult { get;  set; }
        public string Name { get;  set; }
    }
}