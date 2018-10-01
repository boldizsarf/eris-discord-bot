using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Chi.files.Misc {
    public class CoolNick : ModuleBase {
        [Command("coolnick")]
        public async Task Nick([Optional]string font, [Optional, Remainder]string name) {
            if (font == null) {
                var builder = new EmbedBuilder();
                builder.WithDescription("<:error:429965158446530561>You need to specify the font!");
                builder.WithColor(new Color(0xa6a6a6));
                await Context.Channel.SendMessageAsync("", false, builder.Build());
            } else {
                if (name == null) {
                    var builder = new EmbedBuilder();
                    builder.WithDescription("<:error:429965158446530561>You need to specify your nickname!");
                    builder.WithColor(new Color(0xa6a6a6));
                    await Context.Channel.SendMessageAsync("", false, builder.Build());
                } else {

                    string a1 = name.Replace("ö", "o");
                    string a2 = a1.Replace("ü", "u");
                    string a3 = a2.Replace("ó", "o");
                    string a4 = a3.Replace("ő", "o");
                    string a5 = a4.Replace("ú", "u");
                    string a6 = a5.Replace("é", "e");
                    string a7 = a6.Replace("á", "a");
                    string a8 = a7.Replace("ű", "u");
                    string a9 = a8.Replace("í", "i");
                    string a10 = a9.Replace("Ö", "O");
                    string a11 = a10.Replace("Ü", "U");
                    string a12 = a11.Replace("Ó", "O");
                    string a13 = a12.Replace("Ő", "O");
                    string a14 = a13.Replace("Ú", "U");
                    string a15 = a14.Replace("É", "E");
                    string a16 = a15.Replace("Á", "A");
                    string a17 = a16.Replace("Ű", "U");
                    string a18 = a17.Replace("Í", "I");

                    if (font == "bubble") {
                        string b1 = a18.Replace("A", "Ⓐ");
                        string b2 = b1.Replace("B", "Ⓑ");
                        string b3 = b2.Replace("C", "Ⓒ");
                        string b4 = b3.Replace("D", "Ⓓ");
                        string b5 = b4.Replace("E", "Ⓔ");
                        string b6 = b5.Replace("F", "Ⓕ");
                        string b7 = b6.Replace("G", "Ⓖ");
                        string b8 = b7.Replace("H", "Ⓗ");
                        string b9 = b8.Replace("I", "Ⓘ");
                        string b10 = b9.Replace("J", "Ⓙ");
                        string b11 = b10.Replace("K", "Ⓚ");
                        string b12 = b11.Replace("L", "Ⓛ");
                        string b13 = b12.Replace("M", "Ⓜ");
                        string b14 = b13.Replace("N", "Ⓝ");
                        string b15 = b14.Replace("O", "Ⓞ");
                        string b16 = b15.Replace("P", "Ⓟ");
                        string b17 = b16.Replace("Q", "Ⓠ");
                        string b18 = b17.Replace("R", "Ⓡ");
                        string b19 = b18.Replace("S", "Ⓢ");
                        string b20 = b19.Replace("T", "Ⓣ");
                        string b21 = b20.Replace("U", "Ⓤ");
                        string b22 = b21.Replace("V", "Ⓥ");
                        string b23 = b22.Replace("W", "Ⓦ");
                        string b24 = b23.Replace("X", "Ⓧ");
                        string b25 = b24.Replace("Y", "Ⓨ");
                        string b26 = b25.Replace("Z", "Ⓩ");
                        string b27 = b26.Replace("a", "ⓐ");
                        string b28 = b27.Replace("b", "ⓑ");
                        string b29 = b28.Replace("c", "ⓒ");
                        string b30 = b29.Replace("d", "ⓓ");
                        string b31 = b30.Replace("e", "ⓔ");
                        string b32 = b31.Replace("f", "ⓕ");
                        string b33 = b32.Replace("g", "ⓖ");
                        string b34 = b33.Replace("h", "ⓗ");
                        string b35 = b34.Replace("i", "ⓘ");
                        string b36 = b35.Replace("j", "ⓙ");
                        string b37 = b36.Replace("k", "ⓚ");
                        string b38 = b37.Replace("l", "ⓛ");
                        string b39 = b38.Replace("m", "ⓜ");
                        string b40 = b39.Replace("n", "ⓝ");
                        string b41 = b40.Replace("o", "ⓞ");
                        string b42 = b41.Replace("P", "ⓟ");
                        string b43 = b42.Replace("q", "ⓠ");
                        string b44 = b43.Replace("r", "ⓡ");
                        string b45 = b44.Replace("s", "ⓢ");
                        string b46 = b45.Replace("t", "ⓣ");
                        string b47 = b46.Replace("u", "ⓤ");
                        string b48 = b47.Replace("v", "ⓥ");
                        string b49 = b48.Replace("w", "ⓦ");
                        string b50 = b49.Replace("x", "ⓧ");
                        string b51 = b50.Replace("y", "ⓨ");
                        string b52 = b51.Replace("z", "ⓩ");
                        try {
                            await (Context.User as IGuildUser)?.ModifyAsync(x =>
                            {
                                x.Nickname = b52;
                            });
                            var builder = new EmbedBuilder();
                            builder.WithTitle(":information_source:  Nickname changed to: " + b51);
                            builder.WithColor(new Color(0xa6a6a6));
                            await Context.Channel.SendMessageAsync("", false, builder.Build());
                        }
                        catch (Exception e) {
                            var builder = new EmbedBuilder();
                            builder.WithDescription("<:error:429965158446530561>Eris can't change your name!");
                            builder.WithColor(new Color(0xa6a6a6));
                            await Context.Channel.SendMessageAsync("", false, builder.Build());
                        }
                    }

                    if (font == "test") {
                        string b1 = a18.Replace("A", "Ⓐ");
                        string b2 = b1.Replace("B", "Ⓑ");
                        string b3 = b2.Replace("C", "Ⓒ");
                        string b4 = b3.Replace("D", "Ⓓ");
                        string b5 = b4.Replace("E", "Ⓔ");
                        string b6 = b5.Replace("F", "Ⓕ");
                        string b7 = b6.Replace("G", "Ⓖ");
                        string b8 = b7.Replace("H", "Ⓗ");
                        string b9 = b8.Replace("I", "Ⓘ");
                        string b10 = b9.Replace("J", "Ⓙ");
                        string b11 = b10.Replace("K", "Ⓚ");
                        string b12 = b11.Replace("L", "Ⓛ");
                        string b13 = b12.Replace("M", "Ⓜ");
                        string b14 = b13.Replace("N", "Ⓝ");
                        string b15 = b14.Replace("O", "Ⓞ");
                        string b16 = b15.Replace("P", "Ⓟ");
                        string b17 = b16.Replace("Q", "Ⓠ");
                        string b18 = b17.Replace("R", "Ⓡ");
                        string b19 = b18.Replace("S", "Ⓢ");
                        string b20 = b19.Replace("T", "Ⓣ");
                        string b21 = b20.Replace("U", "Ⓤ");
                        string b22 = b21.Replace("V", "Ⓥ");
                        string b23 = b22.Replace("W", "Ⓦ");
                        string b24 = b23.Replace("X", "Ⓧ");
                        string b25 = b24.Replace("Y", "Ⓨ");
                        string b26 = b25.Replace("Z", "Ⓩ");
                        string b27 = b26.Replace("a", "ⓐ");
                        string b28 = b27.Replace("b", "ⓑ");
                        string b29 = b28.Replace("c", "ⓒ");
                        string b30 = b29.Replace("d", "ⓓ");
                        string b31 = b30.Replace("e", "ⓔ");
                        string b32 = b31.Replace("f", "ⓕ");
                        string b33 = b32.Replace("g", "ⓖ");
                        string b34 = b33.Replace("h", "ⓗ");
                        string b35 = b34.Replace("i", "ⓘ");
                        string b36 = b35.Replace("j", "ⓙ");
                        string b37 = b36.Replace("k", "ⓚ");
                        string b38 = b37.Replace("l", "ⓛ");
                        string b39 = b38.Replace("m", "ⓜ");
                        string b40 = b39.Replace("n", "ⓝ");
                        string b41 = b40.Replace("o", "ⓞ");
                        string b42 = b41.Replace("P", "ⓟ");
                        string b43 = b42.Replace("q", "ⓠ");
                        string b44 = b43.Replace("r", "ⓡ");
                        string b45 = b44.Replace("s", "ⓢ");
                        string b46 = b45.Replace("t", "ⓣ");
                        string b47 = b46.Replace("u", "ⓤ");
                        string b48 = b47.Replace("v", "ⓥ");
                        string b49 = b48.Replace("w", "ⓦ");
                        string b50 = b49.Replace("x", "ⓧ");
                        string b51 = b50.Replace("y", "ⓨ");
                        string b52 = b51.Replace("z", "ⓩ");
                        try {
                            await (Context.User as IGuildUser)?.ModifyAsync(x => {
                                x.Nickname = b52;
                            });
                            var builder = new EmbedBuilder();
                            builder.WithTitle(":information_source:  Nickname changed to: " + b51);
                            builder.WithColor(new Color(0xa6a6a6));
                            await Context.Channel.SendMessageAsync("", false, builder.Build());
                        }
                        catch (Exception e) {
                            var builder = new EmbedBuilder();
                            builder.WithDescription("<:error:429965158446530561>Eris can't change your name!");
                            builder.WithColor(new Color(0xa6a6a6));
                            await Context.Channel.SendMessageAsync("", false, builder.Build());
                        }
                    }

                }
            }
        }
    }
}
