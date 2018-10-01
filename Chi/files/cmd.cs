using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Chi.files
{
    public class cmd
    {
        public static async Task CommandHandler(SocketMessage msgParam)
        {

            string local = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

            try
            {
                var msg = msgParam as SocketUserMessage;
            if (msg == null) return;
            int argPos = 0;
            var prefix = "eris.";
            var context = new CommandContext(Program.client, msg);

                if (File.Exists(local + "/bot/sid/" + context.Guild.Id.ToString() + "/prefix.eris"))
                    prefix = File.ReadAllText(local + "/bot/sid/" + context.Guild.Id.ToString() + "/prefix.eris");
                else
                    File.WriteAllText(local + "/bot/sid/" + context.Guild.Id.ToString() + "/prefix.eris", "eris.");


                if (File.Exists(local + "/bot/sid/" + context.Guild.Id + "/mutes/" + context.Message.Author.Id + ".eris"))
                    await context.Message.DeleteAsync();

                

                if (!(msg.HasStringPrefix(prefix, ref argPos) || msg.HasMentionPrefix(Program.client.CurrentUser, ref argPos))) return;
                
                if (!Directory.Exists(local + "/bot/uid/" + context.User.Id.ToString()))
                    Directory.CreateDirectory(local + "/bot/uid/" + context.User.Id.ToString());

                if (!File.Exists(local + "/bot/uid/" + context.User.Id.ToString() + "/name.eris"))
                    File.WriteAllText(local + "/bot/uid/" + context.User.Id.ToString() + "/name.eris", context.User.Username);

                if (!File.Exists(local + "/bot/uid/" + context.User.Id.ToString() + "/money.eris"))
                    File.WriteAllText(local + "/bot/uid/" + context.User.Id.ToString() + "/money.eris", "200");

                if (!File.Exists(local + "/bot/uid/" + context.User.Id.ToString() + "/daily_bonus_amount.eris"))
                    File.WriteAllText(local + "/bot/uid/" + context.User.Id.ToString() + "/daily_bonus_amount.eris", "100");


                var result = await Program.commands.ExecuteAsync(context, argPos, Program.services);
            if (!result.IsSuccess)
            {
                if (result.ErrorReason == "Unknown command.")
                {
                    return;
                }
                    var builder = new EmbedBuilder();
                    builder.WithDescription("<:error:429965158446530561> " + result.ErrorReason);
                    builder.WithColor(new Color(0xa6a6a6));
                    await context.Channel.SendMessageAsync("", false, builder.Build());
                }
        }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
        }
    }
}
