namespace EmployeeManagement.Domain.Common.Exceptions
{
    public class UniqueConstraintException : UserFriendlyException
    {
        public UniqueConstraintException(Exception? innerException = default)
            : base("Data must be unique. See innerException for more details", innerException)
        {

        }
    }
}
