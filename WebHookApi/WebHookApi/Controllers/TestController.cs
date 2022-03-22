using Microsoft.AspNetCore.Mvc;

namespace WebHookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private static readonly List<string> Values = new();

        // GET: api/Test
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return Values;
        }

        // GET api/Test/1
        [HttpGet("{id}")]
        public string Get(int id)
        {
            var value = string.Empty;
            if (id >= 0 && id < Values.Count)
            {
                value = Values[id];
            }
            return value;
        }

        // POST api/Test
        [HttpPost]
        public void Post([FromBody] object value)
        {
            Values.Add(value.ToString());
        }

        // PUT api/Test/1
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            if (id >= 0 && id < Values.Count)
            {
                Values[id] = value;
            }
        }

        // DELETE api/Test/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (id >= 0 && id < Values.Count)
            {
                Values.RemoveAt(id);
            }
        }
    }
}
