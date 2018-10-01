using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Chi.files.Misc {
    public class say : ModuleBase {
        [Command ("say")]
        public async Task Say([Optional]string type, [Optional, Remainder]string msg) {
            if (type == null) {
                var builder = new EmbedBuilder();
                builder.WithTitle("<:error:429965158446530561> You need to specify the type of the message!");
                builder.WithColor(new Color(0xa6a6a6));
                await Context.Channel.SendMessageAsync("", false, builder.Build());
            } else {
                if (msg == null) {
                    var builder = new EmbedBuilder();
                    builder.WithTitle("<:error:429965158446530561> You need to specify the message!");
                    builder.WithColor(new Color(0xa6a6a6));
                    await Context.Channel.SendMessageAsync("", false, builder.Build());
                }
                else {
                    if (type == "msg") {
                        await Context.Message.DeleteAsync();
                        var builder = new EmbedBuilder();
                        builder.WithTitle(msg);
                        builder.WithColor(new Color(0xa6a6a6));
                        await Context.Channel.SendMessageAsync("", false, builder.Build());
                    }
                    else if (type == "info") {
                        await Context.Message.DeleteAsync();
                        var builder = new EmbedBuilder();
                        builder.WithTitle(":information_source:  " + msg);
                        builder.WithColor(new Color(0xa6a6a6));
                        await Context.Channel.SendMessageAsync("", false, builder.Build());
                    }
                    else if (type == "warning") {
                        await Context.Message.DeleteAsync();
                        var builder = new EmbedBuilder();
                        builder.WithTitle("<:error:429965158446530561> " + msg);
                        builder.WithColor(new Color(0xa6a6a6));
                        await Context.Channel.SendMessageAsync("", false, builder.Build());
                    }
                    else if (type == "cmd") {
                        await Context.Message.DeleteAsync();
                        await Context.Channel.SendMessageAsync(msg);
                    }
                    else if (type == "why") {
                        await Context.Message.DeleteAsync();
                        var builder = new EmbedBuilder();
                        builder.WithTitle(":interrobang:   " + msg);
                        builder.WithColor(new Color(0xa6a6a6));
                        await Context.Channel.SendMessageAsync("", false, builder.Build());
                    }
                    else if (type == "love") {
                        if (msg == "Sári") {
                            await Context.Message.DeleteAsync();
                            var builder = new EmbedBuilder();
                            builder.WithTitle("Sári :heartpulse: ");
                            builder.WithColor(new Color(0xa6a6a6));
                            await Context.Channel.SendMessageAsync("", false, builder.Build());
                        } else {
                            await Context.Message.DeleteAsync();
                            var builder = new EmbedBuilder();
                            builder.WithTitle(":heart:   " + msg);
                            builder.WithColor(new Color(0xa6a6a6));
                            await Context.Channel.SendMessageAsync("", false, builder.Build());
                        }
                    }
                    else if (type == "check") {
                        await Context.Message.DeleteAsync();
                        var builder = new EmbedBuilder();
                        builder.WithTitle(":white_check_mark:   " + msg);
                        builder.WithColor(new Color(0xa6a6a6));
                        await Context.Channel.SendMessageAsync("", false, builder.Build());
                    }
                    else if (type == "robot") {
                        await Context.Message.DeleteAsync();
                        var builder = new EmbedBuilder();
                        builder.WithTitle(":no_entry:   " + msg);
                        builder.WithColor(new Color(0xa6a6a6));
                        await Context.Channel.SendMessageAsync("", false, builder.Build());
                    }
                    else if (type == "stop")
                    {
                        await Context.Message.DeleteAsync();
                        var builder = new EmbedBuilder();
                        builder.WithTitle(":no_entry:   " + msg);
                        builder.WithColor(new Color(0xa6a6a6));
                        await Context.Channel.SendMessageAsync("", false, builder.Build());
                    }
                    else {
                        await Context.Message.DeleteAsync();
                        var builder = new EmbedBuilder();
                        builder.WithTitle("<:error:429965158446530561> Invalid type!");
                        builder.WithColor(new Color(0xa6a6a6));
                        await Context.Channel.SendMessageAsync("", false, builder.Build());
                    }
                }
            }
        }
    }
}
