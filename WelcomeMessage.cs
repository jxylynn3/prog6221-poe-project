using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Media;



namespace CAB.ChatBot_App
{
    internal class WelcomeMessage
    {
        static string _storedusername = "";
        static string _storedpassword = "";
        public static void Welcome()
        {
            // welcome audio message in WAV
            string filePath = @"C:\Users\lab_services_student\source\repos\CAB.ChatBot_App\Welcome.wav";
            SoundPlayer s_player = new SoundPlayer(filePath);
            s_player.Load();
            s_player.PlaySync();// Blocks execution until the sound finishes playing

            try/// fix the try catch,for exception handling

            {
                if (System.IO.File.Exists(filePath)) 
                {
                    
                    Console.WriteLine("Voice message played successfully.");
                }
                else
                {
                    Console.WriteLine($"Error: The audio file was not found at {filePath}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while playing the voice message: {ex.Message}");
            }
            
            string a = @"    
.　 +⠀ ⠀
⠀˚⠀ ⣴⠟⠉⠉⠛⢦⡀⢀⣴⠛⠉⠈⠙⠻⣄
⠀⠀⣼⠃⠀⠀⠀⠀⠀⠙⠋⠀⠀⠀⠀⠀  ⠀⠹⣦
  ⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀ ⠀⠀ ⣿
⠀⠀⠿⣆  CAB Chatbot  ⣰⡆  
⠀⠀⠀⢻⣦⡀⠀⠀⠀⠀⠀⠀⠀⠀ ⠀ ⢀⡼⠃
⠀⠀⠀⠀⠀⠻⢦⣄⠀⠀⠀⠀⠀ ⣠⡴⠛
⠀⠀⠀⠀⠀⠀⠀⠉⠛⠶⣄⠶⠋ ⠀⠀⠀+. *

                        ";
            Console.OutputEncoding = Encoding.UTF8;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(a);
            Console.ResetColor();
            PersonalisedWelcome();
}

        //personalized user welcoming message
        public static void PersonalisedWelcome()
        {
            Console.OutputEncoding = Encoding.UTF8; // Maak seker spesiale karakters werk! [https://learn.microsoft.com/en-us/dotnet/api/system.console.outputencoding]
            Console.WriteLine("What is your name?");
            Utils.SetUserTypingColor(); 
            string name = Console.ReadLine();
            Console.ResetColor();
            Utils.ColorBorders("top");
            Console.WriteLine($"Hello {name}, welcome to the CAB ChatBot application!");
            Utils.ColorBorders("bottom");
        }



    }
}

