using CarSharing.Client.Requests.Create;

namespace CarSharing.Client.Requests.Update
{
    public class CarUpdateDTO : CarCreateDTO
    {
        public int Id { get; set; }
    }
}