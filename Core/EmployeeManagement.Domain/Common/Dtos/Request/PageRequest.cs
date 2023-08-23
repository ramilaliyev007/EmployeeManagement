namespace EmployeeManagement.Domain.Common.Dtos.Requests
{
    public record PageRequest
    {
        public int PageNumber { get; init; } = 1;

        public int PageSize { get; init; } = 10;

        public int SkipCount => (PageNumber - 1) * PageSize;
    }
}
