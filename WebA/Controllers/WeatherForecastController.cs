using Microsoft.AspNetCore.Mvc;

namespace WebA.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MyControllers : ControllerBase
    {
        public static List<MyModel> models = new List<MyModel>()
        {
            new MyModel(){Id = 1, Age = 20, Name = "Vadim"},
            new MyModel(){Id = 2, Age = 20, Name = "Nikita"}
        };
        [HttpGet]
        public IEnumerable<MyModel> Get()
        {
            return models;
        }
    }
}
