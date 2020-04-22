using System.Collections.Generic;
using System.Threading.Tasks;
using CarSharing.Domain;
using CarSharing.Domain.Contracts;

namespace CarSharing.BLL.Contracts
{
    public interface ICompanyGetService
    {
        Task<IEnumerable<Company>> GetAsync();
        Task<Company> GetAsync(ICompanyIdentity company);
        Task ValidateAsync(ICompanyContainer departmentContainer);
    }
}