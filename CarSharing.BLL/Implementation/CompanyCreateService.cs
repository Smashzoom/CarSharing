using System.Threading.Tasks;
using CarSharing.BLL.Contracts;
using CarSharing.DataAccess.Contracts;
using CarSharing.Domain;
using CarSharing.Domain.Models;

namespace CarSharing.BLL.Implementation
{
    public class CompanyCreateService : ICompanyCreateService
    {
        private ICompanyDataAccess CompanyDataAccess { get; }

        public CompanyCreateService(ICompanyDataAccess companyDataAccess)
        {
            CompanyDataAccess = companyDataAccess;
        }

        public  Task<Company> CreateAsync(CompanyUpdateModel company)
        {
            return CompanyDataAccess.InsertAsync(company);
        }
    }
}