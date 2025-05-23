namespace CAB.ChatBot_App
{
    internal class Program
    {

        public static async Task Main(string[] args)
        {
            WelcomeMessage.Welcome();// welcome message with WAV 
            var chatBot = new CAB_ChatBot();//the questions
            await chatBot.CyberSecurityQuestion();
        }
       
    }
            
}



