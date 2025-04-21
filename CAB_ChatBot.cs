using System;

public class CAB_ChatBot
{
    public async Task CyberSecurityQuestion()
    {
        Console.WriteLine("Hello! I'm CAB Bot, your Cybersecurity Assistant.");
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
            await Utils.ChatbotResponse("Thanks for sharing! Now, how can I assist you today?");
        }

        while (true)
        {
            Utils.SetUserTypingColor();
            string userQuestion = Console.ReadLine().ToLower();
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkCyan;

            if (userQuestion.Contains("password") || userQuestion.Contains("strong password"))
            {
                Utils.ColorBorders("divider1");
                await Utils.ChatbotResponse("A strong password should be at least 8-16 characters long, with a mix of uppercase, lowercase, numbers, and symbols. " +
                    "Avoid using common words or personal info. Here is a great example of a strong password 'Tr0pical!S3curity2025'. Alternatively, consider using a password manager to store and generate secure passwords.");
                Utils.ColorBorders("divider2");
            }
            else if (userQuestion.Contains("phishing") || userQuestion.Contains("scam email"))
            {
                Utils.ColorBorders("divider1");
                await Utils.ChatbotResponse("Phishing scams uses Social engineering,to trick you into sharing personal information." +
                    " Common signs include: \n" +
                                  "   - Urgent messages like 'Your account will be suspended!'\n" +
                                  "   - Emails from unknown senders with suspicious links\n" +
                                  "   - Poor grammar or strange-looking email addresses.\n" +
                   "Remember,always verify the sender before clicking links, and never enter your password on an unverified site.");
                Utils.ColorBorders("divider2");
            }
            else if (userQuestion.Contains("safe browsing") || userQuestion.Contains("secure websites"))
            {
                Utils.ColorBorders("divider1");
                await Utils.ChatbotResponse("Ways to stay safe online: \n" +
                                  "   - Always use HTTPS websites (secure connection).\n" +
                                  "   - Avoid downloading files from unknown sources.\n" +
                                  "   - Use browser extensions that block malicious sites (like HTTPS Everywhere).");
                Utils.ColorBorders("divider2");
            }
            else if (userQuestion.Contains("two-factor") || userQuestion.Contains("2fa"))
            {
                Utils.ColorBorders("divider1");
                await Utils.ChatbotResponse("Two-Factor Authentication (2FA) is an implementation that adds an extra layer of security to the safeguarding of your data. In the event,that someone attempts to steals your password, they won’t get in without the second step (e.g., a code sent to your phone)." +
                    "To kp yourself safe from any potential attacks, Always enable 2FA on important accounts like email, banking, and social media.");
                Utils.ColorBorders("divider2");
            }
            else if (userQuestion.Contains("vpn") || userQuestion.Contains("private browsing"))
            {
                Utils.ColorBorders("divider1");
                await Utils.ChatbotResponse(" A VPN (Virtual Private Network) encrypts your internet connection, making it harder for hackers to track you. However, be careful: \n" +
                                  "   - Use paid, reputable VPNs (like NordVPN, ExpressVPN).\n" +
                                  "   - Avoid free VPNs—many log your data or sell it!");
                Utils.ColorBorders("divider2");
            }
            else if (userQuestion.Contains("malware") || userQuestion.Contains("virus"))
            {
                Utils.ColorBorders("divider1");
                await Utils.ChatbotResponse(" Malware can infect your device through:\n" +
                                  "   - Suspicious email attachments\n" +
                                  "   - Fake software downloads\n" +
                                  "   - Malicious ads (malvertising)\n" +
                                  "   -That is why its important to always keep your antivirus updated, avoid sketchy downloads, and think before you click!");
                Utils.ColorBorders("divider2");
            }
            else if (userQuestion.Contains("data breach") || userQuestion.Contains("hacked"))
            {
                Utils.ColorBorders("divider1");
                await Utils.ChatbotResponse(" In the event your data is leaked during a breach, here’s what to do:\n" +
                                  "   1️. Check if you're affected on sites like 'haveibeenpwned.com'.\n" +
                                  "   2️. Change your passwords immediately (use a password manager).\n" +
                                  "   3️. Enable 2FA to add extra protection.");
                Utils.ColorBorders("divider2");
            }
            else if (userQuestion.Contains("social engineering") || userQuestion.Contains("scam calls"))
            {
                Utils.ColorBorders("divider1");
                await Utils.ChatbotResponse(" Social Engineering is when hackers manipulate people to give away information. Examples include:\n" +
                                  "   - Fake tech support calls (''Hello, this is Microsoft Support'')\n" +
                                  "   - Impersonation scams (someone pretending to be your boss or friend)\n" +
                                  "   - Always verify identities before sharing personal info!");
                Utils.ColorBorders("divider2");
            }
            else if (userQuestion.Contains("public wi-fi") || userQuestion.Contains("free wi-fi"))
            {
                Utils.ColorBorders("divider1");
                await Utils.ChatbotResponse(" Public Wi-Fi Risks: \n" +
                                  "  - Hackers can set up fake Wi-Fi hotspots to steal your data.\n" +
                                  "  - Use a VPN or Mobile Data for sensitive browsing (like banking).");
                Utils.ColorBorders("divider2");
            }
            else if (userQuestion.Contains("safe shopping") || userQuestion.Contains("buy online"))
            {
                Utils.ColorBorders("divider1");
                await Utils.ChatbotResponse("Online Shopping Safety Tips: \n" +
                                  "   - Stick to trusted websites (Amazon, official brand sites).\n" +
                                  "   - Use secure payment methods (Credit Card, PayPal—never direct bank transfers!).\n" +
                                  "   - Look for HTTPS & lock icon in the address bar.");
                Utils.ColorBorders("divider2");
            }
            else if (userQuestion.Contains("thank you") || userQuestion.Contains("thanks") || userQuestion.Contains("Im good"))
            {
                Utils.ColorBorders("divider1");
                await Utils.ChatbotResponse("You're welcome! Stay safe online, and remember—think before you click!");
                Utils.ColorBorders("divider2");
                break;
            }
            else
            {
                Console.ResetColor();
                Console.WriteLine(Utils.Warning_Border);
                Console.ResetColor();
                Console.WriteLine("\nI'm here to help with cybersecurity! Try asking about:");
                Console.WriteLine("  - Password security");
                Console.WriteLine("  - Phishing scams");
                Console.WriteLine("  - Safe browsing");
                Console.WriteLine("  - Malware protection");
                Console.WriteLine("  - Public Wi-Fi risks\n");
                Console.ResetColor();
                Console.WriteLine(Utils.Warning_Border);
                continue; // re-prompt without ending
            }
            Console.ResetColor();
            
        }

    }
}
