using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebHookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private static readonly List<string> Values = new();

        // GET: api/<TestController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            //return new string[] { "value1", "value2" };
            return Values;
        }

        // GET api/<TestController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            //return "value";
            var value = string.Empty;
            if (id >= 0 && id < Values.Count)
            {
                value = Values[id];
            }
            return value;
        }

        // POST api/<TestController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            if (!string.IsNullOrWhiteSpace(value) &&
                !Values.Exists(x => string.Equals(x, value, StringComparison.CurrentCultureIgnoreCase)))
            {
                Values.Add(value);
            }
        }

        // PUT api/<TestController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            if (id >= 0 && id < Values.Count)
            {
                Values[id] = value;
            }
        }

        // DELETE api/<TestController>/5
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
