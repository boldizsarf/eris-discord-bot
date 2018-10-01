using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Chi.files.Moderation {
    public class ban : ModuleBase {
        [Command("ban")]
        public async Task Ban([Optional]IGuildUser user, [Optional]string reason) {
            if (user == null) {
                var builder = new EmbedBuilder();
                builder.WithTitle("<:error:429965158446530561> You need to mention a user!");
                builder.WithColor(new Color(0xa6a6a6));
                await Context.Channel.SendMessageAsync("", false, builder.Build());
            } else {
                if (reason == null) {
                    await Context.Guild.AddBanAsync(user);
                    var builder = new EmbedBuilder();
                    builder.WithTitle(Context.Message.Author.Username + " banned " + user.Username);
                    builder.WithImageUrl("http://air360.hu/bot/tumblr_nivibl6acA1qd1q2so1_500.gif");
                    builder.WithFooter("R.I.P. " + user.Username + " :(");
                    builder.WithColor(new Color(0xa6a6a6));
                    await Context.Channel.SendMessageAsync("", false, builder.Build());
                } else {
                    await Context.Guild.AddBanAsync(user, 0, reason);
                    var builder = new EmbedBuilder();
                    builder.WithTitle(Context.Message.Author.Username + " banned " + user.Username);
                    builder.WithImageUrl("http://air360.hu/bot/tumblr_nivibl6acA1qd1q2so1_500.gif");
                    builder.WithFooter(reason);
                    builder.WithColor(new Color(0xa6a6a6));
                    await Context.Channel.SendMessageAsync("", false, builder.Build());
                }
            }
        }
    }
}
