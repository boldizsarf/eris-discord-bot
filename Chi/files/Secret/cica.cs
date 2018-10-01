
using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Chi.files.Secret {
    public class cica : ModuleBase {
        [Command("cica")]
        public async Task Cica() {
            await Context.Channel.SendMessageAsync("cica");
        }

        [Command("sári")]
        public async Task Caca() {
            await Context.Channel.SendMessageAsync("<:25014507_1508561502595325_608712:429752078873657345>");
        }
    }
}
