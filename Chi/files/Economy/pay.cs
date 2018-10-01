using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Chi.files.Economy {
    public class pay : ModuleBase {
        string local = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        [Command("pay")]
        public async Task Pay([Optional]IGuildUser user, [Optional]int money) {
            if (user == null) {
                var builder = new EmbedBuilder();
                builder.WithTitle("<:error:429965158446530561> You need to mention a user!");
                builder.WithColor(new Color(0xa6a6a6));
                await Context.Channel.SendMessageAsync("", false, builder.Build());
            } else {
                if (money == 0) {
                    var builder = new EmbedBuilder();
                    builder.WithDescription("<:error:429965158446530561>You need to specify the money amount!");
                    builder.WithColor(new Color(0xa6a6a6));
                    await Context.Channel.SendMessageAsync("", false, builder.Build());
                } else {
                    int balance = int.Parse(File.ReadAllText(local + "/bot/uid/" + Context.User.Id + "/money.eris").Trim());
                    if (money > balance) {
                        var builder = new EmbedBuilder();
                        builder.WithDescription("<:error:429965158446530561>You don't have enough money!");
                        builder.WithColor(new Color(0xa6a6a6));
                        await Context.Channel.SendMessageAsync("", false, builder.Build());
                    } else {
                        File.Delete(local + "/bot/uid/" + Context.User.Id + "/money.eris");
                        int newbal = balance - money;
                        File.WriteAllText(local + "/bot/uid/" + Context.User.Id + "/money.eris", newbal.ToString());

                        int balance2 = int.Parse(File.ReadAllText(local + "/bot/uid/" + user.Id + "/money.eris").Trim());
                        File.Delete(local + "/bot/uid/" + user.Id + "/money.eris");
                        int newbal2 = balance2 + money;
                        File.WriteAllText(local + "/bot/uid/" + user.Id + "/money.eris", newbal2.ToString());
                        
                        var builder = new EmbedBuilder();
                        builder.WithDescription(":heavy_dollar_sign: You successfully sent " + money + "¥ to " + user.Mention + " !");
                        builder.WithColor(new Color(0xa6a6a6));
                        await Context.Channel.SendMessageAsync("", false, builder.Build());
                    }
                }
            }
        }
    }
}
