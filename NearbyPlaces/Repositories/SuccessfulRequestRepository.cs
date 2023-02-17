using Microsoft.EntityFrameworkCore;
using NearbyPlaces.Data;
using NearbyPlaces.Model;

namespace NearbyPlaces.Reositories
{
    public class SuccessfulRequestRepository : ISuccessfulRequestRepository
    {
        private PlacesDbContext _dbContext;
        public SuccessfulRequestRepository(PlacesDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task  AddRequest(SuccessfulRequestModel request)
        {
            var requestToAdd = request;
           
           
                await _dbContext.SuccessfulRequests.AddAsync(requestToAdd);
           
           
            
        }

        public async Task<ICollection<SuccessfulRequestModel>> GetAllRequest()
        {
            var requests = await _dbContext.SuccessfulRequests.ToListAsync();
            return requests;
        }

        public async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
