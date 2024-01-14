using Microsoft.AspNetCore.Mvc;

namespace ArtifyGen.Controllers
{
    public class ImageGenController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Generate(string desc, IFormFile formFile)
        {
            byte[] image;
            using (var stream = formFile.OpenReadStream())
            using (var reader = new BinaryReader(stream))
            {
                var byteFile = reader.ReadBytes((int)stream.Length);
                image = byteFile;
            }

            return View();
        }

    }
}
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using System.Collections.Generic;
//using System.IO;
//using System.Net.Http;
//using System.Threading.Tasks;

//namespace ArtifyGen.Controllers
//{
//    public static class MimeTypeMap
//    {
//        private static readonly Dictionary<string, string> _mappings = new Dictionary<string, string>
//        {
//            { "image/jpeg", "jpg" },
//            { "image/png", "png" },
//        };

//        public static string GetExtension(string contentType)
//        {
//            return _mappings.TryGetValue(contentType, out var extension) ? extension : "dat";
//        }
//    }

//    [ApiController]
//    [Route("api/[controller]")]
//    public class ImageGenController : ControllerBase
//    {
//        private readonly IHttpClientFactory _httpClientFactory;

//        public ImageGenController(IHttpClientFactory httpClientFactory)
//        {
//            _httpClientFactory = httpClientFactory;
//        }

//        [HttpGet]
//        public IActionResult Index()
//        {
//            return Ok("API is running");
//        }

//        [HttpPost("Generate")]
//        public async Task<IActionResult> Generate([FromForm] string desc, [FromForm] IFormFile formFile)
//        {
//            if (formFile == null || formFile.Length == 0)
//            {
//                return BadRequest("Invalid file");
//            }

//            byte[] image;
//            using (var stream = formFile.OpenReadStream())
//            using (var reader = new BinaryReader(stream))
//            {
//                var byteFile = reader.ReadBytes((int)stream.Length);
//                image = byteFile;
//            }
//            await ForwardDataToExternalApi(desc, image, formFile.ContentType);
//            return Ok(new { Description = desc, ImageSize = image.Length });
//        }

//        private async Task ForwardDataToExternalApi(string desc, byte[] image, string contentType)
//        {
//            var apiEndpoint = "https://example.com/api/external";
//            var fileExtension = MimeTypeMap.GetExtension(contentType);

//            using (var httpClient = _httpClientFactory.CreateClient())
//            using (var content = new MultipartFormDataContent())
//            {
//                content.Add(new StringContent(desc), "desc");
//                content.Add(new ByteArrayContent(image), "formFile", $"image.{fileExtension}");

//                var response = await httpClient.PostAsync(apiEndpoint, content);
//            }
//        }
//    }
//}
