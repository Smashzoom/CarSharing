using CarSharing.Domain.Contracts;

namespace CarSharing.Domain.Models
{
    public class CompanyUpdateModel : ICompanyIdentity
    {
        public int Id { get; set; }
        
        //Название компании
        public string Name { get; set; }

        //Юридический адрес компании
        public string Address { get; set; }
    }
}