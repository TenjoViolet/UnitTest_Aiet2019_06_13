using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestLab1.Service;

namespace UnitTestLab1.Factory
{
    public class ServiceFactory
    {
        public static TeacherService GetTeacherService()
        {
            return new TeacherService(RepositoryFactory.GetTeacherRepository());
        }
    }
}
