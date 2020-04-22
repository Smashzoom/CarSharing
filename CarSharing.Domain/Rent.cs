using CarSharing.Domain.Contracts;

namespace CarSharing.Domain
{
    public class Rent : ICompanyContainer, ICarContainer
    {
        //Id
        public int Id { get; set; }

        //Местонахождение автомобиля
        public string Location { get; set; }
        
        //Дата доступности
        public string Date { get; set; }
        
        public Car Car{ get; set; }

        public Company Company { get; set; }
        
        public int? CompanyId => Company.Id;

        public int? CarId => Car.Id;
    }
}