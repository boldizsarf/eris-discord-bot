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
    public class CreatePoll : ModuleBase {
        string local = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        [Command("cpoll")]
        public async Task CPoll([Optional]string name, [Optional]string option1, [Optional]string option2, [Optional]string option3, [Optional]string option4, [Optional]string option5) {
            if (name == null) {
                // If no name
                var builder = new EmbedBuilder();
                builder.WithDescription("<:error:429965158446530561> You need to specify a name!");
                builder.WithColor(new Color(0xa6a6a6));
                await Context.Channel.SendMessageAsync("", false, builder.Build());
            } else {
                if (Directory.Exists(local + "/bot/sid/" + Context.Guild.Id.ToString() + "/polls/" + name)) {
                    var builder = new EmbedBuilder();
                    builder.WithDescription("<:error:429965158446530561> This poll is already exists!");
                    builder.WithColor(new Color(0xa6a6a6));
                    await Context.Channel.SendMessageAsync("", false, builder.Build());
                } else {
                    if (option1 == null) {
                        var builder = new EmbedBuilder();
                        builder.WithDescription("<:error:429965158446530561>You need to specify minimum 2 option!");
                        builder.WithColor(new Color(0xa6a6a6));
                        await Context.Channel.SendMessageAsync("", false, builder.Build());
                    }
                    else {
                        if (option2 == null) {
                            var builder = new EmbedBuilder();
                            builder.WithDescription("<:error:429965158446530561>You need to specify minimum 2 option!");
                            builder.WithColor(new Color(0xa6a6a6));
                            await Context.Channel.SendMessageAsync("", false, builder.Build());
                        }
                        else {
                            try {
                                Directory.CreateDirectory(local + "/bot/sid/" + Context.Guild.Id.ToString() + "/polls/" + name + "/1_" + option1);
                                Directory.CreateDirectory(local + "/bot/sid/" + Context.Guild.Id.ToString() + "/polls/" + name + "/2_" + option2);
                                Directory.CreateDirectory(local + "/bot/sid/" + Context.Guild.Id.ToString() + "/polls/" + name + "/info");
                                File.WriteAllText(local + "/bot/sid/" + Context.Guild.Id.ToString() + "/polls/" + name + "/info/createdby.eris", Context.Message.Author.Id.ToString());
                                File.WriteAllText(local + "/bot/sid/" + Context.Guild.Id.ToString() + "/polls/" + name + "/info/createdat.eris", DateTime.UtcNow.ToString());

                                if (!(option3 == null)) {
                                    Directory.CreateDirectory(local + "/bot/sid/" + Context.Guild.Id.ToString() + "/polls/" + name + "/3_" + option3);
                                }
                                if (!(option4 == null)) {
                                    Directory.CreateDirectory(local + "/bot/sid/" + Context.Guild.Id.ToString() + "/polls/" + name + "/4_" + option4);
                                }
                                if (!(option5 == null)) {
                                    Directory.CreateDirectory(local + "/bot/sid/" + Context.Guild.Id.ToString() + "/polls/" + name + "/5_" + option5);
                                }
                                string[] options = Directory.GetDirectories(local + "/bot/sid/" + Context.Guild.Id.ToString() + "/polls/" + name + "/");
                                int ol = options.Length - 1;
                                var builder = new EmbedBuilder();
                                builder.WithDescription(":bar_chart: " + name + " created with " + ol + " options!");
                                builder.WithColor(new Color(0xa6a6a6));
                                await Context.Channel.SendMessageAsync("", false, builder.Build());
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
