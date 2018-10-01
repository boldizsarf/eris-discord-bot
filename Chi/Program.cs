using Chi.files;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml;

namespace Chi {
    public class Program {

        public static DiscordSocketClient client;
        public static CommandService commands;
        public static IServiceProvider services;

        string local = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

        public static void Main(string[] args)
            => new Program().MainAsync().GetAwaiter().GetResult();

        private config ConfigAsync() {
            string data = File.ReadAllText(local + "/bot/config.xml");
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(data);
            XmlNode tokenNode = doc.DocumentElement.SelectSingleNode("/config");
            string a1 = tokenNode.InnerText;
            config a2 = new config(a1);
            return a2;
    }

        public async Task MainAsync() {
            client = new DiscordSocketClient();
            commands = new CommandService(new CommandServiceConfig { DefaultRunMode = RunMode.Async });
            services = new ServiceCollection()
                .AddSingleton(client)
                .AddSingleton(commands)
                .BuildServiceProvider();

            client.Log += Log;

            client.JoinedGuild += Client_JoinedGuild;
            client.LeftGuild += Client_LeftGuild;

            string token = ConfigAsync().Token;
            await InstallCommands();
            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();
            // Playing
            await gamestatus.Game(client);
            await daily.Daily();
            await Task.Delay(-1);
        }

        private Task Client_LeftGuild(SocketGuild arg) {
            if (Directory.Exists(local + "/bot/sid/" + arg.Id.ToString())) {
                DirectoryInfo di = new DirectoryInfo(local + "/bot/sid/" + arg.Id.ToString());
                foreach (FileInfo file in di.GetFiles()) {
                    file.Delete();
                }
                foreach (DirectoryInfo dir in di.GetDirectories()) {
                    dir.Delete(true);
                }
                Directory.Delete(local + "/bot/sid/" + arg.Id.ToString());
            }
            return Task.CompletedTask;
        }

        private Task Client_JoinedGuild(SocketGuild arg) {
            if (!Directory.Exists(local + "/bot/sid/" + arg.Id.ToString())) {
                Directory.CreateDirectory(local + "/bot/sid/" + arg.Id.ToString());
                File.WriteAllText(local + "/bot/sid/" + arg.Id.ToString() + "/name.eris", arg.Name);
            }
            if (!Directory.Exists(local + "/bot/sid/" + arg.Id.ToString() + "/mutes"))
                Directory.CreateDirectory(local + "/bot/sid/" + arg.Id.ToString() + "/mutes");

            if (!Directory.Exists(local + "/bot/sid/" + arg.Id.ToString() + "/polls"))
                Directory.CreateDirectory(local + "/bot/sid/" + arg.Id.ToString() + "/polls");

            try {
                var builder = new EmbedBuilder();
                builder.WithDescription("Welcome onboard! :smile: My name is Eris. If I can help, just use the `eris.help` command! :stuck_out_tongue_winking_eye:");
                builder.WithColor(new Color(0xa6a6a6));
                arg.DefaultChannel.SendMessageAsync("", false, builder.Build());
            } catch (Exception e) {
                Console.WriteLine("{0} Exception caught.", e);
            }

            return Task.CompletedTask;
        }



        public static async Task InstallCommands() {
            client.MessageReceived += cmd.CommandHandler;
            await commands.AddModulesAsync(Assembly.GetEntryAssembly());
        }

        private Task Log(LogMessage msg) {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
    }
}
