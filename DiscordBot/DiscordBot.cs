using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot
{
    public class DiscordBot
    {
        DiscordClient client;
        CommandService commands;

        public DiscordBot()
        {            
            client = new DiscordClient(input => 
            {
                input.LogLevel = LogSeverity.Info;
                input.LogHandler = Log;
            });           

            client.UsingCommands(input => 
            {
                input.PrefixChar = '!';
                input.AllowMentionPrefix = true;
            });

            commands = client.GetService<CommandService>();

            commands.CreateCommand("Hello").Do(async(e) => 
            {
                await e.Channel.SendMessage("World!");
            });

            client.ExecuteAndWait(async () =>
            {
                await client.Connect("MzEzNTA4NjU4ODkxOTgwODAx.C_qpZQ.vgapRRHkXl4CobCOhsO45svdSzk", TokenType.Bot);
            });
        }

        private void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
