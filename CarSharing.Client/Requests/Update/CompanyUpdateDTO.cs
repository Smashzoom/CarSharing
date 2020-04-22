using CarSharing.Client.Requests.Create;

namespace CarSharing.Client.Requests.Update
{
    public class CompanyUpdateDTO : CompanyCreateDTO
    {
        public int Id { get; set; }
    }
}