using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Vaultix.APIs;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.ProjectOxford.Vision;
using Microsoft.ProjectOxford.Vision.Contract;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Vaultix.Controllers
{
    [Route("api/[controller]")]
    public class ImagesController : Controller
    {
        // GET: api/images
        [HttpPost]
        public async Task<OcrResults> OCRAnalysis([FromBody]string imageUrl)
        {
            VisionServiceClient VisionServiceClient = new VisionServiceClient(Config.COMPUTER_VISION_API_KEY);
            OcrResults ocrResult = await VisionServiceClient.RecognizeTextAsync(imageUrl, "en");
            return ocrResult;
        }

        // GET api/images/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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
