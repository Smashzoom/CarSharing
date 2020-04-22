using System.Threading.Tasks;
using CarSharing.Domain;
using CarSharing.Domain.Models;

namespace CarSharing.BLL.Contracts
{
    public interface ICarUpdateService
    {
        Task<Car> UpdateAsync(CarUpdateModel car);
    }
}