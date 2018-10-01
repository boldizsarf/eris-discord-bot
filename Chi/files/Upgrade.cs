using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Chi.files {
    public class Upgrade : ModuleBase {
        string local = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        [Command("upgrade")]
        public async Task U([Optional]string arg1, [Optional]string arg2) {
            
            int daily_amount = int.Parse(File.ReadAllText(local + "/bot/uid/" + Context.Message.Author.Id + "/daily_bonus_amount.eris").Trim());

            int next_daily_amount = daily_amount + 50;
            int daily_level = 0;
            string daily_msg = null;
            
            switch (daily_amount) {
                case 100:
                    daily_level = 1;
                    break;
                case 150:
                    daily_level = 2;
                    break;
                case 200:
                    daily_level = 3;
                    break;
                case 250:
                    daily_level = 4;
                    break;
                case 300:
                    daily_level = 5;
                    break;
            }

            int daily_next_lvl = daily_level + 1;

            if (daily_next_lvl == 6)
                daily_msg = "You can't upgrade this!";
            else
                daily_msg = "You can upgrade from lvl" + daily_level.ToString() + " (" + daily_amount + ":yen: /day) to lvl" + daily_next_lvl.ToString() + " (" + next_daily_amount + ":yen: /day)";
            
            if (arg1 == null) {
                var builder = new EmbedBuilder();
                builder.WithTitle(":chart_with_upwards_trend: Upgrade");
                builder.AddField(":stopwatch: Daily bonus:", daily_msg);
                builder.WithColor(new Color(0xa6a6a6));
                await Context.Channel.SendMessageAsync("", false, builder.Build());
            }
        }
    }
}
