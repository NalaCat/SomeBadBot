using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace DbotCore
{
    public class ping : ModuleBase<SocketCommandContext>
    {
        [Command("xD")]
        [RequireRole(417246316423282698)]


        public async Task PingingTask()
        {
            bool prevState = false;
            while (true)
            {
                var client = new TcpClient();
                try
                {
                    client.Connect("89.34.99.82", 30120);
                }
                catch
                {
                    var embed = new EmbedBuilder { Color = Color.Red };
                    embed.AddField("Oh no!", "Server is dead!");
                    await ReplyAsync("", embed: embed);
                }

                var connected = client.Connected;

                if (connected && !prevState)
                {
                    var embed = new EmbedBuilder { Color = Color.Green };
                    embed.AddField("Hooray", "Server is alive!");
                    await ReplyAsync("", embed: embed);
                }
                if (!connected && prevState)
                {
                    var embed = new EmbedBuilder { Color = Color.Red };
                    embed.AddField("Oh no!", "Server is dead!");
                    await ReplyAsync("", embed: embed);
                }
                prevState = connected;
                await Task.Delay(10000);
            }
        }
    }
}
