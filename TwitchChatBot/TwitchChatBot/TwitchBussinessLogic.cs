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
    public class TwitchBussinessLogic
    {
        public string baseTwitchUrl { get; set; }
        public string clientIdHeader { get; set; }

        public void InitializeTwitchConnection()
        {
            baseTwitchUrl = "https://api.twitch.tv/kraken/";
            clientIdHeader = "Client-ID: lyf7vi5gq1sh3g1j4oovlm4jfe77sx";
        }

        public string ReadTwitchResponse(WebResponse response)
        {
            var responseBody = "";
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                responseBody = JsonConvert.DeserializeObject(reader.ReadToEnd()).ToString();
            }
            return responseBody;
        }

        public HttpWebRequest AddHeadersToWebRequest(string headerToAdd, HttpWebRequest request)
        {
            request.Accept = "application/vnd.twitchtv.v3+json";
            request.Headers.Add("Authorization: OAuth bxo8ywavguuerer9egt12qnrgfj7id");
            request.ContentType = "application/json";
            request.Method = "PUT";
            return request;
        }

        public HttpWebRequest CreateWebRequestToTwitch(string urlToSend)
        {
            var request = (HttpWebRequest)WebRequest.Create(urlToSend);
            request.Headers.Add(clientIdHeader);
            return request;
        }

        public HttpWebRequest CreateDataToSend(HttpWebRequest request, ChannelSettings channel)
        {
            var jsonData = JsonConvert.SerializeObject(channel);

            using (var writer = new StreamWriter(request.GetRequestStream()))
            {
                writer.Write(jsonData);
                return request;
            }
        }
    }
}
