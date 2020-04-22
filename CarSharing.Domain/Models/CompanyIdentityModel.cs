using CarSharing.Domain.Contracts;

namespace CarSharing.Domain.Models
{
    public class CompanyIdentityModel : ICompanyIdentity
    {
        public int Id { get; }

        public CompanyIdentityModel(int id)
        {
            this.Id = id;
        }
    }
}