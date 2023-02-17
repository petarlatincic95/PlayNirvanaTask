using Microsoft.AspNetCore.Mvc;
using NearbyPlaces.Model;
using NearbyPlaces.Reositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NearbyPlaces.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponsesController : ControllerBase
    {
        private ISuccessfulResponseRepository _responseRepository;
        public ResponsesController(ISuccessfulResponseRepository responseRepository)
        {
            _responseRepository=responseRepository; 
        }
        // GET: api/<ResponsesController>
        [HttpGet]
        public async Task<ICollection<SuccessfulResponseModel>> Get()
        {
            var responses=await _responseRepository.GetAllResponses();
            return responses;
        }

      
    }
}
