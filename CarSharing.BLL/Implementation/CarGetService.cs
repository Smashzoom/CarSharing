using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarSharing.BLL.Contracts;
using CarSharing.DataAccess.Contracts;
using CarSharing.Domain;
using CarSharing.Domain.Contracts;

namespace CarSharing.BLL.Implementation
{
    public class CarGetService : ICarGetService
    {
        private ICarDataAccess CarDataAccess { get; }
        
        public CarGetService(ICarDataAccess carDataAccess)
        {
            this.CarDataAccess = carDataAccess;
        }
        public Task<IEnumerable<Car>> GetAsync()
        {
            return this.CarDataAccess.GetAsync();
        }

        public Task<Car> GetAsync(ICarIdentity car)
        {
            return this.CarDataAccess.GetAsync(car);
        }

        public async Task ValidateAsync(ICarContainer carContainer)
        {
            if (carContainer == null)
            {
                throw new ArgumentNullException(nameof(carContainer));
            }
            
            var rent = await this.GetBy(carContainer);

            if (carContainer.CarId.HasValue && rent == null)
            {
                throw new InvalidOperationException($"Rent not found by id {carContainer.CarId}");
            }
        }
        private Task<Car> GetBy(ICarContainer departmentContainer)
        {
            return this.CarDataAccess.GetByAsync(departmentContainer);
        }
    }
}