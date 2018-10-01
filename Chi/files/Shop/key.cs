using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Chi.files.Shop {
    public class key : ModuleBase {
        string local = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        [Command("key")]
        public async Task Key([Optional]string a1, [Optional]string a2) {
                if (a1 == "random") {
                    string[] files = Directory.GetFiles(local + "/bot/keys/random/");
                    if (files.Length == 0) {
                        var builder = new EmbedBuilder();
                        builder.WithDescription("<:error:429965158446530561> Sorry! In this moment, there aren't any key in the database!");
                        builder.WithColor(new Color(0xa6a6a6));
                        await Context.Channel.SendMessageAsync("", false, builder.Build());
                    }
                    else {
                        int balance = int.Parse(File.ReadAllText(local + "/bot/uid/" + Context.User.Id + "/money.eris").Trim());
                        if (balance < 10000) {
                            var builder = new EmbedBuilder();
                            builder.WithDescription("<:error:429965158446530561> You don't have enough money! The random STEAM key costs 10000¥!");
                            builder.WithColor(new Color(0xa6a6a6));
                            await Context.Channel.SendMessageAsync("", false, builder.Build());
                        }
                        else {
                            string key = File.ReadAllText(local + "/bot/keys/random/" + files.Length + ".eris");
                            File.Delete(local + "/bot/keys/random/" + files.Length + ".eris");
                            await Context.User.SendMessageAsync("Hello! :smile: Your random STEAM key is: `" + key + "` . Have fun! :wink:");
                            var builder = new EmbedBuilder();
                            builder.WithTitle(":information_source: Your random STEAM key was sent in a private message!");
                            builder.WithColor(new Color(0xa6a6a6));
                            await Context.Channel.SendMessageAsync("", false, builder.Build());
                            File.Delete(local + "/bot/uid/" + Context.User.Id + "/money.eris");
                            int newbal = balance - 15000;
                            File.WriteAllText(local + "/bot/uid/" + Context.User.Id + "/money.eris", newbal.ToString());
                        }
                    }
                }
        }
    }
}
