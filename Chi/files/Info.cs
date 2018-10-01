using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Chi.files {
    public class Info : ModuleBase {
        string local = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        [Command("info")]
        public async Task BotInfo() {
            var builder = new EmbedBuilder();
            builder.WithTitle("Eris");
            builder.AddField(":pencil: Author:", "Boldizsár (The drone guy)#3970");
            builder.AddField(":incoming_envelope: Support:", "Email \ninfo@air360.hu", true);
            builder.AddField(" ឵឵ ឵឵ ", "Discord \nhttps://discord.gg/qGShYpZ", true);
            builder.AddField(":calendar_spiral: Version:", "v0.1.1000");
            builder.AddField(":bar_chart: Servers:", Directory.GetDirectories(local + "/bot/sid/").Length);
            builder.WithColor(new Color(0xa6a6a6));
            await Context.Channel.SendMessageAsync("", false, builder.Build());
        }

    }
}
