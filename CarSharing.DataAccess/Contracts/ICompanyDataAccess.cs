using System.Collections.Generic;
using System.Threading.Tasks;
using CarSharing.Domain;
using CarSharing.Domain.Contracts;
using CarSharing.Domain.Models;
namespace CarSharing.DataAccess.Contracts
{
    public interface ICompanyDataAccess
    {
        Task<Company> InsertAsync(CompanyUpdateModel company);
        Task<IEnumerable<Company>> GetAsync();
        Task<Company> GetAsync(ICompanyIdentity companyId);
        Task<Company> UpdateAsync(CompanyUpdateModel company);
        Task<Company> GetByAsync(ICompanyContainer company);

    }
}