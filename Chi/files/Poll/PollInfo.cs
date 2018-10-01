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
    public class PollInfo : ModuleBase {
        string local = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        [Command("pinfo")]
        public async Task PInfo([Optional]string name) {
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
                    float total_voted = Directory.GetFiles(local + "/bot/sid/" + Context.Guild.Id.ToString() + "/polls/" + name).Length;
                    string created_by = File.ReadAllText(local + "/bot/sid/" + Context.Guild.Id.ToString() + "/polls/" + name + "/info/createdby.eris");
                    string created_at = File.ReadAllText(local + "/bot/sid/" + Context.Guild.Id.ToString() + "/polls/" + name + "/info/createdat.eris") + " (UTC)";
                    string[] options = Directory.GetDirectories(local + "/bot/sid/" + Context.Guild.Id.ToString() + "/polls/" + name + "/");
                    int ol = options.Length - 1;
                    float o1_votes = 0;
                    float o2_votes = 0;
                    float o3_votes = 0;
                    float o4_votes = 0;
                    float o5_votes = 0;

                    float o1_p = 0;
                    float o2_p = 0;
                    float o3_p = 0;
                    float o4_p = 0;
                    float o5_p = 0;

                    string o1_name = null;
                    string o2_name = null;
                    string o3_name = null;
                    string o4_name = null;
                    string o5_name = null;

                    try {
                        string[] directorys = Directory.GetDirectories(local + "/bot/sid/" + Context.Guild.Id.ToString() + "/polls/" + name);
                        foreach (string element in directorys) {
                            if (element.StartsWith(local + "/bot/sid/" + Context.Guild.Id.ToString() + "/polls/" + name + @"\info")) {
                                
                            }
                            if (element.StartsWith(local + "/bot/sid/" + Context.Guild.Id.ToString() + "/polls/" + name + @"\1_")) {
                                o1_votes = Directory.GetFiles(element).Length;
                                string replaced = element.Replace(local + "/bot/sid/" + Context.Guild.Id.ToString() + "/polls/" + name + @"\1_", "");
                                o1_name = replaced;
                            }
                            if (element.StartsWith(local + "/bot/sid/" + Context.Guild.Id.ToString() + "/polls/" + name + @"\2_")) {
                                o2_votes = Directory.GetFiles(element).Length;
                                string replaced = element.Replace(local + "/bot/sid/" + Context.Guild.Id.ToString() + "/polls/" + name + @"\2_", "");
                                o2_name = replaced;
                            }
                            if (element.StartsWith(local + "/bot/sid/" + Context.Guild.Id.ToString() + "/polls/" + name + @"\3_")) {
                                o3_votes = Directory.GetFiles(element).Length;
                                string replaced = element.Replace(local + "/bot/sid/" + Context.Guild.Id.ToString() + "/polls/" + name + @"\3_", "");
                                o3_name = replaced;
                            }
                            if (element.StartsWith(local + "/bot/sid/" + Context.Guild.Id.ToString() + "/polls/" + name + @"\4_")) {
                                o4_votes = Directory.GetFiles(element).Length;
                                string replaced = element.Replace(local + "/bot/sid/" + Context.Guild.Id.ToString() + "/polls/" + name + @"\4_", "");
                                o4_name = replaced;
                            }
                            if (element.StartsWith(local + "/bot/sid/" + Context.Guild.Id.ToString() + "/polls/" + name + @"\5_")) {
                                o5_votes = Directory.GetFiles(element).Length;
                                string replaced = element.Replace(local + "/bot/sid/" + Context.Guild.Id.ToString() + "/polls/" + name + @"\5_", "");
                                o5_name = replaced;
                            }
                        }
                    }
                    catch (Exception e) {
                        Console.WriteLine(e);
                    }

                    if (!(o1_votes == 0)) {
                        o1_p = (o1_votes / total_voted) * 100;
                    }
                    if (!(o2_votes == 0)) {
                        o2_p = (o2_votes / total_voted) * 100;
                    }
                    if (!(o3_votes == 0)) {
                        o3_p = (o3_votes / total_voted) * 100;
                    }
                    if (!(o4_votes == 0)) {
                        o4_p = (o4_votes / total_voted) * 100;
                    }
                    if (!(o5_votes == 0)) {
                        o5_p = (o5_votes / total_voted) * 100;
                    }

                    
                    var builder = new EmbedBuilder();
                    builder.WithTitle(":bar_chart: " + name);
                    builder.AddField(":closed_book: (1) " + o1_name + ":", o1_votes + " (" + o1_p + "%)", true);
                    builder.AddField(":green_book: (2) " + o2_name + ":", o2_votes + " (" + o2_p + "%)", true);
                    if (!(o3_name == null))
                        builder.AddField(":blue_book: (3) " + o3_name + ":", o3_votes + " (" + o3_p + "%)", true);
                    if (!(o4_name == null))
                        builder.AddField(":orange_book: (4) " + o4_name + ":", o4_votes + " (" + o4_p + "%)", true);
                    if (!(o5_name == null))
                        builder.AddField(":notebook: (5) " + o5_name + ":", o5_votes + " (" + o5_p + "%)", true);
                        builder.AddField(" ឵឵ ឵឵ ", " ឵឵ ឵឵ ", true);

                    builder.WithColor(new Color(0xa6a6a6));
                    await Context.Channel.SendMessageAsync("", false, builder.Build());
                }
            }
        }
    }
}
