namespace EmployeeManagement.Domain.Common.Dtos
{
    public record EntityDto : EntityDto<int>
    {

    }

    public record EntityDto<TId> where TId : struct
    {
        public TId Id { get; set; }
    }
}
