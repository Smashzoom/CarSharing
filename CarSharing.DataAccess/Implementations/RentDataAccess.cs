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
    public class RentDataAccess : IRentDataAccess
    {
        private CompanyContext Context { get; }
        private IMapper Mapper { get; }

        public RentDataAccess(CompanyContext context, IMapper mapper)
        {
            this.Context = context;
            Mapper = mapper;
        }

        public async Task<Rent> InsertAsync(RentUpdateModel rent)
        {
            var result = await this.Context.AddAsync(this.Mapper.Map<DataAccess.Entities.Rent>(rent));
            await this.Context.SaveChangesAsync();
            return this.Mapper.Map<Rent>(result.Entity);
        }

        public async Task<IEnumerable<Rent>> GetAsync()
        {
            return this.Mapper.Map<IEnumerable<Rent>>(await this.Context.Rent.Include(x => x.Company).Include(x=>x.Car).ToListAsync());
        }

        public async Task<Rent> GetAsync(IRentIdentity rentId)
        {

            var result = await this.Get(rentId);
            return this.Mapper.Map<Rent>(result);
        }
        
        private async Task<CarSharing.DataAccess.Entities.Rent> Get(IRentIdentity rentId)
        {
            if (rentId == null)
                throw new ArgumentNullException(nameof(rentId));
            return await this.Context.Rent.Include(x => x.Company).Include(x=>x.Car).FirstOrDefaultAsync(x => x.Id == rentId.Id);
            
        }

        public async Task<Rent> UpdateAsync(RentUpdateModel rent)
        {
            var existing = await this.Get(rent);

            var result = this.Mapper.Map(rent, existing);

            this.Context.Update(result);

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<Rent>(result);
        }

        public async Task<Rent> GetByAsync(IRentContainer rent)
        {
            return rent.RentId.HasValue 
                ? this.Mapper.Map<Rent>(await this.Context.Rent.FirstOrDefaultAsync(x => x.Id == rent.RentId)) 
                : null;
        }
    }
}