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
    [Route("api/rent")]
    public class RentController
    {
        private ILogger<RentController> Logger { get; }
        private IRentCreateService RentCreateService { get; }
        private IRentGetService RentGetService { get; }
        private IRentUpdateService RentUpdateService { get; }
        private IMapper Mapper { get; }

        public RentController(ILogger<RentController> logger, IMapper mapper, IRentCreateService rentCreateService, IRentGetService rentGetService, IRentUpdateService rentUpdateService)
        {
            this.Logger = logger;
            this.RentCreateService = rentCreateService;
            this.RentGetService = rentGetService;
            this.RentUpdateService = rentUpdateService;
            this.Mapper = mapper;
        }

        [HttpPut]
        [Route("")]
        public async Task<RentDTO> PutAsync(RentCreateDTO rent)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.RentCreateService.CreateAsync(this.Mapper.Map<RentUpdateModel>(rent));

            return this.Mapper.Map<RentDTO>(result);
        }

        [HttpPatch]
        [Route("")]
        public async Task<RentDTO> PatchAsync(RentUpdateDTO rent)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.RentUpdateService.UpdateAsync(this.Mapper.Map<RentUpdateModel>(rent));

            return this.Mapper.Map<RentDTO>(result);
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<RentDTO>> GetAsync()
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called");

            return this.Mapper.Map<IEnumerable<RentDTO>>(await this.RentGetService.GetAsync());
        }

        [HttpGet]
        [Route("{rentId}")]
        public async Task<RentDTO> GetAsync(int rentId)
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called for {rentId}");

            return this.Mapper.Map<RentDTO>(await this.RentGetService.GetAsync(new RentIdentityModel(rentId)));
        }
    }
}