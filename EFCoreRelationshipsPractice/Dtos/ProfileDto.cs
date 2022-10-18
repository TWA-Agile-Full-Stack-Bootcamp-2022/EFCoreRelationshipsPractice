using EFCoreRelationshipsPractice.Models;

namespace EFCoreRelationshipsPractice.Dtos
{
    public class ProfileDto
    {
        public ProfileDto()
        {
        }

        public ProfileDto(Profile companyProfile)
        {
            RegisteredCapital = companyProfile.RegisteredCapital;
            CertId = companyProfile.CertId;
        }

        public int RegisteredCapital { get; set; }
        public string CertId { get; set; }
    }
}