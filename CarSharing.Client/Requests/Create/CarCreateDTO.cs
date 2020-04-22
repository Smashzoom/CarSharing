using System.ComponentModel.DataAnnotations;

namespace CarSharing.Client.Requests.Create
{
    public class CarCreateDTO
    {
        //Марка
        [Required(ErrorMessage = "Make is required")]
        public string Make { get; set; }

        //Модель
        [Required(ErrorMessage = "ModelName is required")]
        public string ModelName { get; set; }

        //Цена за минуту
        [Required(ErrorMessage = "Price is required")]
        public string Price { get; set; }

        //Год выпуска
        [Required(ErrorMessage = "Year is required")]
        public int Year { get; set; }
    }
}