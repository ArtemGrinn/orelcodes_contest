using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("/")]
    [ApiController]
    public class ValuesController : Controller
    {
        private const string DateFormat = "yyyy-MM-dd HH:mm:ss zzz";
        [HttpGet]
        public ActionResult Get() 
        {
            var time = DateTime.Now.ToString(DateFormat);
            using (var md5Hash = MD5.Create())
                return Content($"{time} {GetMd5Hash(md5Hash, time)}");
        }

        [HttpPost]
        public JsonResult Post([FromBody] JsonModel data)
        {
            using (var md5Hash = MD5.Create())
            {
                data.first_name += $" {GetMd5Hash(md5Hash, data.first_name)}";
                data.last_name += $" {GetMd5Hash(md5Hash, data.last_name)}";
            }
            data.say = "C# is best!";
            data.current_time = DateTime.Now.ToString(DateFormat);
            return Json(data);
        }

        private static string GetMd5Hash(MD5 md5Hash, string input) 
            =>  BitConverter.ToString(md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input)));
    }

    public class JsonModel
    {
        public string id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string current_time { get; set; }
        public string say { get; set; }
    }
}
