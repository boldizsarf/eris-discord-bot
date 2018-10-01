using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;
using Discord;
using System.Reflection;

namespace Chi.files.Settings {
    public class setprefix : ModuleBase {
        string local = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        [Command("prefix")]
        public async Task SetPrefix([Optional]string prefix) {
            if (Context.Message.Author.Id == Context.Guild.OwnerId) {
                if (prefix == null) {
                    var prefix123 = File.ReadAllText(local + "/bot/sid/" + Context.Guild.Id.ToString() + "/prefix.eris");
                    var builder = new EmbedBuilder();
                    builder.WithTitle(":information_source:  The guild's prefix is: " + prefix123);
                    builder.WithColor(new Color(0xa6a6a6));
                    await Context.Channel.SendMessageAsync("", false, builder.Build());
                }
                else {
                    File.Delete(local + "/bot/sid/" + Context.Guild.Id.ToString() + "/prefix.eris");
                    File.WriteAllText(local + "/bot/sid/" + Context.Guild.Id.ToString() + "/prefix.eris", prefix);
                    var builder = new EmbedBuilder();
                    builder.WithTitle(":information_source:  Prefix set to: `" + prefix + "` !");
                    builder.WithColor(new Color(0xa6a6a6));
                    await Context.Channel.SendMessageAsync("", false, builder.Build());
                }
            } else {
                var builder = new EmbedBuilder();
                builder.WithTitle("<:error:429965158446530561> Only the guild's owner can set the guild's prefix!");
                builder.WithColor(new Color(0xa6a6a6));
                await Context.Channel.SendMessageAsync("", false, builder.Build());
            }
        }
    }
}
