using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CarSharing.BLL.Contracts;
using CarSharing.Client.DTO.Read;
using CarSharing.Client.Requests.Create;
using CarSharing.Client.Requests.Update;
using CarSharing.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CarSharing.WebAPI.Controllers
{
    [ApiController]
    [Route("api/company")]
    public class CompanyController
    {
        private ILogger<CompanyController> Logger { get; }
        private ICompanyCreateService CompanyCreateService { get; }
        private ICompanyGetService CompanyGetService { get; }
        private ICompanyUpdateService CompanyUpdateService { get; }
        private IMapper Mapper { get; }

        public CompanyController(ILogger<CompanyController> logger, IMapper mapper, ICompanyCreateService companyCreateService, ICompanyGetService companyGetService, ICompanyUpdateService companyUpdateService)
        {
            this.Logger = logger;
            this.CompanyCreateService = companyCreateService;
            this.CompanyGetService = companyGetService;
            this.CompanyUpdateService = companyUpdateService;
            this.Mapper = mapper;
        }

        [HttpPut]
        [Route("")]
        public async Task<CompanyDTO> PutAsync(CompanyCreateDTO car)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.CompanyCreateService.CreateAsync(this.Mapper.Map<CompanyUpdateModel>(car));

            return this.Mapper.Map<CompanyDTO>(result);
        }

        [HttpPatch]
        [Route("")]
        public async Task<CompanyDTO> PatchAsync(CompanyUpdateDTO company)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.CompanyUpdateService.UpdateAsync(this.Mapper.Map<CompanyUpdateModel>(company));

            return this.Mapper.Map<CompanyDTO>(result);
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<CompanyDTO>> GetAsync()
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called");

            return this.Mapper.Map<IEnumerable<CompanyDTO>>(await this.CompanyGetService.GetAsync());
        }

        [HttpGet]
        [Route("{companyId}")]
        public async Task<CompanyDTO> GetAsync(int companyId)
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called for {companyId}");

            return this.Mapper.Map<CompanyDTO>(await this.CompanyGetService.GetAsync(new CompanyIdentityModel(companyId)));
        }
    }
}