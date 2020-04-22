using System.Collections.Generic;
using System.Threading.Tasks;
using CarSharing.Domain;
using CarSharing.Domain.Contracts;

namespace CarSharing.BLL.Contracts
{
    public interface ICarGetService
    {
        Task<IEnumerable<Car>> GetAsync();
        Task<Car> GetAsync(ICarIdentity car);
        Task ValidateAsync(ICarContainer departmentContainer);
    }
}