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
    [Route("api/car")]
    public class CarController : ControllerBase
    {
        private ILogger<CarController> Logger { get; }
        private ICarCreateService CarCreateService { get; }
        private ICarGetService CarGetService { get; }
        private ICarUpdateService CarUpdateService { get; }
        private IMapper Mapper { get; }

        public CarController(ILogger<CarController> logger, IMapper mapper, ICarCreateService carCreateService, ICarGetService carGetService, ICarUpdateService carUpdateService)
        {
            this.Logger = logger;
            this.CarCreateService = carCreateService;
            this.CarGetService = carGetService;
            this.CarUpdateService = carUpdateService;
            this.Mapper = mapper;
        }

        [HttpPut]
        [Route("")]
        public async Task<CarDTO> PutAsync(CarCreateDTO car)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.CarCreateService.CreateAsync(this.Mapper.Map<CarUpdateModel>(car));

            return this.Mapper.Map<CarDTO>(result);
        }

        [HttpPatch]
        [Route("")]
        public async Task<CarDTO> PatchAsync(CarUpdateDTO car)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.CarUpdateService.UpdateAsync(this.Mapper.Map<CarUpdateModel>(car));

            return this.Mapper.Map<CarDTO>(result);
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<CarDTO>> GetAsync()
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called");

            return this.Mapper.Map<IEnumerable<CarDTO>>(await this.CarGetService.GetAsync());
        }

        [HttpGet]
        [Route("{carId}")]
        public async Task<CarDTO> GetAsync(int carId)
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called for {carId}");

            return this.Mapper.Map<CarDTO>(await this.CarGetService.GetAsync(new CarIdentityModel(carId)));
        }
    }
}