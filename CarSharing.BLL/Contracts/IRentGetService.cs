using System.Collections.Generic;
using System.Threading.Tasks;
using CarSharing.Domain;
using CarSharing.Domain.Contracts;

namespace CarSharing.BLL.Contracts
{
    public interface IRentGetService
    {
        Task<IEnumerable<Rent>> GetAsync();
        Task<Rent> GetAsync(IRentIdentity rent);
        Task ValidateAsync(IRentContainer departmentContainer);
    }
}