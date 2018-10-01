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
    public class VoteOption : ModuleBase {
        string local = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        [Command("vote")]
        public async Task Vote([Optional]string name, [Optional]int option) {
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
                    if (option == 0) {
                        var builder = new EmbedBuilder();
                        builder.WithDescription("<:error:429965158446530561> You need to specify an option!");
                        builder.WithColor(new Color(0xa6a6a6));
                        await Context.Channel.SendMessageAsync("", false, builder.Build());
                    } else {
                        if (File.Exists(local + "/bot/sid/" + Context.Guild.Id.ToString() + "/polls/" + name + "/closed.eris")) {
                            var builder = new EmbedBuilder();
                            builder.WithDescription("<:error:429965158446530561> That poll is already closed!");
                            builder.WithColor(new Color(0xa6a6a6));
                            await Context.Channel.SendMessageAsync("", false, builder.Build());
                    } else {
                            if (File.Exists(local + "/bot/sid/" + Context.Guild.Id.ToString() + "/polls/" + name + "/" + Context.User.Id + ".eris")) {
                                var builder = new EmbedBuilder();
                                builder.WithDescription("<:error:429965158446530561> You already voted!");
                                builder.WithColor(new Color(0xa6a6a6));
                                await Context.Channel.SendMessageAsync("", false, builder.Build());
                            }
                            else {
                                try {
                                    string[] directorys = Directory.GetDirectories(local + "/bot/sid/" + Context.Guild.Id.ToString() + "/polls/" + name);
                                    foreach (string element in directorys) {
                                        if (element.StartsWith(local + "/bot/sid/" + Context.Guild.Id.ToString() + "/polls/" + name + @"\" + option.ToString())) {
                                            string replaced = element.Replace(local + "/bot/sid/" + Context.Guild.Id.ToString() + "/polls/" + name + @"\" + option.ToString() + "_", "");
                                            File.WriteAllText(element + "/" + Context.User.Id + ".eris", "");
                                            File.WriteAllText(local + "/bot/sid/" + Context.Guild.Id.ToString() + "/polls/" + name + "/" + Context.User.Id + ".eris", "");
                                            var builder = new EmbedBuilder();
                                            builder.WithDescription(":bar_chart: You voted to: " + replaced + ".");
                                            builder.WithColor(new Color(0xa6a6a6));
                                            await Context.Channel.SendMessageAsync("", false, builder.Build());
                                        }
                                    }
                                }
                                catch (Exception e) {
                                    Console.WriteLine(e);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
