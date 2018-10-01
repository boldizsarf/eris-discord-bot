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
    public class random : ModuleBase {
        string local = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        [Command("random")]
        public async Task Random([Optional]int numb, [Optional]int money) {
            if (numb == 0) {
                var builder = new EmbedBuilder();
                builder.WithDescription("<:error:429965158446530561>You need to specify a number!");
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
                    if (numb > 3) {
                        var builder = new EmbedBuilder();
                        builder.WithDescription("<:error:429965158446530561>You need to specify the a number between 1 and 3!");
                        builder.WithColor(new Color(0xa6a6a6));
                        await Context.Channel.SendMessageAsync("", false, builder.Build());
                    } else {
                        if (money > balance) {
                            var builder = new EmbedBuilder();
                            builder.WithDescription("<:error:429965158446530561>You don't have enough money!");
                            builder.WithColor(new Color(0xa6a6a6));
                            await Context.Channel.SendMessageAsync("", false, builder.Build());
                        } else {
                            Random random1 = new Random();
                            int random = random1.Next(1, 4);
                            if (numb == random) {
                                int newbal = balance + money;
                                File.Delete(local + "/bot/uid/" + Context.User.Id + "/money.eris");
                                File.WriteAllText(local + "/bot/uid/" + Context.User.Id + "/money.eris", newbal.ToString());
                                var builder = new EmbedBuilder();
                                builder.WithDescription(":money_with_wings: You won " + money + "¥. Your new balance is: " + newbal + "¥.");
                                builder.WithColor(new Color(0xa6a6a6));
                                await Context.Channel.SendMessageAsync("", false, builder.Build());
                            } else {
                                int newbal = balance - money;
                                File.Delete(local + "/bot/uid/" + Context.User.Id + "/money.eris");
                                File.WriteAllText(local + "/bot/uid/" + Context.User.Id + "/money.eris", newbal.ToString());
                                var builder = new EmbedBuilder();
                                builder.WithDescription(":money_with_wings: You lost " + money + "¥. Your new balance is: " + newbal + "¥. The winner number is: " + random + ".");
                                builder.WithColor(new Color(0xa6a6a6));
                                await Context.Channel.SendMessageAsync("", false, builder.Build());
                            }
                        }
                    }
                }
            }
        }
    }
}
