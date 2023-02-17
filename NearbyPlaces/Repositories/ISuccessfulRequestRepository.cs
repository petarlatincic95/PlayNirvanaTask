using NearbyPlaces.Model;

namespace NearbyPlaces.Reositories
{
    public interface ISuccessfulRequestRepository
    {
        Task AddRequest(SuccessfulRequestModel request);
        Task<ICollection<SuccessfulRequestModel>>GetAllRequest();
        Task SaveChanges();
    }
    
}
