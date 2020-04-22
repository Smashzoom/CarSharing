using CarSharing.Client.Requests.Create;

namespace CarSharing.Client.Requests.Update
{
    public class RentUpdateDTO : RentCreateDTO
    {
        public int Id { get; set; }
    }
}