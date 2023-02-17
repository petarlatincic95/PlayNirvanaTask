using Microsoft.AspNetCore.Mvc;
using NearbyPlaces.Model;
using NearbyPlaces.Reositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NearbyPlaces.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestsController : ControllerBase
    {
        private ISuccessfulRequestRepository _requestRepository;
        public RequestsController(ISuccessfulRequestRepository requestRepository)
        {
            _requestRepository=requestRepository;
        }
        // GET: api/<RequestsController>
        [HttpGet]
        public async Task<ICollection<SuccessfulRequestModel>> Get()
        {
            var requests = await _requestRepository.GetAllRequest();
            return requests;
            
        }

       
    }
}
