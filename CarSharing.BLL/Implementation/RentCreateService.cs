using System.Threading.Tasks;
using CarSharing.BLL.Contracts;
using CarSharing.DataAccess.Contracts;
using CarSharing.Domain;
using CarSharing.Domain.Models;

namespace CarSharing.BLL.Implementation
{
    public class RentCreateService : IRentCreateService
    {
        private IRentDataAccess RentDataAccess { get; }
        private ICarGetService CarGetService { get; }
        private ICompanyGetService CompanyGetService { get; }

        public RentCreateService(IRentDataAccess rentDataAccess, ICompanyGetService companyGetService,
            ICarGetService carGetService)
        {
            RentDataAccess = rentDataAccess;
            CarGetService = carGetService;
            CompanyGetService = companyGetService;
        }

        public async Task<Rent> CreateAsync(RentUpdateModel rent)
        {
            await CarGetService.ValidateAsync(rent);
            await CompanyGetService.ValidateAsync(rent);

            return await RentDataAccess.InsertAsync(rent);

        }
    }
}