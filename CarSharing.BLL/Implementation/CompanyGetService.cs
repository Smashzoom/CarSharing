using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarSharing.BLL.Contracts;
using CarSharing.DataAccess.Contracts;
using CarSharing.Domain;
using CarSharing.Domain.Contracts;

namespace CarSharing.BLL.Implementation
{
    
    public class CompanyGetService : ICompanyGetService
    {
        private ICompanyDataAccess CompanyDataAccess { get; }
        
        public CompanyGetService(ICompanyDataAccess companyDataAccess)
        {
            this.CompanyDataAccess = companyDataAccess;
        }
        public Task<IEnumerable<Company>> GetAsync()
        {
            return this.CompanyDataAccess.GetAsync();
        }

        public Task<Company> GetAsync(ICompanyIdentity company)
        {
            return this.CompanyDataAccess.GetAsync(company);
        }

        public async Task ValidateAsync(ICompanyContainer companyContainer)
        {
            if (companyContainer == null)
            {
                throw new ArgumentNullException(nameof(companyContainer));
            }
            
            var company = await this.GetBy(companyContainer);

            if (companyContainer.CompanyId.HasValue && company == null)
            {
                throw new InvalidOperationException($"Company not found by id {companyContainer.CompanyId}");
            }
        }
        private Task<Company> GetBy(ICompanyContainer companyContainer)
        {
            return this.CompanyDataAccess.GetByAsync(companyContainer);
        }
    }
}