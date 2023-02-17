using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.JSInterop;
using NearbyPlaces.Hubs;
using NearbyPlaces.Model;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace NearbyPlaces.Pages
{

    public class IndexModel : PageModel
    {
   

        [BindProperty]
        public string latitude { get; set; }
        [BindProperty]
        public string longitude { get; set; }
        public List<PlaceDTO> places { get; set; } = new List<PlaceDTO>();
        private readonly ILogger<IndexModel> _logger;
        public PlaceDTO placeDTO;
        public List<string> PlaceTypesList=new List<string>();
        public bool p1=true;
        public bool p2 = false;
        public IJSRuntime _ijsRuntime { get; set; }




        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
           

        }

        public void OnGet()
        {
            

        }
        public async Task<IActionResult> OnPost()
        {
            HttpClient client = new HttpClient();
            double la = 0.0;
            double lo = 0.0;
            p1 = double.TryParse(latitude, out la);
            p2 = double.TryParse(longitude, out lo);

            if (p1 == false || p2== false)
            {
                return RedirectToPage("/Index");

            }


            HttpResponseMessage responseMessage = await client.GetAsync($"https://localhost:44326/api/places/{latitude},{longitude}");
           
                var responseContent = responseMessage.Content.ReadAsStringAsync();
                places = JsonConvert.DeserializeObject<List<PlaceDTO>>(responseContent.Result);

            
                return Page();






            
        }
    }
}