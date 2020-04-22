using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarSharing.DataAccess.Entities
{
    public class Company
    {
        public Company()
        {
            this.Rent = new HashSet<Rent>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual ICollection<Rent> Rent { get; set; }

        //Id
        public int Id { get; set; }

        //Название компании
        public string Name { get; set; }

        //Юридический адрес компании
        public string Address { get; set; }
    }
}