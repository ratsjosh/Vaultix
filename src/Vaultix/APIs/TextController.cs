using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Vaultix.Utils;
using Newtonsoft.Json;

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
                //%20
                using (var client = new HttpClient())
                {
                    // We'll obtain the accesstoken from the static utils class
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + WitAiUtils._accessToken);

                    HttpResponseMessage response =
                        client.GetAsync("https://api.wit.ai/message?v=20170307&q=" +

                        // Made a bit of searching via http://packagesearch.azurewebsites.net
                        // to retrieve the exact method to utilize for URL encoding
                        System.Net.WebUtility.UrlDecode(message)).Result;

                    // If the call is successful
                    if (response.IsSuccessStatusCode)
                    {
                        // Retrieve the result of the response
                        var msg = response.Content.ReadAsStringAsync().Result;

                        // Reading a JsonObject
                        // https://damienpontifex.github.io/net-core-web-request
                        return new JsonResult(JsonConvert.DeserializeObject(msg));
                    }
                }

                return new JsonResult("HttpClient Failed Somehow");
            } catch (Exception ex) {
                return new JsonResult(ex.ToString());
            }
        }

        private string ConvertToURL(string message)
        {
            throw new NotImplementedException();
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
