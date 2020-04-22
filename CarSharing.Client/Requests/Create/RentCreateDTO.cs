using System.ComponentModel.DataAnnotations;

namespace CarSharing.Client.Requests.Create
{
    public class RentCreateDTO
    {
        //Местонахождение автомобиля
        [Required(ErrorMessage = "Location is required")]
        public string Location { get; set; }
        
        //Дата доступности
        [Required(ErrorMessage = "Date is required")]
        public string Date { get; set; }
        
        public int? CarId{ get; set; }

        public int? CompanyId { get; set; }
    }
}