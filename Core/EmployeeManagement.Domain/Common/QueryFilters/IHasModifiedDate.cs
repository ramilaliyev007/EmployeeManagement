namespace EmployeeManagement.Domain.Common.QueryFilters
{
    public interface IHasLastModifiedDate
    {
        public DateTime? LastModifiedDate { get; set; }
    }
}
