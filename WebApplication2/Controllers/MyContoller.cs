using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyContoller : Controller
    {
        private static List<MyModels> models = new List<MyModels>()
        {
            new MyModels(){Id = 1, Age = 20, Name = "Vadim" },
            new MyModels {Id = 2, Name = "Nikita", Age = 54 }
        };

        [HttpGet]
        public ActionResult<IEnumerable<MyModels>> GetAll()
        {
            return Ok(models);
        }
        [HttpGet("{id}")]
        public ActionResult<MyModels> Get(int id)
        {
            var model = models.FirstOrDefault(x => x.Id == id);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }
        [HttpDelete("{id}")]
        public ActionResult<MyModels> Delete(int id)
        {
            var model = models.FirstOrDefault(x => x.Id == id);
            if(model == null)
            {
                return NotFound();
            }
            models.Remove(model);
            return NoContent();

        }
        [HttpPost]
        public ActionResult Post([FromBody] MyModels model)
        {
            models.Add(model);
            return Ok(model);
        }
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromQuery] MyModels newmodel)
        {
            var model = models.FirstOrDefault(x => x.Id == id);
            if(model == null)
            {
                return NotFound();
            }
            model.Age = newmodel.Age;
            model.Name = newmodel.Name;
            return NoContent();
        }

    }
}
