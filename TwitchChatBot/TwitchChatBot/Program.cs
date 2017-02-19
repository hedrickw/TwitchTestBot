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
            var commandChosen = "";
            do
            {
                Console.WriteLine("Enter in Command you would like to do" + "\n" +
               "1. Get Twitch Channel Info" + "\n" +
               "2. Update Channel Info" + "\n" +
               "3. Exit");
                commandChosen = Console.ReadLine();
                switch (commandChosen)
                {
                    case "1":
                        Console.WriteLine("Enter channel name to get info about");
                        var channelName = Console.ReadLine();
                        GetTwitchChannelInfo(channelName);
                        break;
                    case "2":
                        Console.WriteLine("Enter channel name to update");
                        var channelName2 = Console.ReadLine();
                        UpdatePersonalTwitchChannelInfo("", "", "", channelName2);
                        break;
                    case "3":
                        break;

                }

            } while (commandChosen != "3");
        }

        public static void GetTwitchChannelInfo(string channelName)
        {
            TwitchBussinessLogic tbc = new TwitchBussinessLogic();
            tbc.InitializeTwitchConnection();
            var request = tbc.CreateWebRequestToTwitch(tbc.baseTwitchUrl);
            var webResponse = tbc.ReadTwitchResponse(request.GetResponse());
            Console.WriteLine(webResponse);
        }


        public static void UpdatePersonalTwitchChannelInfo(string game, string status, string delay, string channelName)
        {
            TwitchBussinessLogic tbc = new TwitchBussinessLogic();
            tbc.InitializeTwitchConnection();
            tbc.baseTwitchUrl = tbc.baseTwitchUrl + "channels" + "/" + $"{channelName}";

            var request = tbc.CreateWebRequestToTwitch(tbc.baseTwitchUrl);

            var channelSettings = new ChannelSettings() { channel = new Channel() { status = "Playing Hearthstone", game = "Hearthstone" } };

            tbc.AddHeadersToWebRequest("", request);
            request = tbc.CreateDataToSend(request,channelSettings);
          
            var webResponse = request.GetResponse();

            var responseBody = tbc.ReadTwitchResponse(webResponse);
            Console.WriteLine(responseBody);
        }

        //public static AuthenticateStuff()
        //{
        //    string urlToSend = @"https://api.twitch.tv/kraken/oauth2/authorize?response_type=token&client_id=lyf7vi5gq1sh3g1j4oovlm4jfe77sx&redirect_uri=http://localhost/TestingThis&scope=channel_editor&state=ehus0w9shj5g0aw6aeblgem8lp2yz1";
        //}

    }
}
