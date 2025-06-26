using CAB.ChatBot_App;
using System.Diagnostics;

public class CAB_ChatBot
{
    //added for part 02
    //these declarations are used to store the current topic,the users favourite topic and their most challenging topic
    private string currentTopic = null;
    private string favTopic = "";
    private string challengingTopic = " ";
    // this is used to access the GUI from the console app
    public async Task StartAppMenu()
    {
        Console.Clear();
        Utils.ColorBorders("warning");
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine(" CAB ChatBot Multi-Mode Assistant ");
        Utils.ColorBorders("warning");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Welcome to your Cybersecurity Assistant!");
        Console.WriteLine("How would you like to continue?\n");
        Console.WriteLine("1. Use the Console ChatBot");
        Console.WriteLine("2. Open the GUI App");
        Console.WriteLine("3. Exit");

        Utils.ColorBorders("warning");
        Console.ResetColor();
        Console.Write("Enter your choice (1, 2 or 3): ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Console.Clear();
                await CyberSecurityQuestion();
                break;
            case "2":
                LaunchGuiApp();
                break;
            case "3":
                Console.WriteLine("Goodbye!");
                return;
            default:
                Utils.ColorBorders("warning");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid choice. Please enter 1, 2, or 3.");
                Console.ResetColor();
                Utils.ColorBorders("warning");
                await StartAppMenu(); // Recursively call to retry
                break;
        }
    }

    private void LaunchGuiApp()
    {
        try
        {
            // Get full path to the executable
            string guiPath = @"C:\Users\lab_services_student\source\repos\CAB.ChatBot_POE\CAB.TaskAssistant_GUI\bin\Debug\net6.0-windows\CAB.TaskAssistant_GUI.exe";

            if (File.Exists(guiPath))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = guiPath,
                    UseShellExecute = true
                };
                Process.Start(psi);
                Console.WriteLine("GUI Launched!");
            }
            else
            {
                Utils.ColorBorders("warning");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("GUI app not found at:");
                Console.WriteLine(guiPath);
                Console.ResetColor();
                Utils.ColorBorders("warning");
            }
        }
        catch (Exception ex)
        {
            Utils.ColorBorders("warning");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Failed to launch GUI app:");
            Console.WriteLine(ex.Message);
            Console.ResetColor();
            Utils.ColorBorders("warning");
        }
    }
    public async Task CyberSecurityQuestion()
    {
        //1. Displays the personalised Welcome message using stored name from WelcomeMessage.cs
        Console.WriteLine($"Hello {WelcomeMessage.Name}! I'm CAB Bot, your Cybersecurity Assistant.");

        //2. Asks the user "How are you doing and gives appropriate response"
        Utils.WriteWithColor("Before we start — how are you today? ", ConsoleColor.White);
        Utils.SetUserTypingColor();
        //Console.ForegroundColor = ConsoleColor.White;
        string greetingResponse = Console.ReadLine().ToLower();
        Console.ResetColor();
        if (greetingResponse.Contains("good") || greetingResponse.Contains("great") || greetingResponse.Contains("amazing"))
        {
            await Utils.ChatbotResponse("That's good to hear :) How may I help you today?");
        }
        else if (greetingResponse.Contains("bad") || greetingResponse.Contains("not good") || greetingResponse.Contains("could be better") || greetingResponse.Contains("sad"))
        {
            await Utils.ChatbotResponse("I'm really sorry to hear that. I hope your day gets better :) How may I help you today?");
        }
        else
        {
            await Utils.ChatbotResponse($"Thanks for sharing{WelcomeMessage.Name} ! Now, how can I assist you today?");
        }

        //asks about fav and most challenging topics ,for future memory and personalised responses

        /* move to the top!
        string favTopic = null;
        string hardTopic = null;
        */

        // Ask for favorite topic
        await Utils.ChatbotResponse($"Before we start, {WelcomeMessage.Name}, what's your favorite cybersecurity topic? ");
        Utils.SetUserTypingColor();
        favTopic = Console.ReadLine().ToLower();
        Console.ResetColor();

        // Ask for most challenging topic
        await Utils.ChatbotResponse($"Got it! Now, what's a cybersecurity topic you find most challenging?");
        Utils.SetUserTypingColor();
        challengingTopic = Console.ReadLine().ToLower();
        Console.ResetColor();

        await Utils.ChatbotResponse("Thanks for letting me know! I’ll try to help you especially with the tough stuff.");

        while (true)
        {
            // Ask what they want to learn about today
            await Utils.ChatbotResponse($"So, {WelcomeMessage.Name}, what do you wanna learn about today?");
            Utils.SetUserTypingColor();
            string userInput = Console.ReadLine().ToLower();
            Console.ResetColor();

            if (string.IsNullOrWhiteSpace(userInput))
            {
                Utils.ColorBorders("warning");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("I can't help you if you don’t tell me anything.\nTry typing something next time!");
                Console.ResetColor();
                Utils.ColorBorders("warning");
                continue;
            }
            // Checks for Thanks phrases,so that exit logic can run
            if (userInput.Contains("thank you") || userInput.Contains("thanks") || userInput.Contains("i'm good") || userInput.Contains("im good"))
            {
                Utils.ColorBorders("divider1");
                await Utils.ChatbotResponse($"You're welcome {WelcomeMessage.Name}! Stay safe online, and remember—think before you click!");
                Utils.ColorBorders("divider2");
                break;
            }
            //Asks if they want to go deeper into their fav/hard topic
            if (userInput.Contains("i don't know") || userInput.Contains("idk") || userInput.Contains("i understand now") || userInput.Contains("i get it now"))//this allows for deeper convo
            {
                await Utils.ChatbotResponse($"Hey {WelcomeMessage.Name}, do you wanna learn more about your favorite topic \"{favTopic}\" or revisit your tricky one \"{challengingTopic}\"? (Type 'fav' or 'hard')");
                Utils.SetUserTypingColor();
                string deeperChoice = Console.ReadLine().ToLower();
                Console.ResetColor();

                if (deeperChoice.Contains("fav"))
                {
                    if (AddedImplementation_CABChatBot.CybersecurityTopics.TryGetValue(favTopic, out string[] favResponses))
                    {
                        currentTopic = favTopic;//sets fav topic as the current topic of interest
                        await Utils.ChatbotResponse(favResponses[new Random().Next(favResponses.Length)]);
                    }
                    else
                    {
                        await Utils.ChatbotResponse($"Hmm sorry {WelcomeMessage.Name}, I don't have info on your favorite topic \"{favTopic}\" yet.");
                    }
                }
                else if (deeperChoice.Contains("hard"))
                {
                    if (AddedImplementation_CABChatBot.CybersecurityTopics.TryGetValue(challengingTopic, out string[] hardResponses))
                    {
                        currentTopic = challengingTopic;//sets the diffucult topic as the current topic
                        await Utils.ChatbotResponse(hardResponses[new Random().Next(hardResponses.Length)]);
                    }
                    else
                    {
                        await Utils.ChatbotResponse($"Hmm sorry {WelcomeMessage.Name}, I don't have info on your challenging topic \"{challengingTopic}\" yet.");
                    }
                }
                else if (deeperChoice.Contains("not right now") || deeperChoice.Contains("maybe later"))
                {
                    await Utils.ChatbotResponse($"Alright {WelcomeMessage.Name}, well circle back.");
                    continue; // Loop back to asking what they want to learn about
                }
                else
                {
                    await Utils.ChatbotResponse("Sorry, I didn't catch that. Let's keep going.");
                }

                continue; // Go back to main question loop after dealing with deeper topic
            }


            //Checks for follow-up questions
            if (currentTopic != null && (userInput.Contains("more") || userInput.Contains("details") || userInput.Contains("explain")))
            {
                // Provide more information on the current topic
                if (AddedImplementation_CABChatBot.FollowUpResponses.TryGetValue(currentTopic, out string[] followUpResponses))
                {
                    var random = new Random();
                    string followUpResponse = followUpResponses[random.Next(followUpResponses.Length)];
                    Utils.ColorBorders("divider1");
                    await Utils.ChatbotResponse(followUpResponse);
                    Utils.ColorBorders("divider2");
                }
                else
                {
                    await Utils.ChatbotResponse("Sorry, I don't have more info on that right now.");
                }
                continue; // loops back to main loop
            }

            //Keyword recognition

            bool matched = false;
            foreach (var topic in AddedImplementation_CABChatBot.CybersecurityTopics)
            {
                if (userInput.Contains(topic.Key.ToLower()))
                {
                    currentTopic = topic.Key; // Set the current topic
                    //Utils.ColorBorders("divider1");
                    var _userResponse = topic.Value[new Random().Next(topic.Value.Length)];
                    //Utils.ColorBorders("divider2");
                    //allows for sentiments to be used in the ChatBot responses
                    string usedMood = Utils.DetectingSentiment(userInput);
                    string sentiments = AddedImplementation_CABChatBot.GetSentimentResponse(usedMood);
                    Utils.ColorBorders("divider1");
                    if (sentiments != null)
                    {
                        await Utils.ChatbotResponse(sentiments);
                    }
                    await Utils.ChatbotResponse(_userResponse);
                    Utils.ColorBorders("divider2");

                }
            }
            if (!matched)
            {
                //13. idk logic
                Console.ResetColor();
                Utils.ColorBorders("warning");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"I didn't catch what you said,{WelcomeMessage.Name} \nTry asking about:");
                Console.WriteLine("  - Password security");
                Console.WriteLine("  - Phishing scams");
                Console.WriteLine("  - Safe browsing");
                Console.WriteLine("  - Malware protection");
                Console.WriteLine("  - Public Wi-Fi risks\n");
                Console.ResetColor();
                Utils.ColorBorders("warning");
            }
        }
    }
}

