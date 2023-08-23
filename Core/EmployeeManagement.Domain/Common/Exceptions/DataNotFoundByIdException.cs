using System.Runtime.CompilerServices;

namespace EmployeeManagement.Domain.Common.Exceptions
{
    public class DataNotFoundByIdException : UserFriendlyException
    {
        public DataNotFoundByIdException(dynamic id)
            : base($"Data not found for given Id. Id: {id}")
        {

        }

        public DataNotFoundByIdException(string message, dynamic id) : base($"{message}. Id: {id}")
        {

        }

        public static void ThrowIfNotFound(object? data, dynamic id, [CallerArgumentExpression("data")] string dataName = default)
        {
            if (data is null)
                throw new DataNotFoundByIdException($"'{dataName}' not found for given id", id);
        }
    }
}
