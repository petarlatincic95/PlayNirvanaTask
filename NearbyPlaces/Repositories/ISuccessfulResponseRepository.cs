using NearbyPlaces.Model;

namespace NearbyPlaces.Reositories
{
    public interface ISuccessfulResponseRepository
    {
        Task AddResponse(SuccessfulResponseModel response);
        Task<ICollection<SuccessfulResponseModel>> GetAllResponses();
        Task SaveChanges();
    }
    
}
