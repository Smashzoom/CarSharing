using System.Threading.Tasks;
using CarSharing.Domain;
using CarSharing.Domain.Models;

namespace CarSharing.BLL.Contracts
{
    public interface ICarCreateService
    {
        Task<Car> CreateAsync(CarUpdateModel car);
    }
}