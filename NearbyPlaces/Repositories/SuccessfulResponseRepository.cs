using Microsoft.EntityFrameworkCore;
using NearbyPlaces.Data;
using NearbyPlaces.Model;
using NearbyPlaces.Reositories;

namespace NearbyPlaces.Repositories
{
    public class SuccessfulResponseRepository : ISuccessfulResponseRepository
    {
        private PlacesDbContext _dbContext;
        public SuccessfulResponseRepository(PlacesDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddResponse(SuccessfulResponseModel response)
        {
           await  _dbContext.SuccessfulResponses.AddAsync(response);
           
        }

        public async Task<ICollection<SuccessfulResponseModel>> GetAllResponses()
        {
            var responses = await _dbContext.SuccessfulResponses.ToListAsync();
            return responses;

        }

        public async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();

        }
    }
}
