using AutoMapper;
using CarSharing.Client.DTO.Read;
using CarSharing.Client.Requests.Create;
using CarSharing.Client.Requests.Update;
using CarSharing.Domain.Models;

namespace CarSharing.WebAPI
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<DataAccess.Entities.Company, Domain.Company>();
            this.CreateMap<DataAccess.Entities.Car, Domain.Car>();
            this.CreateMap<DataAccess.Entities.Rent, Domain.Rent>();
            this.CreateMap<Domain.Company, CompanyDTO>();
            this.CreateMap<Domain.Car, CarDTO>();
            this.CreateMap<Domain.Rent, RentDTO>();
            
            this.CreateMap<CompanyCreateDTO, CompanyUpdateModel>();
            this.CreateMap<CompanyUpdateDTO, CompanyUpdateModel>();
            this.CreateMap<CompanyUpdateModel, DataAccess.Entities.Company>();
            
            this.CreateMap<CarCreateDTO, CarUpdateModel>();
            this.CreateMap<CarUpdateDTO, CarUpdateModel>();
            this.CreateMap<CarUpdateModel, DataAccess.Entities.Car>();
            
            this.CreateMap<RentCreateDTO, RentUpdateModel>();
            this.CreateMap<RentUpdateDTO, RentUpdateModel>();
            this.CreateMap<RentUpdateModel, DataAccess.Entities.Rent>();
        }
    }
}