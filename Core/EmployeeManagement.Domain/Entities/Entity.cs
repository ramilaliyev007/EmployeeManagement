namespace EmployeeManagement.Domain.Entities
{
    public class Entity : Entity<int>
    {

    }

    public class Entity<TId> where TId : struct
    {
        public TId Id { get; init; }
    }
}