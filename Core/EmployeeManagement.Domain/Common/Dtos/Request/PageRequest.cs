namespace EmployeeManagement.Domain.Common.Dtos.Requests
{
    public record PageRequest
    {
        public int Page { get; init; } = 1;

        public int Take { get; init; } = 10;

        public int Skip => (Page - 1) * Take;
    }
}
