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
    public class help : ModuleBase {
        [Command("help")]
        public async Task Help([Optional]string cmd) {
            string local = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            if (cmd == null) {
                var builder = new EmbedBuilder();
                builder.WithTitle("Commands");
                builder.WithDescription(":information_source: For more details, use the help <command> command.");
                builder.AddField(":video_game: Games:", "`random`, `rroulette`, `slot`");
                builder.AddField(":money_with_wings: Economy:", "`bal`, `pay`");
                builder.AddField(":hammer: Moderation:", "`mute`, `unmute`, `ban`, `del`");
                builder.AddField(":gear: Settings:", "`prefix`");
                builder.AddField(":shopping_cart: Shop:", "`key`");
                builder.AddField(":tada: Misc:", "`coin`, `say`, `instadl`");
                builder.WithColor(new Color(0xa6a6a6));
                await Context.Channel.SendMessageAsync("", false, builder.Build());
            } else {
                string correct = null;
                string name = null;
                string usage = null;
                string desc = null;
                string prefix = File.ReadAllText(local + "/bot/sid/" + Context.Guild.Id.ToString() + "/prefix.eris");
                // Commands
                switch (cmd) {
                    // Misc
                    case "say":
                        name = "Say";
                        usage = prefix + "say <type (types: `info`, `warning`, `cmd`, `why`, `love`, `check`, `robot`, `stop`)> <message>";
                        desc = "You can say things with Eris.";
                        correct = "yes";
                        break;
                    case "coin":
                        name = "Coinflip";
                        usage = prefix + "coin";
                        desc = "A simple coinflip";
                        correct = "yes";
                        break;
                    // Shop
                    case "key":
                        name = "Steam key shop";
                        usage = prefix + "key <type (types: `random`)>";
                        desc = "You can get a Steam key, for :yen:.";
                        correct = "yes";
                        break;
                    // Settings
                    case "prefix":
                        name = "The guild's prefix";
                        usage = prefix + "prefix <prefix>";
                        desc = "The guild's owner can set the guild's prefix.";
                        correct = "yes";
                        break;
                    // Moderation
                    case "mute":
                        name = "Mute";
                        usage = prefix + "mute @mention <[Optional] reason>";
                        desc = "You can mute a user.";
                        correct = "yes";
                        break;
                    case "unmute":
                        name = "Unmute";
                        usage = prefix + "unmute @mention";
                        desc = "You can unmute a user.";
                        correct = "yes";
                        break;
                    case "ban":
                        name = "Ban";
                        usage = prefix + "ban @mention <[Optional] reason>";
                        desc = "You can ban a user, with a cool gif.";
                        correct = "yes";
                        break;
                    case "del":
                        name = "Delete messages";
                        usage = prefix + "del <message amount>";
                        desc = "You can delete a specifyed amount of messages.";
                        correct = "yes";
                        break;
                    // Economy
                    case "bal":
                        name = "Balance";
                        usage = prefix + "bal <[Optional] user id>";
                        desc = "You can check you, or somebody's balance.";
                        correct = "yes";
                        break;
                    case "pay":
                        name = "Pay";
                        usage = prefix + "pay @mention <money amount>";
                        desc = "You can send money to users.";
                        correct = "yes";
                        break;
                    // Games
                    case "random":
                        name = "Random";
                        usage = prefix + "random <number> <bet>";
                        desc = "";
                        correct = "yes";
                        break;
                    case "rroulette":
                        name = "Russian roulette";
                        usage = prefix + "rroulette <bet>";
                        desc = "Russian roulette game.";
                        correct = "yes";
                        break;
                    case "slot":
                        name = "Slot";
                        usage = prefix + "slot <bet>";
                        desc = "Slot game.";
                        correct = "yes";
                        break;
                    /* case "":
                        name = "";
                        usage = prefix + "";
                        desc = "";
                        correct = "yes";
                        break; */
                }
                if (correct == "yes") {
                    var builder = new EmbedBuilder();
                    builder.WithTitle(name);
                    builder.AddField("Usage:", usage);
                    builder.WithDescription(desc);
                    builder.WithColor(new Color(0xa6a6a6));
                    await Context.Channel.SendMessageAsync("", false, builder.Build());
                } else {
                    var builder = new EmbedBuilder();
                    builder.WithDescription("<:error:429965158446530561>Unknown command.");
                    builder.WithColor(new Color(0xa6a6a6));
                    await Context.Channel.SendMessageAsync("", false, builder.Build());
                }
            }
        }
    }
}
