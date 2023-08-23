namespace EmployeeManagement.Domain.Common.Exceptions
{
    public class UserFriendlyException : Exception
    {
        public UserFriendlyException(Exception? innerException = default) : this("Error occured", innerException)
        {

        }

        public UserFriendlyException(string message, Exception? innerException = default) : base(message, innerException)
        {

        }
    }
}
