using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarSharing.DataAccess.Entities
{
    public class Car
    {
        public Car()
        {
            this.Rent = new HashSet<Rent>();
        }
        
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //Id
        public int Id { get; set; }
        
        //Марка
        public string Make { get; set; }

        //Модель
        public string ModelName { get; set; }

        //Цена за минуту
        public string Price { get; set; }

        //Год выпуска
        public int Year { get; set; }
        
        public virtual ICollection<Rent> Rent { get; set; }
    }
}