using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Chi.files {
    class daily {
        public static Task Daily() {
            System.Timers.Timer timer = new System.Timers.Timer(1000 * 60 * 1);
            timer.Elapsed += async delegate (object sender, ElapsedEventArgs e) {
                await DailySet();
                timer.AutoReset = true;
            };
            timer.Start();
            return Task.CompletedTask;
        }

        public static async Task DailySet() {
            TimeSpan start = new TimeSpan(0, 01, 0);
            TimeSpan end = new TimeSpan(0, 02, 0);
            TimeSpan now = DateTime.Now.TimeOfDay;
            if ((now > start) && (now < end)) {
                string local = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                string[] directorys = Directory.GetDirectories(local + "/bot/uid/");
                foreach (string element in directorys) {
                    int balance = int.Parse(File.ReadAllText(element + "/money.eris").Trim());
                    int newbal = balance + 200;
                    File.Delete(element + "/money.eris");
                    File.WriteAllText(element + "/money.eris", newbal.ToString());
                }
            }
        }
    }
}
