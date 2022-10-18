using System.ComponentModel.DataAnnotations;
using System.Runtime.ConstrainedExecution;
using EFCoreRelationshipsPractice.Dtos;

namespace EFCoreRelationshipsPractice.Models
{
    public class Profile
    {
        public Profile()
        {
        }

        public Profile(ProfileDto profileDto)
        {
            RegisteredCapital = profileDto.RegisteredCapital;
            CertId = profileDto.CertId;
        }

        [Key]
        public int Id { get; set; }

        public int RegisteredCapital { get; set; }

        public string CertId { get; set; }
    }
}