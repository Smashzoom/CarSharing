using System.Threading.Tasks;
using CarSharing.BLL.Contracts;
using CarSharing.DataAccess.Contracts;
using CarSharing.Domain;
using CarSharing.Domain.Models;

namespace CarSharing.BLL.Implementation
{
    public class CarCreateService : ICarCreateService
    {
        private ICarDataAccess CarDataAccess { get; }

        public CarCreateService(ICarDataAccess rentDataAccess)
        {
            CarDataAccess = rentDataAccess;
        }

        public Task<Car> CreateAsync(CarUpdateModel car)
        {
            return CarDataAccess.InsertAsync(car);
        }
    }
}