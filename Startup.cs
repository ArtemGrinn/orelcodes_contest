using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Empty
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {       
            app.Run(async (context) =>
            {
                if (context.Request.Method == "GET")
                await context.Response.WriteAsync("Running... give me a POST!");
                
                if (context.Request.Method == "POST")
                using (var reader = new StreamReader(context.Request.Body))
                using (var md5Hash = MD5.Create())
                {
                    var body = reader.ReadToEnd();
                    var json = JsonConvert.DeserializeObject<JsonModel>(body);
                    json.first_name += GetMd5Hash(md5Hash, json.first_name);
                    json.last_name += GetMd5Hash(md5Hash, json.last_name);
                    
                    context.Response.Headers.Add("Contetnt-Type", "application/json");
                    await context.Response.WriteAsync(JsonConvert.SerializeObject(json));                    
                }
            });
        }

        private static string GetMd5Hash(MD5 md5Hash, string input)
        {
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));	
            var sBuilder = new StringBuilder();	
            sBuilder.Append(" ");	
            for (byte i = 0; i < data.Length; i++)		
                sBuilder.Append(data[i].ToString("x2"));	
            
            return sBuilder.ToString();
        }      
    }

    public class JsonModel
    {
        public string id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string current_time => DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss zzz");
        public string say => "C# is best!";
    }
}
