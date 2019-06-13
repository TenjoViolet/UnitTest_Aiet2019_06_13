using System;
using UnitTestLab1.Repository;

namespace UnitTestLab1.Factory
{
    public class RepositoryFactory
    {
        public static ITeacherRepository GetTeacherRepository()
        {
            return new TeacherRepository();
        }
    }
}