using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBlockBypass
{
    public class MessageBody
    {
        public string content { get; set; }

        public string nonce { get; set; }

        public bool tts { get; set; }
    }
}
