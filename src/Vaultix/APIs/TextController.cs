using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Vaultix.Utils;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Vaultix.APIs
{
    [Route("api/[controller]")]
    public class TextController : Controller
    {
        // GET: api/values
        // Implementing asynchronous tasks
        // http://stackoverflow.com/questions/38309165/how-to-consume-a-asp-net-core-webapi-in-a-c-sharp-uwp-application
        [HttpGet]
        public async Task<JsonResult> Get(string message)
        {
            try
            {
                using (var client = new HttpClient())
                {

                    // We'll obtain the accesstoken from the static utils class
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + WitAiUtils._accessToken);

                    var response =
                        await client.GetStringAsync("https://api.wit.ai/message?v=20170307&q=" + message);
                    
                }

                return new JsonResult(Response);
            } catch (Exception ex) {
                return new JsonResult(ex.ToString());
            }
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
