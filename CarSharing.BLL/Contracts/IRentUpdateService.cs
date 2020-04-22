using System.Threading.Tasks;
using CarSharing.Domain;
using CarSharing.Domain.Models;

namespace CarSharing.BLL.Contracts
{
    public interface IRentUpdateService
    {
        Task<Rent> UpdateAsync(RentUpdateModel rent);
    }
}