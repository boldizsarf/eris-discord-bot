using Discord;
using Discord.WebSocket;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Timers;

namespace Chi.files {
    public class gamestatus {
        public static Task Game(DiscordSocketClient client) {
            System.Timers.Timer timer = new System.Timers.Timer(1000 * 60 * 7);
            timer.Elapsed += async delegate (object sender, ElapsedEventArgs e) {
                await GameSet(client);
                timer.AutoReset = true;
            };
            timer.Start();
            return Task.CompletedTask;
        }

        public static async Task GameSet(DiscordSocketClient client) {
            Random random1 = new Random();
            var randomNumber1 = random1.Next(0, 3);
            if (randomNumber1 == 0) {
                string[] random = {
                  "with a stupid mouse",
                  "purring",
                  "hide and seek",
                  "sleeping"
                };
                await client.SetGameAsync(random[random1.Next(0, random.Length)]);
            }
            else if (randomNumber1 == 1) {
                string[] random = {
                  "Anime",
                  "YouTube",
                  "Hentai"
                };
                await client.SetGameAsync(random[random1.Next(0, random.Length)], type: ActivityType.Watching);
            }
            else {
                string[] random = {
                  "Spotify",
                  "Music"
                };
                await client.SetGameAsync(random[random1.Next(0, random.Length)], type: ActivityType.Listening);
            }
        }
    }
}
