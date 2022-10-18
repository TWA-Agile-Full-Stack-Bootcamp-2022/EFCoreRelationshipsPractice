using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFCoreRelationshipsPractice.Models
{
    public class Company
    {
        public Company()
        {
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public Profile Profile { get; set; } = new Profile();

        public List<Employee> Employees { get; set; } = new List<Employee>();
    }
}