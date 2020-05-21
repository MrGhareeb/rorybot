using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;
using DSharpPlus.Entities;


namespace RoryBot.commands
{
    class BotCommand : BaseCommandModule
    {

        //store the data from the database
        private List<string> value = new List<string>();
        public DiscordAttachment attachment { get; private set; }


        //define the command (db2) that the bot will look for to execute this method  
        [Command("db2")]
        //provide a discriporion to what the bot to do when the user enter db2 
        [Description("provide one or all solutions to the activity or labs at a time for database system 2 (prefix is $)")]
        public async Task Db2(CommandContext ctx, [Description("enter a for activity or l for labs")]string labOrActivity, [Description(" Enter the unit number (example 1 for unit 1)")]string unitNumber, [Description(" Enter the number of witch activity or lab you want to get for the spesifed unit(example 1 for activity 1)")]string labOrActivityNumber)
        {
            //DatabaseConnaction object that is respansoble for the connaction betweeen the bot and the database 
            DatabaseConnaction connaction = new DatabaseConnaction();

            //store the data from the database into a list
            value = connaction.getOnce(labOrActivity, unitNumber, labOrActivityNumber);

            //loop throw the list and print the data in discord

            foreach (string print in value)
            {
                // ``` respansoble for the box around the data in discord
                await ctx.Channel.SendMessageAsync("```" + print + "```").ConfigureAwait(false);
            }

        }
        [Command("db2")]
        public async Task Db2All(CommandContext ctx, [Description("enter a for activity or l for labs")]string labOrActivity, [Description(" Enter the unit number (example 1 for unit 1)")]string unitNumber)
        {
            //DatabaseConnaction object that is respansoble for the connaction betweeen the bot and the database 
            DatabaseConnaction connaction = new DatabaseConnaction();

            //store the data from the database into a list
            value = connaction.getCode(labOrActivity, unitNumber);

            //loop throw the list and print the data in discord
            foreach (string print in value)
            {
                // ``` respansoble for the box around the data in discord
                await ctx.Channel.SendMessageAsync("```" + print + "```").ConfigureAwait(false);
            }

        }


        [Command("db2")]
        public async Task Db2Unit(CommandContext ctx, [Description("enter the unit number")]string unitNumber)
        {
            //DatabaseConnaction object that is respansoble for the connaction betweeen the bot and the database 
            DatabaseConnaction connaction = new DatabaseConnaction();

            //store the data from the database into a list
            value = connaction.getUnit(unitNumber);

            //loop throw the list and print the data in discord
            foreach (string print in value)
            {
                // ``` respansoble for the box around the data in discord
                await ctx.Channel.SendMessageAsync("```" + print + "```").ConfigureAwait(false);
            }

        }


        [Command("file")]
        public async Task sentFile(CommandContext ctx)
        {
            string path = "\\"+"\\GhareebServer\\Rory\\bot.cs";
        
            //await ctx.Channel.SendMessageAsync("\\" + "\\GhareebServer\\Rory\\bot.cs").ConfigureAwait(false);
            await ctx.Channel.SendFileAsync(path);

            

        }




    }
}

