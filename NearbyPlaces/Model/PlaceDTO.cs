namespace NearbyPlaces.Model
{
    public class PlaceDTO
    {
        public string name { get; set; }
        public string place_id { get; set; }
        public float rating { get; set; }
        public string vicinity { get; set; }
        public string[] types { get; set; }
    }
}
