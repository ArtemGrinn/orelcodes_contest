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
        [HttpGet]
        public ActionResult Get()
        {
            return Content(DateTime.Now.ToString("yyyy-MM-dd HH:mm zzz"));
        }

        [HttpPost]
        public JsonResult Post([FromBody] JsonModel data)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                data.first_name += JsonModel.GetMd5Hash(md5Hash, data.first_name);
                data.last_name += JsonModel.GetMd5Hash(md5Hash, data.last_name);
            }
            data.say = "C# is best!";
            data.current_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm zzz");
            return Json(data);
        }
    }

    
    public class JsonModel
    {
        public string id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string current_time { get; set; }
        public string say { get; set; }
        
        public static string GetMd5Hash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            sBuilder.Append(" ");
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

    }
}
