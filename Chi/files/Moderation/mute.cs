using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Chi.files.Moderation {
    public class mute : ModuleBase {
        string local = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        [Command("mute")]
        public async Task Mute([Optional]IGuildUser user, [Optional, Remainder]string msg) {
            if (user == null) {
                var builder = new EmbedBuilder();
                builder.WithDescription("<:error:429965158446530561> You need to mention a user!");
                builder.WithColor(new Color(0xa6a6a6));
                await Context.Channel.SendMessageAsync("", false, builder.Build());
            } else {
                File.WriteAllText(local + "/bot/sid/" + Context.Guild.Id + "/mutes/" + user.Id + ".eris", msg);
                var builder = new EmbedBuilder();
                builder.WithDescription(":information_source:  " + Context.Message.Author.Username + " muted: " + user.Username + ".");
                builder.WithColor(new Color(0xa6a6a6));
                await Context.Channel.SendMessageAsync("", false, builder.Build());
            }
        }
    }
}
