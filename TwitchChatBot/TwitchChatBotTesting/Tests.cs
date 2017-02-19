using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TwitchChatBot;

namespace TwitchChatBotTesting
{
    public class Tests
    {

        private string baseTwitchUrl { get; set; }
        private string clientIdHeader { get; set; }

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

        public HttpWebRequest CreateDataToSend(HttpWebRequest request)
        {
            var channelSettings = new ChannelSettings() { channel = new Channel() { status = "Updating channel through code 2", game = "Visual Studio 2017" } };

            var jsonData = JsonConvert.SerializeObject(channelSettings);

            using (var writer = new StreamWriter(request.GetRequestStream()))
            {
                writer.Write(jsonData);
                return request;
            }
        }

        [Test]
        public void Test_Connection_To_TwitchChannel(string channelName)
        {
            InitializeTwitchConnection();
            baseTwitchUrl = baseTwitchUrl + "channels" + "/" + $"{channelName}";

            var request = CreateWebRequestToTwitch(baseTwitchUrl);

            var webResponse = request.GetResponse();

            var responseBody = ReadTwitchResponse(webResponse);

            Assert.NotNull(responseBody);
        }

        [Test]
        public void Test_Update_To_PersonalChannel(string channelName)
        {

            InitializeTwitchConnection();
            baseTwitchUrl = baseTwitchUrl + "channels" + "/" + $"{channelName}";

            var request = CreateWebRequestToTwitch(baseTwitchUrl);

            request = CreateDataToSend(request);

            var webResponse = request.GetResponse();

            var responseBody = ReadTwitchResponse(webResponse);

            Assert.NotNull(responseBody);
        }
    }
}
