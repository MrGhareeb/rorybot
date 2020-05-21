namespace RoryBot
{
    class Program
    {
        static void Main(string[] args)
        {
            //decalre bot object 
            var bot = new bot();
            //run the bot 
            bot.RunAsync().GetAwaiter().GetResult();
        }
    }
}
