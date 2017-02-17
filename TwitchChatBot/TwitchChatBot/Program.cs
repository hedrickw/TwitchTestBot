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
            //Console.WriteLine("Enter Channel Name you want information on");
            //var channelName = Console.ReadLine();
            UpdatePersonalTwitchChannelInfo("", "", "");
            //GetTwitchChannelInfo(channelName);
        }

        public static void GetTwitchChannelInfo(string channelName)
        {
            string urlToRequest = "https://api.twitch.tv/kraken/channels" + "/" + $"{channelName}";

            var request = WebRequest.Create(urlToRequest);
            request.Headers.Add("Client-ID: lyf7vi5gq1sh3g1j4oovlm4jfe77sx");
            var stuff = request.GetResponse();

            using (var reader = new StreamReader(stuff.GetResponseStream()))
            {
                var moarStuff = JsonConvert.DeserializeObject(reader.ReadToEnd()).ToString();

                Console.WriteLine(moarStuff);
            }

            Console.ReadLine();
        }

        //public static AuthenticateStuff()
        //{
        //    string urlToSend = @"https://api.twitch.tv/kraken/oauth2/authorize?response_type=token&client_id=lyf7vi5gq1sh3g1j4oovlm4jfe77sx&redirect_uri=http://localhost/TestingThis&scope=channel_editor&state=w51d28xtnez1ydui9sa6fv2jot4sq2";
        //}

        public static void UpdatePersonalTwitchChannelInfo(string game, string status, string delay)
        {
            string urlToRequest = "https://api.twitch.tv/kraken/channels" + "/" + $"25666162";

            var request = (HttpWebRequest)WebRequest.Create(urlToRequest);
            
            request.Headers.Add("Client-ID: lyf7vi5gq1sh3g1j4oovlm4jfe77sx");
            request.Accept = "application/vnd.twitchtv.v3+json";
            request.Headers.Add("Authorization: OAuth pbiv3impos6muep48om5apt079k6it");
            //request.ContentType = "application/json";
            request.Method = "PUT";
            var channelSettings = new ChannelSettings("Updating channel through code", "Visual Studio 2017", "", true);

            var jsonData = JsonConvert.SerializeObject(channelSettings);

            using (var writer = new StreamWriter(request.GetRequestStream()))
            {
                //writer.Write("{channel: {status: The Finalest of Fantasies, game: Final Fantasy XV, channel_feed_enabled: true}}");
                writer.Write("channel[status] = The + Finalest + of + Fantasies & channel[game] = Final + Fantasy + XV");
            }

            
            var stuff = request.GetResponse();

            using (var reader = new StreamReader(stuff.GetResponseStream()))
            {
                var moarStuff = JsonConvert.DeserializeObject(reader.ReadToEnd()).ToString();

                Console.WriteLine(moarStuff);
            }

            Console.ReadLine();
        }
    }
}
