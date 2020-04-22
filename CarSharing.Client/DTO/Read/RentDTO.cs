namespace CarSharing.Client.DTO.Read
{
    public class RentDTO
    {
        //Id
        public int Id { get; set; }

        //Местонахождение автомобиля
        public string Location { get; set; }
        
        //Дата доступности
        public string Date { get; set; }

        public CompanyDTO Company { get; set; }
        
        public CarDTO Car{ get; set; }
    }
}