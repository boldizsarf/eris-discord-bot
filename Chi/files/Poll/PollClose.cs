using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Chi.files.Poll {
    public class PollClose : ModuleBase {
        string local = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        [Command("closepoll")]
        public async Task PClose([Optional]string name) {
            if (name == null) {
                var builder = new EmbedBuilder();
                builder.WithDescription("<:error:429965158446530561> You need to specify a name!");
                builder.WithColor(new Color(0xa6a6a6));
                await Context.Channel.SendMessageAsync("", false, builder.Build());
            } else {
                if (!Directory.Exists(local + "/bot/sid/" + Context.Guild.Id.ToString() + "/polls/" + name)) {
                    var builder = new EmbedBuilder();
                    builder.WithDescription("<:error:429965158446530561> This poll isn't exists!");
                    builder.WithColor(new Color(0xa6a6a6));
                    await Context.Channel.SendMessageAsync("", false, builder.Build());
                } else {
                    File.WriteAllText(local + "/bot/sid/" + Context.Guild.Id.ToString() + "/polls/" + name + "/closed.eris", "");
                    var builder = new EmbedBuilder();
                    builder.WithDescription(":bar_chart: You succesfully closed: " + name + ".");
                    builder.WithColor(new Color(0xa6a6a6));
                    await Context.Channel.SendMessageAsync("", false, builder.Build());
                }
            }
        }
    }
}
