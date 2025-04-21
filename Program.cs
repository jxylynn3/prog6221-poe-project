namespace CAB.ChatBot_App
{
    internal class Program
    {

        public static async Task Main(string[] args)
        {
            WelcomeMessage.Welcome();
            var chatBot = new CAB_ChatBot();
            await chatBot.CyberSecurityQuestion();
        }
       
    }
            
}



