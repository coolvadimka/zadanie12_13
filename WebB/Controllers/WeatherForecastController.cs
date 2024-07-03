using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
namespace WebB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MyControllers : ControllerBase
    {
        private readonly HttpClient _httpClient;
        public MyControllers(IHttpClientFactory httpFactory)
        {
            _httpClient = httpFactory.CreateClient();
        }
        [HttpGet]
        public async Task<IEnumerable<MyModel>> Get()
        {
            var response = await _httpClient.GetStringAsync("https://localhost:7271/MyControllers");
            var mymodels = JsonConvert.DeserializeObject<List<MyModel>>(response);
            return mymodels;
        }
    }
}
