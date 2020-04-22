using CarSharing.Domain.Contracts;

namespace CarSharing.Domain.Models
{
    public class CarIdentityModel : ICarIdentity
    {
        public int Id { get; }

        public CarIdentityModel(int id)
        {
            this.Id = id;
        }
    }
}