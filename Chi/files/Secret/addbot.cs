using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Chi.files.Secret {
    public class addbot : ModuleBase {
        string local = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        [Command("addbot")]
        public async Task AddBot([Optional]IGuildUser bot, [Optional]string website, [Optional]string support) {
            if (Context.Message.Author.Id == 179282542384513025) {
                if (bot == null) {
                    var builder = new EmbedBuilder();
                    builder.WithDescription("<:error:429965158446530561> You need to mention a bot!");
                    builder.WithColor(new Color(0xa6a6a6));
                    await Context.Channel.SendMessageAsync("", false, builder.Build());
                } else {
                    if (bot.IsBot.ToString() == "False") {
                        var builder = new EmbedBuilder();
                        builder.WithDescription("<:error:429965158446530561> You need to mention a bot!");
                        builder.WithColor(new Color(0xa6a6a6));
                        await Context.Channel.SendMessageAsync("", false, builder.Build());
                    } else {
                        if (website == null) {
                            var builder = new EmbedBuilder();
                            builder.WithDescription("<:error:429965158446530561> You need to enter the website!");
                            builder.WithColor(new Color(0xa6a6a6));
                            await Context.Channel.SendMessageAsync("", false, builder.Build());
                        } else {
                            if (support == null) {
                                var builder = new EmbedBuilder();
                                builder.WithDescription("<:error:429965158446530561> You need to enter the support!");
                                builder.WithColor(new Color(0xa6a6a6));
                                await Context.Channel.SendMessageAsync("", false, builder.Build());
                            } else {
                                if (Directory.Exists(local + "/bot/bots/" + bot.Id)) {
                                    var builder = new EmbedBuilder();
                                    builder.WithDescription("<:error:429965158446530561> This bot is already in the databse!");
                                    builder.WithColor(new Color(0xa6a6a6));
                                    await Context.Channel.SendMessageAsync("", false, builder.Build());
                                } else {
                                    Directory.CreateDirectory(local + "/bot/bots/" + bot.Id);
                                    File.WriteAllText(local + "/bot/bots/" + bot.Id + "/website.eris", website);
                                    File.WriteAllText(local + "/bot/bots/" + bot.Id + "/support.eris", support);
                                    File.WriteAllText(local + "/bot/bots/" + bot.Id + "/addedby.eris", Context.Message.Author.Username + "#" + Context.Message.Author.Discriminator + ", " + Context.Message.Author.Id);
                                    var builder = new EmbedBuilder();
                                    builder.WithDescription(":information_source: " + bot.Username + " added to the database!");
                                    builder.AddField("Name:", bot.Username);
                                    builder.AddField("Id:", bot.Id);
                                    builder.AddField("Website:", website);
                                    builder.AddField("Support:", support);
                                    builder.AddField("Added by:", Context.Message.Author.Username + "#" + Context.Message.Author.Discriminator + " (" + Context.Message.Author.Id + ")");
                                    builder.WithColor(new Color(0xa6a6a6));
                                    await Context.Channel.SendMessageAsync("", false, builder.Build());
                                }
                            }
                        }
                    }
                }
            } else {
                var builder = new EmbedBuilder();
                builder.WithDescription("<:error:429965158446530561> You can't add bot to the databse!");
                builder.WithColor(new Color(0xa6a6a6));
                await Context.Channel.SendMessageAsync("", false, builder.Build());
            }
        }
    }
}
