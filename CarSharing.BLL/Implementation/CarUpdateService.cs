using System.Threading.Tasks;
using CarSharing.BLL.Contracts;
using CarSharing.DataAccess.Contracts;
using CarSharing.Domain;
using CarSharing.Domain.Models;

namespace CarSharing.BLL.Implementation
{
    public class CarUpdateService : ICarUpdateService
    {
        private ICarDataAccess CarDataAccess { get; }

        public CarUpdateService(ICarDataAccess rentDataAccess)
        {
            CarDataAccess = rentDataAccess;
        }

        public Task<Car> UpdateAsync(CarUpdateModel car)
        {
            return CarDataAccess.UpdateAsync(car);
        }
    }
}