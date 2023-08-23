namespace EmployeeManagement.Domain.Common.QueryFilters
{
    public interface IHasDeletedDate
    {
        public DateTime? DeletedDate { get; set; }
    }
}
