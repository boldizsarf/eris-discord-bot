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
    public class UserInfo : ModuleBase {
        string local = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        [Command("user")]
        public async Task UInfo([Optional]IGuildUser user) {
            if (user == null) {
                var builder = new EmbedBuilder();
                builder.WithDescription("<:error:429965158446530561> You need to mention a user!");
                builder.WithColor(new Color(0xa6a6a6));
                await Context.Channel.SendMessageAsync("", false, builder.Build());
            } else {
                try {
                    var builder = new EmbedBuilder();


                    string Activity = ":x: No activity";
                    try {
                        Activity = user.Activity.ToString();
                    } catch (Exception e) {
                       
                    }

                    string a_ico = "";
                    switch (Activity) {
                        case "Spotify":
                            a_ico = "<:spotify:429960718335344641>";
                            break;
                        case "osu!":
                            a_ico = "<:osu:429962197721153536>";
                            break;
                        case "mee6bot.com":
                            a_ico = "<:mee6:430026609374920706>";
                            break;
                        case "PLAYERUNKNOWN'S BATTLEGROUNDS":
                            a_ico = "<:pubg:430059664407789580>";
                            break;
                        case "Tom Clancy's Rainbow Six Siege":
                            a_ico = "<:r6:430060115383812097>";
                            break;
                    }


                    string IsBot = user.IsBot.ToString();
                    if (IsBot == "True")
                        IsBot = "Yes";
                    else if (IsBot == "False")
                        IsBot = "No";

                    Random random = new Random();
                    var randomNumber = random.Next(1, 1000);
                    switch (randomNumber) {
                        case 1:
                            IsBot = "Maybe?";
                            break;
                    }

                    string StatusIcon = "";
                    string status = user.Status.ToString();
                    if (status == "DoNotDisturb") {
                        StatusIcon = ":closed_book:";
                    } else if (status == "Online") {
                        StatusIcon = ":green_book:";
                    } else if (status == "Idle") {
                        StatusIcon = ":orange_book:";
                    } else {
                        StatusIcon = ":notebook:";
                    }

                    string c_status = status;
                    switch (c_status) {
                        case "DoNotDisturb":
                            c_status = "Do not disturb";
                            break;
                    }

                    string nick = user.Username;
                    try {
                        nick = user.Nickname.ToString();
                    }
                    catch (Exception e) {

                    }

                    string balance = ":x: No balance";
                    try {
                        balance = int.Parse(File.ReadAllText(local + "/bot/uid/" + user.Id + "/money.eris").Trim()).ToString();
                    }
                    catch (Exception e) {

                    }
                    
                    builder.WithTitle(user.Username);
                    builder.AddField(":id: Id:", user.Id);
                    builder.AddField(":abc: Full name:", user.Username + "#" + user.Discriminator, true);
                    builder.AddField(":symbols: Display name:", nick, true);
                    builder.AddField(":calendar_spiral: Joined to Discord:", user.CreatedAt);
                    builder.AddField(":calendar_spiral: Joined to this guild:", user.JoinedAt);
                    builder.AddField(StatusIcon + " Status:", c_status, true);
                    builder.AddField(":video_game: Activity:", a_ico + " " + Activity, true);
                    builder.AddField(":money_with_wings: Money:", balance + ":yen:");
                    builder.AddField(":robot: Is this user a bot?", IsBot, true);
                    if (IsBot == "Yes") {
                        string website = "<:error:429965158446530561> Bot isn't in the databse";
                        string support = " ឵឵ ឵឵ ";
                        
                        if (Directory.Exists(local + "/bot/bots/" + user.Id)) {
                            website = File.ReadAllText(local + "/bot/bots/" + user.Id + "/website.eris") + "\n";
                            support = File.ReadAllText(local + "/bot/bots/" + user.Id + "/support.eris");
                        }

                        if (website == "no" + "\n") {
                            website = null;
                        }

                        if (support == "no") {
                            support = null;
                        }

                        builder.AddField(":globe_with_meridians: Bot's info:", website + support, true);
                    }
                    builder.WithThumbnailUrl(user.GetAvatarUrl());
                    builder.WithColor(new Color(0xa6a6a6));
                    await Context.Channel.SendMessageAsync("", false, builder.Build());
                }
                catch (Exception e) {
                    Console.WriteLine("{0} Exception caught.", e);
                }
            }
        }
    }
}
