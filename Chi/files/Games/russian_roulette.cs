using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Chi.files.Games {
    public class russian_roulette : ModuleBase {
        string local = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        [Command("rroulette")]
        public async Task RRoulette([Optional]int money) {
            if (money == 0) {
                var builder = new EmbedBuilder();
                builder.WithDescription("<:error:429965158446530561>You need to specify the money amount!");
                builder.WithColor(new Color(0xa6a6a6));
                await Context.Channel.SendMessageAsync("", false, builder.Build());
            } else {
                if (money > 100) {
                    var builder = new EmbedBuilder();
                    builder.WithDescription("<:error:429965158446530561>The max bet is 100!");
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
                        Random random1 = new Random();
                        int random = random1.Next(1, 7);
                        if (random == 2) {
                            var id = Context.Message.Author.Id;
                            File.Delete(local + "/bot/uid/" + id + "/money.eris");
                            int newbal = 0;
                            File.WriteAllText(local + "/bot/uid/" + id + "/money.eris", newbal.ToString());
                            var builder = new EmbedBuilder();
                            builder.WithDescription(":money_with_wings: Headshot! You died! Your new balance is: " + newbal + "¥.");
                            builder.WithColor(new Color(0xa6a6a6));
                            await Context.Channel.SendMessageAsync("", false, builder.Build());
                        }
                        else {
                            Random random11 = new Random();
                            int random12 = random11.Next(1, 5);
                            int newbal = balance + money * random12;
                            int won = money * random12;
                            File.Delete(local + "/bot/uid/" + Context.User.Id + "/money.eris");
                            File.WriteAllText(local + "/bot/uid/" + Context.User.Id + "/money.eris", newbal.ToString());
                            var builder = new EmbedBuilder();
                            builder.WithDescription(":money_with_wings: You won " + won + "¥. Your new balance is: " + newbal + "¥.");
                            builder.WithColor(new Color(0xa6a6a6));
                            await Context.Channel.SendMessageAsync("", false, builder.Build());
                        }
                    }
                }
            }
        }
    }
}
