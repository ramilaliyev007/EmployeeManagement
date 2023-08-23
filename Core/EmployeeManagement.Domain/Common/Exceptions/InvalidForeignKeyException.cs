using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Domain.Common.Exceptions
{
    public class InvalidForeignKeyException : UserFriendlyException
    {
        public InvalidForeignKeyException(Exception? innerException = default) : this("Invalid foreign key. See innerException for more details", innerException)
        {

        }

        public InvalidForeignKeyException(string message, Exception? innerException = default) : base(message, innerException)
        {

        }
    }
}
