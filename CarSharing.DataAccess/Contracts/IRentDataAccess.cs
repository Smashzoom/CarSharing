using System.Collections.Generic;
using System.Threading.Tasks;
using CarSharing.Domain;
using CarSharing.Domain.Contracts;
using CarSharing.Domain.Models;
namespace CarSharing.DataAccess.Contracts
{
    public interface IRentDataAccess
    {
        Task<Rent> InsertAsync(RentUpdateModel rent);
        Task<IEnumerable<Rent>> GetAsync();
        Task<Rent> GetAsync(IRentIdentity rentId);
        Task<Rent> UpdateAsync(RentUpdateModel rent);
        Task<Rent> GetByAsync(IRentContainer rent);

    }
}