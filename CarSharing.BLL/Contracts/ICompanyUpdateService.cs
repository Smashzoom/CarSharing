using System.Threading.Tasks;
using CarSharing.Domain;
using CarSharing.Domain.Models;

namespace CarSharing.BLL.Contracts
{
    public interface ICompanyUpdateService
    {
        Task<Company> UpdateAsync(CompanyUpdateModel company);
    }
}