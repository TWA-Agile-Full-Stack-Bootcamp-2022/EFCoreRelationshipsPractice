using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using EFCoreRelationshipsPractice.Dtos;

namespace EFCoreRelationshipsPractice.Models
{
    public class Company
    {
        public Company()
        {
        }

        public Company(CompanyDto companyDto)
        {
            Name = companyDto.Name;
            Profile = new Profile(companyDto.Profile);
            Employees = companyDto.Employees.Select(dto => new Employee(dto)).ToList();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public Profile Profile { get; set; } = new Profile();

        public List<Employee> Employees { get; set; } = new List<Employee>();
    }
}