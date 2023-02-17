namespace NearbyPlaces.Model
{
    public class SuccessfulRequestModel
    {
        public int Id { get; set; }
        public DateTime RequestSentTime { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

    }
}
