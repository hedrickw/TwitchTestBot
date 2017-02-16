using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TwitchChatBot
{
  public class Program
    {
        public static void Main(string[] args)
        {
            string urlToRequest = "https://api.twitch.tv/kraken";

            var request = WebRequest.Create(urlToRequest);
            request.Headers.Add("Client-ID: lyf7vi5gq1sh3g1j4oovlm4jfe77sx");
            var stuff = request.GetResponse();

            using (var reader = new StreamReader(stuff.GetResponseStream()))
            {
                var moarStuff = JsonConvert.DeserializeObject(reader.ReadToEnd());
            }
              //  var response = JsonConvert.DeserializeObject(stuff.ToString());
        }
    }
}
