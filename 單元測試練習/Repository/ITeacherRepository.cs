using System.Collections.Generic;
using UnitTestLab1.ODT;

namespace UnitTestLab1.Repository
{
    public interface ITeacherRepository
    {
        List<Teacher> SelectTeachers();
    }
}