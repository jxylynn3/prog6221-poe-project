using CAB.ChatBot_App;

public class CAB_ChatBot
{
    private string currentTopic = null; // Track the current topic
    public async Task CyberSecurityQuestion()
    {
        Console.WriteLine($"Hello {WelcomeMessage.Name}! I'm CAB Bot, your Cybersecurity Assistant.");
        Utils.WriteWithColor("Before we start — how are you today? ", ConsoleColor.White);

        Console.ForegroundColor = ConsoleColor.White;
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

        while (true)
        {
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

            // Check for exit phrases
            if (userInput.Contains("thank you") || userInput.Contains("thanks") || userInput.Contains("i'm good") || userInput.Contains("im good"))
            {
                Utils.ColorBorders("divider1");
                await Utils.ChatbotResponse($"You're welcome {WelcomeMessage.Name}! Stay safe online, and remember—think before you click!");
                Utils.ColorBorders("divider2");
                break;
            }
            // Check for follow-up questions
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
                continue; // Continue to the next iteration of the loop
            }

            // Keyword recognition
            
            bool matched = false;
            foreach (var topic in AddedImplementation_CABChatBot.CybersecurityTopics)
            {
                if (userInput.Contains(topic.Key.ToLower()))
                {
                    currentTopic = topic.Key; // Set the current topic
                    Utils.ColorBorders("divider1");
                    await Utils.ChatbotResponse(topic.Value[new Random().Next(topic.Value.Length)]);
                    Utils.ColorBorders("divider2");
                    matched = true;
                    break;
                }
            }
            if (!matched)
            {
                Console.ResetColor();
                Utils.ColorBorders("warning");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"I didnt catch what you said,{WelcomeMessage.Name} \nTry asking about:");
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

