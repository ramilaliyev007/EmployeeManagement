namespace EmployeeManagement.Domain.Common.QueryFilters
{
    public interface ISoftDelete
    {
        public bool IsDeleted { get; set; }
    }
}
