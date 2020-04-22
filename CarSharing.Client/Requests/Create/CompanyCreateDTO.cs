using System.ComponentModel.DataAnnotations;

namespace CarSharing.Client.Requests.Create
{
    public class CompanyCreateDTO
    {
        //Название компании
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        //Юридический адрес компании
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
    }
}