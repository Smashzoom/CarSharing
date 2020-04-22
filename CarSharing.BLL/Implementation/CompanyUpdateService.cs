using System.Threading.Tasks;
using CarSharing.BLL.Contracts;
using CarSharing.DataAccess.Contracts;
using CarSharing.Domain;
using CarSharing.Domain.Models;

namespace CarSharing.BLL.Implementation
{
    public class CompanyUpdateService : ICompanyUpdateService
    {
        private ICompanyDataAccess CompanyDataAccess { get; }

        public CompanyUpdateService(ICompanyDataAccess companyDataAccess)
        {
            CompanyDataAccess = companyDataAccess;
        }

        public Task<Company> UpdateAsync(CompanyUpdateModel company)
        {
            return CompanyDataAccess.UpdateAsync(company);
        }
    }
}