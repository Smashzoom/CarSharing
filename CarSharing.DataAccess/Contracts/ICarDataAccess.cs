using System.Collections.Generic;
using System.Threading.Tasks;
using CarSharing.Domain;
using CarSharing.Domain.Contracts;
using CarSharing.Domain.Models;
namespace CarSharing.DataAccess.Contracts
{
    public interface ICarDataAccess
    {
        Task<Car> InsertAsync(CarUpdateModel car);
        Task<IEnumerable<Car>> GetAsync();
        Task<Car> GetAsync(ICarIdentity carId);
        Task<Car> UpdateAsync(CarUpdateModel car);
        Task<Car> GetByAsync(ICarContainer car);

    }
}