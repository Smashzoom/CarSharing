using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarSharing.DataAccess.Entities
{
    public class Rent
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //Id
        public int Id { get; set; }
        
        //Местонахождение автомобиля
        public string Location { get; set; }
        
        //Дата доступности
        public string Date { get; set; }
        
        public int? CarId { get; set; }
        
        public int? CompanyId { get; set; }

        public virtual Car Car { get; set; }

        public virtual Company Company { get; set; }
    }
}