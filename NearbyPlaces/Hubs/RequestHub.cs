using Microsoft.AspNetCore.SignalR;
using NearbyPlaces.Model;
using NearbyPlaces.Reositories;

namespace NearbyPlaces.Hubs
{
    public class RequestHub:Hub
    {
        private ISuccessfulRequestRepository _requestRepository;
        
        public RequestHub(ISuccessfulRequestRepository requestRepository)
        {
            _requestRepository= requestRepository;
        }
        
        public static int TotalSuccessfulRequests { get; set; } = 0;
      
        public async Task NewSuccessfullRequest()
        {
               
                TotalSuccessfulRequests++;
                //Updating clients that there have been new successful place search
                await Clients.All.SendAsync("updateTotalSuccessfulRequests", TotalSuccessfulRequests);
            
        }
    }
}
