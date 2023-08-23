namespace EmployeeManagement.Domain.Common.Exceptions
{
    public class DataNotFoundByIdException : UserFriendlyException
    {
        public DataNotFoundByIdException(dynamic id) : base($"Data not found for given Id. Id: {id}")
        {

        }
    }
}
