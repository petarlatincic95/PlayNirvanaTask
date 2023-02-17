using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NearbyPlaces.Data;
using NearbyPlaces.Hubs;
using NearbyPlaces.Model;
using NearbyPlaces.Reositories;
using Newtonsoft.Json;
using RestSharp;
using System.Net;
using System.Net.Http.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NearbyPlaces.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlacesController : ControllerBase
    {
        private ISuccessfulRequestRepository _requestRepository;
        private ISuccessfulResponseRepository _responseRepository;
        private SuccessfulRequestModel requestToAdd = new SuccessfulRequestModel();
        private SuccessfulResponseModel responseToAdd=new SuccessfulResponseModel() ;
        public PlacesController(ISuccessfulRequestRepository requestRepository, ISuccessfulResponseRepository responseRepository)
        {
            _requestRepository = requestRepository;
            _responseRepository = responseRepository;
        }
        public record struct Place();
        
        [HttpGet("{location}")]
        public async Task<IActionResult> Get(string location)
        {

            var s = location.Split(',');
            if (s.Length != 2)
                return BadRequest();
            else
            {
                var mykey = "Enter your GoogleAPI key HERE!";

                string lat = s[0].Trim();
                string lng = s[1].Trim(); ;

                string url = $"https://maps.googleapis.com/maps/api/place/nearbysearch/json?location={lat},{lng}&radius=5000&key={mykey}";
                HttpClient client = new HttpClient();
                HttpResponseMessage responseMessage = await client.GetAsync(url);
                var responseContent = responseMessage.Content.ReadAsStringAsync();
              
                if (responseMessage.IsSuccessStatusCode)
                {
                    requestToAdd.RequestSentTime = DateTime.Now;
                    requestToAdd.Latitude = lat;
                    requestToAdd.Longitude = lng;
                    await _requestRepository.AddRequest(requestToAdd);
                    await _requestRepository.SaveChanges();
                    
                 

                    responseToAdd.ResponseContent = await responseContent;
                    await _responseRepository.AddResponse(responseToAdd);
                    await _responseRepository.SaveChanges();


                    var obj = JsonConvert.DeserializeObject<Rootobject>(responseContent.Result);
                    var rootObjDTOList = new List<PlaceDTO>();
                    for (int i = 0; i < obj.results.Length; i++)
                    {
                        rootObjDTOList.Add(new PlaceDTO(){
                            name= obj.results[i].name,
                            place_id = obj.results[i].place_id,
                            types=obj.results[i].types,
                            vicinity=obj.results[i].vicinity,
                            rating=obj.results[i].rating
                        });
                        
                    }

                    
                    string rootObjDtoListString=JsonConvert.SerializeObject(rootObjDTOList);
                    return Ok(rootObjDtoListString);
                  
                }
                else
                    return BadRequest();

            }

        }

       
        
    }
}

