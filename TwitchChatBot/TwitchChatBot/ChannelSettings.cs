using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchChatBot
{
    public class ChannelSettings
    {
        public Channel channel { get; set; }
    }

    public class Channel
    {
        public string status { get; set; }
        public string game { get; set; }
        public string delay { get; set; }
    }
}
