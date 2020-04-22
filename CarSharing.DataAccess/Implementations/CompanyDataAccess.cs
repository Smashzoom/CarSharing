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
    public class CompanyDataAccess : ICompanyDataAccess
    {
        private CompanyContext Context { get; }
        private IMapper Mapper { get; }

        public CompanyDataAccess(CompanyContext context, IMapper mapper)
        {
            this.Context = context;
            Mapper = mapper;
        }

        public async Task<Company> InsertAsync(CompanyUpdateModel company)
        {
            var result = await this.Context.AddAsync(this.Mapper.Map<DataAccess.Entities.Company>(company));

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<Company>(result.Entity);
        }

        public async Task<IEnumerable<Company>> GetAsync()
        {
            return this.Mapper.Map<IEnumerable<Company>>(
                await this.Context.Company.ToListAsync());

        }

        public async Task<Company> GetAsync(ICompanyIdentity company)
        {
            var result = await this.Get(company);

            return this.Mapper.Map<Company>(result);
        }

        public async Task<Company> UpdateAsync(CompanyUpdateModel company)
        {
            var existing = await this.Get(company);

            var result = this.Mapper.Map(company, existing);

            this.Context.Update(result);

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<Company>(result);
        }

        public async Task<Company> GetByAsync(ICompanyContainer company)
        {
            return company.CompanyId.HasValue 
                ? this.Mapper.Map<Company>(await this.Context.Company.FirstOrDefaultAsync(x => x.Id == company.CompanyId)) 
                : null;
        }

        private async Task<CarSharing.DataAccess.Entities.Company> Get(ICompanyIdentity company)
        {
            if(company == null)
                throw new ArgumentNullException(nameof(company));
            return await this.Context.Company.FirstOrDefaultAsync(x => x.Id == company.Id);
        }
    }
}