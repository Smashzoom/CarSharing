using CarSharing.Domain.Contracts;

namespace CarSharing.Domain.Models
{
    public class RentIdentityModel : IRentIdentity
    {
        public int Id { get; }

        public RentIdentityModel(int id)
        {
            this.Id = id;
        }
    }
}