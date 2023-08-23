namespace EmployeeManagement.Domain.Common.Dtos.Response
{
    public record PageListResponse<TEntity>
    {
        public PageListResponse(int pageSize, int totalCount, List<TEntity> list)
        {
            List = list;

            TotalCount = totalCount;

            TotalPages = (int)Math.Ceiling((double)totalCount / pageSize);
        }

        public int TotalCount { get; init; }

        public int TotalPages { get; init; }

        public List<TEntity> List { get; init; }
    }
}
