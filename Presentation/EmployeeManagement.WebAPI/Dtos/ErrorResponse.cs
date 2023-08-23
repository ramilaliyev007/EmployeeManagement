using System.Text.Json;

namespace EmployeeManagement.WebAPI.Dtos
{
#nullable disable

    public record ErrorResponse
    {
        public string Message { get; init; }

        public DateTime Time => DateTime.Now;

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }

#nullable enable
}
