using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarSharing.BLL.Contracts;
using CarSharing.DataAccess.Contracts;
using CarSharing.Domain;
using CarSharing.Domain.Contracts;

namespace CarSharing.BLL.Implementation
{
    public class RentGetService : IRentGetService
    {
        private IRentDataAccess RentDataAccess { get; }
        
        public RentGetService(IRentDataAccess companyDataAccess)
        {
            this.RentDataAccess = companyDataAccess;
        }
        public Task<IEnumerable<Rent>> GetAsync()
        {
            return this.RentDataAccess.GetAsync();
        }

        public Task<Rent> GetAsync(IRentIdentity rent)
        {
            return this.RentDataAccess.GetAsync(rent);
        }

        public async Task ValidateAsync(IRentContainer rentContainer)
        {
            if (rentContainer == null)
            {
                throw new ArgumentNullException(nameof(rentContainer));
            }
            
            var rent = await this.GetBy(rentContainer);

            if (rentContainer.RentId.HasValue && rent == null)
            {
                throw new InvalidOperationException($"Rent not found by id {rentContainer.RentId}");
            }
        }
        private Task<Rent> GetBy(IRentContainer departmentContainer)
        {
            return this.RentDataAccess.GetByAsync(departmentContainer);
        }
    }
}