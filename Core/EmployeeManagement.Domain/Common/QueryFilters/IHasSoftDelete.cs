namespace EmployeeManagement.Domain.Common.QueryFilters
{
    public interface IHasSoftDelete
    {
        public bool IsDeleted { get; set; }
    }
}
