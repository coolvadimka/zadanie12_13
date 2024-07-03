using Microsoft.AspNetCore.Mvc;

namespace zadanie19.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MyControllers : ControllerBase
    {
        private readonly IUser piska;
        public static List<MyModel> Users = new List<MyModel>();

        public MyControllers(IUser piska)
        {
            this.piska = piska;
        }
        [HttpPost]
        public ActionResult<MyModel> Post([FromBody] MyModel model)
        {
            var user = piska.Change(model);
            Users.Add(user);
            return Ok(user);
        }
        [HttpGet]
        public ActionResult<IEnumerable<MyModel>> GetAll() {
            return Ok(Users);
        }
    }
}
