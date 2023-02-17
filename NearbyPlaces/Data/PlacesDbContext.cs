using Microsoft.EntityFrameworkCore;
using NearbyPlaces.Model;
using NearbyPlaces.Reositories;

namespace NearbyPlaces.Data
{
    public class PlacesDbContext:DbContext
    {
        public PlacesDbContext(DbContextOptions<PlacesDbContext>options):base(options)
        {

        }
        
        public DbSet<SuccessfulRequestModel> SuccessfulRequests { get; set; }
        public DbSet<SuccessfulResponseModel> SuccessfulResponses{ get; set; }
       
    }
}
