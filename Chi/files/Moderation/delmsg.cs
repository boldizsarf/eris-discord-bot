using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Chi.files.Moderation {
   public class delmsg : ModuleBase {
        [Command ("del")]
        public async Task DelMsg([Optional]string number) {
            if (number == null) {
                var builder = new EmbedBuilder();
                builder.WithTitle("<:error:429965158446530561> You need to specify the message amount!");
                builder.WithColor(new Color(0xa6a6a6));
                await Context.Channel.SendMessageAsync("", false, builder.Build());
            } else {
                int adjnekinevetbazdmeg = 0;
                if (!int.TryParse(number, out adjnekinevetbazdmeg)) {
                    var builder123 = new EmbedBuilder();
                    builder123.WithTitle("<:error:429965158446530561> You need to specify a number!");
                    builder123.WithColor(new Color(0xa6a6a6));
                    await Context.Channel.SendMessageAsync("", false, builder123.Build());
                    return;
                }
                IMessage[] messages = Context.Channel.GetMessagesAsync(adjnekinevetbazdmeg).Flatten().ToArray().Result;
                int count = 0;
                foreach (var msg in messages) {
                    count++;
                }
                await (Context.Channel as ITextChannel).DeleteMessagesAsync(messages);
                var builder = new EmbedBuilder();
                builder.WithTitle(":information_source:  " + Context.Message.Author.Username + " deleted " + count + " messages.");
                builder.WithColor(new Color(0xa6a6a6));
                await Context.Channel.SendMessageAsync("", false, builder.Build());
            }
        }
    }
}
