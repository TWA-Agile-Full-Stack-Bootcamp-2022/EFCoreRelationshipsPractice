using System.ComponentModel.DataAnnotations;
using EFCoreRelationshipsPractice.Dtos;

namespace EFCoreRelationshipsPractice.Models
{
    public class Employee
    {
        public Employee()
        {
        }

        public Employee(EmployeeDto employeeDto)
        {
            Name = employeeDto.Name;
            Age = employeeDto.Age;
        }

        [Key] public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }
    }
}