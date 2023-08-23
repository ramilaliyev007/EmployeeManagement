using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository.EfCore.Helpers
{
    internal enum SqlExceptionNumber
    {
        UniqueConstraint = 2627,

        DuplicateKey = 2601
    }
}
