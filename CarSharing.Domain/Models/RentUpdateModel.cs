using CarSharing.Domain.Contracts;

namespace CarSharing.Domain.Models
{
    public class RentUpdateModel : IRentIdentity, ICarContainer, ICompanyContainer
    {
        public int Id { get; set; }
        
        //Местонахождение автомобиля
        public string Location { get; set; }
        
        //Дата доступности
        public string Date { get; set; }
        
        public int? CarId { get; set; }
        public int? CompanyId { get; set; }
    }
}