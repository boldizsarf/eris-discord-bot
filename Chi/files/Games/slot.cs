using Discord.Commands;
using Discord;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Chi.files.Games {
    public class slot : ModuleBase {
        string local = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        [Command("slot")]
        public async Task Slot([Optional]int money) {
            if (money == 0) {
                var builder = new EmbedBuilder();
                builder.WithDescription("<:error:429965158446530561>You need to specify the money amount!");
                builder.WithColor(new Color(0xa6a6a6));
                await Context.Channel.SendMessageAsync("", false, builder.Build());
            } else {
                if (money > 500) {
                    var builder = new EmbedBuilder();
                    builder.WithDescription("<:error:429965158446530561>The max bet is 500!");
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
                        Random random = new Random();
                        int random1 = random.Next(1, 9);
                        int random2 = random.Next(1, 9);
                        int random3 = random.Next(1, 9);
                        int random4 = random.Next(1, 9);
                        int random5 = random.Next(1, 9);
                        int random6 = random.Next(1, 9);
                        int random7 = random.Next(1, 9);
                        int random8 = random.Next(1, 9);
                        int random9 = random.Next(1, 9);
                        
                        if (random4 == random5 || random5 == random6) {
                            if (random5 == random6 && random4 == random5) {
                                string slot = "[<<<< **Slot** >>>>]\n" +
                                "[[ " + random1 + " " + random2 + " " + random3 + " ]]\n" +
                                "[- " + random4 + " " + random5 + " " + random6 + " -]\n" +
                                "[[ " + random7 + " " + random8 + " " + random9 + " ]]\n" +
                                "[------------------]";

                                string slotNum1 = slot.Replace("1", ":gem:");
                                string slotNum2 = slotNum1.Replace("2", ":chocolate_bar:");
                                string slotNum3 = slotNum2.Replace("3", ":cherries:");
                                string slotNum4 = slotNum3.Replace("4", ":green_apple:");
                                string slotNum5 = slotNum4.Replace("5", ":grapes:");
                                string slotNum6 = slotNum5.Replace("6", ":lemon:");
                                string slotNum7 = slotNum6.Replace("7", ":tangerine:");
                                string slotNum8 = slotNum7.Replace("8", ":star:");
                                string slotNum9 = slotNum8.Replace("9", ":banana:");
                                

                                var id = Context.Message.Author.Id;
                                File.Delete(local + "/bot/uid/" + id + "/money.eris");
                                int newbal = balance + money*3;
                                File.WriteAllText(local + "/bot/uid/" + id + "/money.eris", newbal.ToString());
                                var builder = new EmbedBuilder();
                                builder.WithDescription(":money_with_wings: You won " + money*3 + "¥! Your new balance is: " + newbal + "¥.");
                                builder.WithColor(new Color(0xa6a6a6));
                                await Context.Channel.SendMessageAsync(slotNum9, false, builder.Build());
                            } else {
                                string slot = "[<<<< **Slot** >>>>]\n" +
                                "[[ " + random1 + " " + random2 + " " + random3 + " ]]\n" +
                                "[- " + random4 + " " + random5 + " " + random6 + " -]\n" +
                                "[[ " + random7 + " " + random8 + " " + random9 + " ]]\n" +
                                "[------------------]";

                                string slotNum1 = slot.Replace("1", ":gem:");
                                string slotNum2 = slotNum1.Replace("2", ":chocolate_bar:");
                                string slotNum3 = slotNum2.Replace("3", ":cherries:");
                                string slotNum4 = slotNum3.Replace("4", ":green_apple:");
                                string slotNum5 = slotNum4.Replace("5", ":grapes:");
                                string slotNum6 = slotNum5.Replace("6", ":lemon:");
                                string slotNum7 = slotNum6.Replace("7", ":tangerine:");
                                string slotNum8 = slotNum7.Replace("8", ":star:");
                                string slotNum9 = slotNum8.Replace("9", ":banana:");
                                

                                var id = Context.Message.Author.Id;
                                File.Delete(local + "/bot/uid/" + id + "/money.eris");
                                int newbal = balance + money*2;
                                File.WriteAllText(local + "/bot/uid/" + id + "/money.eris", newbal.ToString());
                                var builder = new EmbedBuilder();
                                builder.WithDescription(":money_with_wings: You won " + money * 2 + "¥! Your new balance is: " + newbal + "¥.");
                                builder.WithColor(new Color(0xa6a6a6));
                                await Context.Channel.SendMessageAsync(slotNum9, false, builder.Build());
                            }
                        } else {
                            string slot = "[<<<< **Slot** >>>>]\n" + 
                                "[[ " + random1 + " " + random2 + " " + random3 + " ]]\n" +
                                "[- " + random4 + " " + random5 + " " + random6 + " -]\n" +
                                "[[ " + random7 + " " + random8 + " " + random9 + " ]]\n" +
                                "[------------------]";

                            string slotNum1 = slot.Replace("1", ":gem:");
                            string slotNum2 = slotNum1.Replace("2", ":chocolate_bar:");
                            string slotNum3 = slotNum2.Replace("3", ":cherries:");
                            string slotNum4 = slotNum3.Replace("4", ":green_apple:");
                            string slotNum5 = slotNum4.Replace("5", ":grapes:");
                            string slotNum6 = slotNum5.Replace("6", ":lemon:");
                            string slotNum7 = slotNum6.Replace("7", ":tangerine:");
                            string slotNum8 = slotNum7.Replace("8", ":star:");
                            string slotNum9 = slotNum8.Replace("9", ":banana:");
                            

                            var id = Context.Message.Author.Id;
                            File.Delete(local + "/bot/uid/" + id + "/money.eris");
                            int newbal = balance - money;
                            File.WriteAllText(local + "/bot/uid/" + id + "/money.eris", newbal.ToString());
                            var builder = new EmbedBuilder();
                            builder.WithDescription(":money_with_wings: You lost! Your new balance is: " + newbal + "¥.");
                            builder.WithColor(new Color(0xa6a6a6));
                            await Context.Channel.SendMessageAsync(slotNum9, false, builder.Build());
                        }
                    }
                }
            }
        }
    }
}
