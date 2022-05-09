using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student_platform.BLL.Interfaces
{
    public interface IStudentManager
    {
        Task<List<string>> ModifyStudent();
    }
}
