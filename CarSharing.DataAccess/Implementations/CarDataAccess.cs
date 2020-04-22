using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarSharing.DataAccess.Context;
using CarSharing.DataAccess.Contracts;
using CarSharing.Domain;
using CarSharing.Domain.Contracts;
using CarSharing.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore;
using AutoMapper;

namespace CarSharing.DataAccess.Implementations
{
    public class CarDataAccess : ICarDataAccess
    {
        private CompanyContext Context { get; }
        private IMapper Mapper { get; }

        public CarDataAccess(CompanyContext context, IMapper mapper)
        {
            this.Context = context;
            Mapper = mapper;
        }

        public async Task<Car> InsertAsync(CarUpdateModel car)
        {
            var result = await this.Context.AddAsync(this.Mapper.Map<DataAccess.Entities.Car>(car));

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<Car>(result.Entity);
        }

        public async Task<IEnumerable<Car>> GetAsync()
        {
            return this.Mapper.Map<IEnumerable<Car>>(
                await this.Context.Car.ToListAsync());
        }

        public async Task<Car> GetAsync(ICarIdentity car)
        {
            var result = await this.Get(car);

            return this.Mapper.Map<Car>(result);
        }

        public async Task<Car> UpdateAsync(CarUpdateModel car)
        {
            var existing = await this.Get(car);

            var result = this.Mapper.Map(car, existing);

            this.Context.Update(result);

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<Car>(result);
        }

        public async Task<Car> GetByAsync(ICarContainer car)
        {
            return car.CarId.HasValue 
                ? this.Mapper.Map<Car>(await this.Context.Car.FirstOrDefaultAsync(x => x.Id == car.CarId)) 
                : null;
        }

        private async Task<CarSharing.DataAccess.Entities.Car> Get(ICarIdentity car)
        {
            if(car == null)
                throw new ArgumentNullException(nameof(car));
            return await this.Context.Car.FirstOrDefaultAsync(x => x.Id == car.Id);
        }
    }
}