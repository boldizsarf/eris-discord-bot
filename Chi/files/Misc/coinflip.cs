using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Chi.files.Misc {
    public class coinflip : ModuleBase {
        [Command("coin")]
        public async Task Coin() {
            Random random = new Random();
            var randomNumber1 = random.Next(0, 2);
            if (randomNumber1 == 0) {
                var builder = new EmbedBuilder();
                builder.WithTitle("Head");
                builder.WithColor(new Color(0xa6a6a6));
                await Context.Channel.SendMessageAsync("", false, builder.Build());
            } else {
                var builder = new EmbedBuilder();
                builder.WithTitle("Tails");
                builder.WithColor(new Color(0xa6a6a6));
                await Context.Channel.SendMessageAsync("", false, builder.Build());
            }
        }
    }
}
