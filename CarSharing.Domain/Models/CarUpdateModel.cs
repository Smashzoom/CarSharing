using CarSharing.Domain.Contracts;

namespace CarSharing.Domain.Models
{
    public class CarUpdateModel : ICarIdentity
    {
        public int Id { get; set; }

        //Марка
        public string Make { get; set; }

        //Модель
        public string ModelName { get; set; }

        //Цена за минуту
        public string Price { get; set; }

        //Год выпуска
        public int Year { get; set; }
    }
}