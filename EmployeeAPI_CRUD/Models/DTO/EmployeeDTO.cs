using System.ComponentModel.DataAnnotations;

namespace EmployeeAPI_CRUD.Models.DTO
{
    public class EmployeeDTO
    {
        public string FullName { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        public string? Gender { get; set; }
    }
}
