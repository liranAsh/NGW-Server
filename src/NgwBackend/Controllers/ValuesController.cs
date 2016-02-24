using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Newtonsoft.Json.Linq;
using NgwBackend.Models.Utilities;
using MongoDB.Driver;
using MongoDB.Bson;
using Newtonsoft.Json;

namespace NgwBackend.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET: api/values
        [HttpGet]
        public JArray Get()
        {
            /* JObject x =new JObject();
            x["operationName"] = "Liran - Server";
            x["date"] = "23/2/2015";

            JObject y = new JObject();
            y["operationName"] = "Ziv - Server";
            y["date"] = "23/2/2015";

            JArray result = new JArray();

            result.Add(x);
            result.Add(y);

            return result;
            //return new string[] { "value1", "value2" };
            */
            
            IMongoCollection<BsonDocument> collection = Dal.getInstance().GetCollection("Persons");
            var resultBson = collection.Find(new BsonDocument()).ToList();

            string stringJson = BsonExtensionMethods.ToJson(resultBson);
            JArray json = JsonConvert.DeserializeObject<JArray>(stringJson);

            return json;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
