using System.ComponentModel.DataAnnotations;

namespace NearbyPlaces.Model
{
    public class SuccessfulResponseModel
    {
        [Key]
        public int Id { get; set; }
        public string ResponseContent { get; set; }
    }
}
