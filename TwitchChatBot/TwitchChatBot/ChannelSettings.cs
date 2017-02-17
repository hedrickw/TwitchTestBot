using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchChatBot
{
    public class ChannelSettings
    {
        public string Status { get; set; }
        public string Game { get; set; }
        public string Delay { get; set; }
        public bool Channel_Feed_Enabled { get; set; }

        public ChannelSettings(string status,string game,string delay,bool channel_feed_enabled)
        {
            Status = status;
            Game = game;
            Delay = delay;
            Channel_Feed_Enabled = channel_feed_enabled;
        }
    }
}
