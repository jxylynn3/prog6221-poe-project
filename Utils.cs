using System;

public class Utils
{
    // borders used within the project
    public static string Top_Border = "╭── ⋅  ── ⋅ ── ⋅ ── ✩ ── ⋅  ── ⋅ ──  ⋅  ── ⋅ ──  ⋅ ──╮";
    
    public static string Bottom_Border = "╰──  ⋅  ── ⋅ ── ⋅ ── ✩ ── ⋅  ── ⋅ ──  ⋅  ── ⋅ ──  ⋅ ──╯";
    public static string Warning_Border = "・・・・☆・・・・☆ ・・・・☆・・・・☆ ・・・・";
    public static string Divider_Top = "╭──────────────────────────────.★..─╮";
    public static string Divider_Bottom = "╰─..★.──────────────────────────────╯";


    // Method to make user typing in Dark Cyan
    public static void SetUserTypingColor()
    {
        Console.ForegroundColor = ConsoleColor.DarkCyan;
    }
    //this method will simulate the typing,for a more convo feel
    // Method for chatbot typing effect in Dark gray
    public static async Task ChatbotResponse(string message)
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        foreach (char letter in message)
        {
            Console.Write(letter);
            Thread.Sleep(50);
        }
        Console.WriteLine();
        Console.ResetColor();
    }
    // Method to set Dark Magenta for all borders
    public static void ColorBorders(string _Border)
    {
        Console.ForegroundColor = ConsoleColor.DarkMagenta;

        switch (_Border)
        {
            case "top":
                Console.WriteLine(Top_Border);
                break;
            case "bottom":
                Console.WriteLine(Bottom_Border);
                break;
            case "warning":
                Console.WriteLine(Warning_Border);
                break;
            case "divider1":
                //dividers each question
                Console.WriteLine(Divider_Top); 
                break;
            case "divider2":
                Console.WriteLine(Divider_Bottom);
                break;
            default:
                Console.WriteLine(" Invalid border type.");
                break;
        }

        Console.ResetColor();
    }

    // Method to write text with color
    public static void WriteWithColor(string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write(text);
        Console.ResetColor();
    }
    //implementing sentiments
    //added for part 02
    //the logic implementation for the GetSentimentResponse(string usedMood) method in AddedImplementated_CABChatBot
    public static string DetectingSentiment(string input)
    {
        input = input.ToLower();
        if (input.Contains("worried") || input.Contains("anxious") || input.Contains("scared"))
        {
            return "worried";
        }
        else if (input.Contains("frustrated") || input.Contains("overwhelmed") || input.Contains("confused"))
        {
            return "frustrated";
        }
        else if (input.Contains("curious") || input.Contains("interested") || input.Contains("excited"))
        {
            return "curious";
        }
        else if (input.Contains("bored") || input.Contains("tired"))
        {
            return "bored";
        }
        return "neutral"; // Default mood if no keywords match
    }

}