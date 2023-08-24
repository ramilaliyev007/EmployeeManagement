using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository.EfCore.Helpers
{
    internal static class SqlExceptionNumberConsts
    {
        public const int UniqueConstraint = 2627;

        public const int DuplicateKey = 2601;
    }
}
