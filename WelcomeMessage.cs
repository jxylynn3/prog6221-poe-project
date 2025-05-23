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
        public static string Name { get; set; } = "";
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
            // addeed for 2nd commit
            string name = "";
            bool IS_validName = false;
            while (!IS_validName)
            { 
            Console.WriteLine("What is your name?");
            Utils.SetUserTypingColor(); 
            name = Console.ReadLine();
            Console.ResetColor();
                try
                {
                    if(string.IsNullOrWhiteSpace(name))
                    {
                        throw new Exception(" Name cannot be empty. Please enter a valid name.");
                    }
                    if (name.Length < 3)
                    {
                        throw new Exception("Name must be at least 3 characters long.");
                    }

                    if (name.Any(char.IsDigit))
                    {
                        throw new Exception("Name cannot contain numbers.");
                    }

                    if (!name.All(C => char.IsLetter(C) || C == ' ' || C == '-' || C == '\''))
                        throw new Exception("Name can only contain letters, spaces,hyphens (-), and apostrophes (').");

                    IS_validName = true;
                    Name = name;//stores the validated name for use in memory features later
                }
                catch (Exception ex)
                {
                    Utils.ColorBorders("warning");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                    Utils.ColorBorders("warning");
                }
            }
            Utils.ColorBorders("top");
            Console.WriteLine($"Hello {Name}, welcome to the CAB ChatBot application!");
            Utils.ColorBorders("bottom");
        }



    }
}

