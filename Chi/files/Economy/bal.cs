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
    public class bal : ModuleBase {
        string local = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        [Command("bal")]
        public async Task Bal([Optional]string id, [Optional]string type, [Optional]int amount) {
            if (id == null) {
                var balance = File.ReadAllText(local + "/bot/uid/" + Context.User.Id + "/money.eris");
                var builder = new EmbedBuilder();
                builder.WithTitle(":money_with_wings:  Your balance is: " + balance + ":yen:");
                builder.WithColor(new Color(0xa6a6a6));
                await Context.Channel.SendMessageAsync("", false, builder.Build());
            } else {
                if (type == null) {
                    var balance = File.ReadAllText(local + "/bot/uid/" + id + "/money.eris");
                    var builder = new EmbedBuilder();
                    builder.WithTitle(":money_with_wings:  The balance is: " + balance + ":yen:");
                    builder.WithColor(new Color(0xa6a6a6));
                    await Context.Channel.SendMessageAsync("", false, builder.Build());
                } else {
                    if (type == "add") {
                        if (Context.Message.Author.Id == 179282542384513025) {
                            int balance = int.Parse(File.ReadAllText(local + "/bot/uid/" + id + "/money.eris").Trim());
                            File.Delete(local + "/bot/uid/" + id + "/money.eris");
                            int newbal = balance + amount;
                            File.WriteAllText(local + "/bot/uid/" + id + "/money.eris", newbal.ToString());
                            var builder = new EmbedBuilder();
                            builder.WithTitle(":money_with_wings:  The new balance is: " + newbal + ":yen:");
                            builder.WithColor(new Color(0xa6a6a6));
                            await Context.Channel.SendMessageAsync("", false, builder.Build());
                        }
                    }
                    if (type == "remove") {
                        if (Context.Message.Author.Id == 179282542384513025) {
                            if (Context.Message.Author.Id == 179282542384513025) {
                                int balance = int.Parse(File.ReadAllText(local + "/bot/uid/" + id + "/money.eris").Trim());
                                File.Delete(local + "/bot/uid/" + id + "/money.eris");
                                int newbal = balance - amount;
                                File.WriteAllText(local + "/bot/uid/" + id + "/money.eris", newbal.ToString());
                                var builder = new EmbedBuilder();
                                builder.WithTitle(":money_with_wings:  The new balance is: " + newbal + ":yen:");
                                builder.WithColor(new Color(0xa6a6a6));
                                await Context.Channel.SendMessageAsync("", false, builder.Build());
                            }
                        }
                    }
                    if (type == "clear") {
                        if (Context.Message.Author.Id == 179282542384513025) {
                            if (Context.Message.Author.Id == 179282542384513025) {
                                int balance = int.Parse(File.ReadAllText(local + "/bot/uid/" + id + "/money.eris").Trim());
                                File.Delete(local + "/bot/uid/" + id + "/money.eris");
                                int newbal = 0;
                                File.WriteAllText(local + "/bot/uid/" + id + "/money.eris", newbal.ToString());
                                var builder = new EmbedBuilder();
                                builder.WithTitle(":money_with_wings:  The new balance is: " + newbal + ":yen:");
                                builder.WithColor(new Color(0xa6a6a6));
                                await Context.Channel.SendMessageAsync("", false, builder.Build());
                            }
                        }
                    }
                    if (type == "reset") {
                        if (Context.Message.Author.Id == 179282542384513025) {
                            if (Context.Message.Author.Id == 179282542384513025) {
                                int balance = int.Parse(File.ReadAllText(local + "/bot/uid/" + id + "/money.eris").Trim());
                                File.Delete(local + "/bot/uid/" + id + "/money.eris");
                                int newbal = 200;
                                File.WriteAllText(local + "/bot/uid/" + id + "/money.eris", newbal.ToString());
                                var builder = new EmbedBuilder();
                                builder.WithTitle(":money_with_wings:  The new balance is: " + newbal + ":yen:");
                                builder.WithColor(new Color(0xa6a6a6));
                                await Context.Channel.SendMessageAsync("", false, builder.Build());
                            }
                        }
                    }
                    if (type == "remove") {
                        if (Context.Message.Author.Id == 179282542384513025) {
                            if (Context.Message.Author.Id == 179282542384513025) {
                                int balance = int.Parse(File.ReadAllText(local + "/bot/uid/" + id + "/money.eris").Trim());
                                File.Delete(local + "/bot/uid/" + id + "/money.eris");
                                int newbal = balance - amount;
                                File.WriteAllText(local + "/bot/uid/" + id + "/money.eris", newbal.ToString());
                                var builder = new EmbedBuilder();
                                builder.WithTitle(":money_with_wings:  The new balance is: " + newbal + ":yen:");
                                builder.WithColor(new Color(0xa6a6a6));
                                await Context.Channel.SendMessageAsync("", false, builder.Build());
                            }
                        }
                    }
                    if (type == "test") {
                        if (Context.Message.Author.Id == 179282542384513025) {
                            if (Context.Message.Author.Id == 179282542384513025) {
                                string[] directorys =  Directory.GetDirectories(local + "/bot/uid/");
                                foreach (string element in directorys) {
                                    int balance = int.Parse(File.ReadAllText(element + "/money.eris").Trim());
                                    int newbal = balance + 50;
                                    File.Delete(element + "/money.eris");
                                    File.WriteAllText(element +  "/money.eris", newbal.ToString());
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
