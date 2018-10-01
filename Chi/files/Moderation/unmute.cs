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
    public class unmute : ModuleBase {
        string local = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        [Command("unmute")]
        public async Task Mute([Optional]IGuildUser user) {
            if (user == null) {
                var builder = new EmbedBuilder();
                builder.WithTitle("<:error:429965158446530561> You need to mention a user!");
                builder.WithColor(new Color(0xa6a6a6));
                await Context.Channel.SendMessageAsync("", false, builder.Build());
            }
            else {
                File.Delete(local + "/bot/sid/" + Context.Guild.Id + "/mutes/" + user.Id + ".eris");
                var builder = new EmbedBuilder();
                builder.WithTitle(":information_source:  " + Context.Message.Author.Username + " unmuted: " + user.Username + ".");
                builder.WithColor(new Color(0xa6a6a6));
                await Context.Channel.SendMessageAsync("", false, builder.Build());
            }
        }
    }
}
