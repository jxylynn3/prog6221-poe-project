using System;
using System.Collections.Generic;

namespace CAB.ChatBot_App
{
    // This static class handles all the core chatbot logic for topics, follow-ups, and sentiment support.
    public static class AddedImplementation_CABChatBot
    {
        // Dictionary to store cybersecurity topics for the keyboard Recognition feature
        // The key is the keyword for the specific topic (e.g., "password") and the value is an array of string responses for the specific topic.
        public static readonly Dictionary<string, string[]> CybersecurityTopics = new(StringComparer.OrdinalIgnoreCase)
        {
            { "password", new string[] {
                "Crafting a robust password is your first line of defense! Aim for a mix of uppercase and lowercase letters, numbers, and symbols, ensuring it's at least 8 characters long. Think unique phrases or combinations rather than common words or personal dates.",
                "For maximum security, your password should be a complex blend of 8-16 characters, incorporating a variety of character types like A-Z, a-z, 0-9, and special symbols. Avoid anything easily guessable, such as birthdays or pet names.",
                "A truly strong password is a digital fortress. It should be lengthy (8-16 characters minimum) and diversified, featuring a blend of capitals, small letters, numbers, and symbols. Steer clear of dictionary words or sequential patterns."
            }},
            { "strong password", new string[] {
                "To create a strong password, think 'unpredictable.' Combine upper and lowercase letters, numbers, and symbols. It should be at least 8-16 characters long and something you can remember but a hacker can't guess. Try a memorable phrase with substitutions!",
                "A strong password acts as a robust barrier. Ensure it's 8 to 16 characters in length, incorporating a mix of upper and lower case letters, numbers, and symbols. The key is to make it complex and unique, avoiding any personal information.",
                "For an impenetrable password, aim for 8-16 characters or more, using a diverse set of characters: uppercase, lowercase, numbers, and symbols. The more random and less tied to personal details, the better."
            }},
            { "phishing", new string[] {
                "Phishing attempts are digital trickery! Always scrutinize the sender's email address and hover over links before clicking. If something feels off, it probably is. Never provide personal details unless you've independently verified the request.",
                "Beware of phishing: these are cunning attempts to trick you into revealing sensitive data. Always double-check the email sender's authenticity and resist the urge to click on suspicious links or open unexpected attachments.",
                "Phishing scams rely on deception. Before you click or share, verify the source of any email or message. If an offer seems too good to be true, or a request for information feels urgent and unusual, it's a red flag."
            }},
            { "scam", new string[] {
                "Scams are designed to deceive. Be wary of unsolicited communications and offers that sound too good to be true. Always verify the legitimacy of any unexpected contact or request, especially concerning money or personal data.",
                "A scam is a deceptive scheme intended to defraud. Exercise extreme caution when dealing with unknown individuals or organizations, particularly regarding financial or personal information. When in doubt, don't engage.",
                "Recognizing a scam is crucial. Look out for high-pressure tactics, demands for immediate payment, or promises of unrealistic returns. If something feels suspicious, trust your instincts and research before acting."
            }},
            { "ransomware", new string[] {
                "Ransomware holds your files hostage! Your best defense is a robust antivirus and, crucially, regular backups of all your important data. If the worst happens, you can restore your files without paying the ransom.",
                "Ransomware is malicious software that encrypts your files, demanding payment for their release. Protect yourself by maintaining updated antivirus software and consistently backing up your critical data to an external drive or cloud.",
                "To mitigate the risk of ransomware, keep your operating system and antivirus software current. The most effective safeguard is having reliable, offline backups of your essential files, so you're never forced to pay a ransom."
            }},
            { "malware", new string[] {
                "Malware is a broad term for harmful software like viruses, worms, and Trojans. To keep your devices safe, always use reputable antivirus software and be cautious about what you download and from where.",
                "Malware encompasses any software designed to harm or gain unauthorized access to your computer. Common types include viruses, worms, Trojans, and spyware. Regular scans with antivirus software are key to detection and removal.",
                "Protecting against malware involves vigilance. Be cautious of suspicious downloads and email attachments. Keep your operating system and applications updated, and always run a reliable antivirus solution."
            }},
            { "firewall", new string[] {
                "Think of a firewall as your network's bouncer. It stands guard, controlling who gets in and out of your digital space, blocking unauthorized access attempts to keep your data secure.",
                "A firewall is a critical network security system that acts as a barrier, monitoring and filtering incoming and outgoing network traffic. It's essential for preventing unauthorized access to your computer or network.",
                "Your firewall is a digital security gate. It examines all network traffic, permitting legitimate data to pass through while blocking potentially harmful or unauthorized connections."
            }},
            { "vpn", new string[] {
                "A VPN is your online privacy cloak. It encrypts your internet connection, shielding your data and hiding your IP address, especially useful when using public Wi-Fi to keep your information safe from prying eyes.",
                "A Virtual Private Network (VPN) creates a secure, encrypted tunnel for your internet traffic. This not only hides your IP address but also protects your data from surveillance and potential interception, particularly on unsecured networks.",
                "Using a VPN is like browsing the internet through a secure, private tunnel. It encrypts your data and masks your location, offering a crucial layer of security and anonymity, particularly when you're connected to public Wi-Fi hotspots."
            }},
            { "social engineering", new string[] {
                "Social engineering is about manipulating people, not technology, to gain access to information. Always be skeptical of unsolicited requests for personal data, and verify identities independently before sharing anything confidential.",
                "Social engineering exploits human psychology to trick individuals into revealing confidential information. Always question unexpected requests for sensitive data and confirm the legitimacy of the requester through an independent channel.",
                "Be aware of social engineering tactics: these involve psychological manipulation to bypass security. Never feel pressured to disclose personal information, and always verify the identity of someone asking for sensitive data."
            }},
            { "encryption", new string[] {
                "Encryption is like speaking in a secret code. It scrambles your data, making it unreadable to anyone without the correct key, which is vital for protecting sensitive information both in transit and at rest.",
                "Encryption is the process of transforming data into an unreadable, coded format, ensuring that only authorized parties with the decryption key can access it. It's fundamental for securing sensitive information across all digital platforms.",
                "To secure your sensitive data, encryption is paramount. It converts your information into a secure format, rendering it unintelligible to unauthorized individuals and thereby safeguarding its confidentiality."
            }},
            { "2fa", new string[] {
                "2FA adds a powerful extra layer of security! Beyond your password, it requires a second verification method, like a code from your phone. Even if your password is stolen, your account remains secure.",
                "Two-factor authentication (2FA) significantly boosts your account security. It demands two distinct forms of verification—something you know (your password) and something you possess (like a phone or security token)—before granting access.",
                "Enable 2FA wherever possible! It's a robust security measure that requires a second piece of evidence beyond your password, such as a temporary code sent to your mobile device, making it much harder for unauthorized access."
            }},
            { "two factor authentication", new string[] {
                "Two-factor authentication is a simple yet effective way to make your accounts much harder to compromise. It layers on security by asking for a second piece of proof beyond your password, often a code sent to your phone.",
                "For enhanced security, activate two-factor authentication. This method requires both something you know (your password) and something you have (such as a unique code from a mobile app or a physical token) to confirm your identity.",
                "Two-factor authentication (2FA) is a critical security upgrade. It ensures that even if your password is leaked, your account remains secure because an attacker would also need access to your secondary verification method."
            }},
            { "update", new string[] {
                "Keeping your software updated isn't just about new features; it's crucial for security! Updates often patch vulnerabilities that hackers exploit, so make it a habit to install them promptly.",
                "Regularly updating your software, apps, and operating systems is paramount for cybersecurity. These updates often include critical security patches that fix vulnerabilities, protecting you from known cyber threats.",
                "Always prioritize software updates. They are designed to close security loopholes and improve overall system resilience, significantly reducing your exposure to cyberattacks and improving performance."
            }},
            { "antivirus", new string[] {
                "Antivirus software is your digital immune system. Keep it updated and running to detect, prevent, and remove malicious software, acting as your first line of defense against online threats.",
                "Reliable antivirus software is essential for detecting, preventing, and eliminating malware. Ensure it's always up-to-date and performing regular scans to protect your system from digital infections.",
                "For comprehensive protection, invest in and regularly update your antivirus software. It's designed to identify and neutralize various forms of malware, safeguarding your computer from harmful programs."
            }},
            { "cybersecurity tips", new string[] {
                "Boost your cybersecurity with these key tips: Use strong passwords, enable 2FA, be wary of suspicious links, keep all software updated, use quality antivirus, back up your data, and use a VPN on public Wi-Fi.",
                "To maintain strong cybersecurity, remember these practices: create complex passwords, activate 2FA, avoid clicking unknown links, regularly update all software, deploy antivirus, frequently back up your data, and use a VPN on public networks.",
                "Improve your digital safety with these essential tips: Prioritize strong, unique passwords, always enable two-factor authentication, remain vigilant against phishing attempts, ensure all your software is current, utilize effective antivirus software, perform regular data backups, and secure your public Wi-Fi use with a VPN."
            }},
            { "cybersecurity", new string[] {
                "Cybersecurity is the broad practice of safeguarding digital systems and data from attacks. It encompasses a range of strategies, from using firewalls and encryption to practicing good password hygiene and regular software updates.",
                "Cybersecurity refers to the protection of computer systems, networks, and data from digital attacks, damage, or unauthorized access. It involves a combination of technologies, processes, and user practices like using firewalls, encryption, and safe password habits.",
                "Essentially, cybersecurity is about keeping your digital life safe. This involves technical measures like firewalls and antivirus, alongside personal habits such as using strong passwords, understanding phishing, and regularly updating your software."
            }},
            { "data breach", new string[] {
                "A data breach is a serious security incident where sensitive information is accessed or stolen without authorization. Prevent this by using strong, unique passwords, enabling 2FA, and consistently updating your software to patch vulnerabilities.",
                "A data breach occurs when confidential data is exposed or stolen from a secure system. To minimize your risk, implement strong, unique passwords for all accounts, activate two-factor authentication, and ensure all your software is kept up-to-date.",
                "To avoid becoming a victim of a data breach, focus on foundational security: use robust, distinct passwords for each account, enable 2FA whenever available, and diligently apply software updates to close potential security gaps."
            }},
        };

        // Separate dictionary for follow-up responses after the user says "Tell me more" or something similar.
        // Follow-up responses for important topics - now providing direct answers
        public static readonly Dictionary<string, string[]> FollowUpResponses = new(StringComparer.OrdinalIgnoreCase)
        {
            // These go deeper into specific topics,thus creating a convo feel
            { "password", new string[] {
                "To create a strong, memorable password, use a *passphrase*. This is a sentence or string of unrelated words that's long and unique. For example, instead of 'password123', try 'My blue dog jumped over the lazy moon!'. You can add numbers or symbols in unusual places, like 'MyBlued0gJmpd!ovrTheLazyM00n?'.",
                "You shouldn't reuse passwords across different accounts because if one of your passwords is stolen from a data breach on one website, hackers will immediately try that same password on all your other accounts. This is called a 'credential stuffing attack' and it's incredibly common and successful.",
                "Password managers are secure applications that store all your passwords in an encrypted 'vault' and can even generate strong, unique passwords for you. You only need to remember one master password to unlock the manager. They are highly recommended for managing multiple strong passwords securely."
            }},
            { "social engineering", new string[] {
                "Common social engineering tactics include creating a sense of urgency or fear (e.g., claiming your account is compromised), impersonating authority figures (like your boss or bank), baiting you with tempting offers (e.g., a free download), or using a 'quid pro quo' where they offer a service in exchange for information.",
                "You can spot a social engineering attempt by looking for unexpected, urgent, or emotional requests. Check if the message or call creates fear or extreme pressure. Also, be suspicious if they ask for sensitive information they should already have, or ask you to go outside normal procedures. Always verify the sender's true identity.",
                "If you think you're being targeted by social engineering, the first rule is: *Stop, Think, and Verify*. Don't click any links, open attachments, or reply. Contact the alleged sender or organization through a *known, official channel* (like their official website or a phone number you look up yourself, not one provided in the suspicious message) to confirm if the request is legitimate."
            }},
            { "scam", new string[] {
                "Beyond phishing, common types of scams include Romance Scams (where criminals build fake relationships online to get money), Tech Support Scams (where fake agents claim your computer has a virus and charge for unnecessary repairs), Prize/Lottery Scams (asking for upfront fees to claim a non-existent prize), and Investment Scams (promising impossibly high returns).",
                "You can tell if an offer or request is a scam by looking for demands for unusual payment methods (like gift cards, wire transfers, or cryptocurrency), pressure to act immediately, promises of 'too good to be true' returns, or unexpected requests for personal information from an unknown source. Poor grammar or spelling can also be a sign.",
                "If you fall victim to a scam, act quickly. If you've sent money, contact your bank or financial institution immediately to report the fraud. If you've shared personal information, monitor your accounts and credit reports for any suspicious activity and change any compromised passwords. Always report the scam to relevant authorities like your local police or fraud reporting agencies."
            }},
            { "phishing", new string[] {
                "You can identify a phishing email or text message by checking the sender's actual email address (not just the display name) for slight misspellings or unofficial domains. Hover over links to see the true URL before clicking. Also, look for poor grammar, spelling errors, generic greetings, and urgent or threatening language demanding immediate action.",
                "The main difference is targeting. Regular phishing is a broad, untargeted attempt sent to many people, like casting a wide net. Spear phishing, however, is highly targeted; attackers do research to personalize the message to a specific individual or small group, making it much more convincing because it includes details specific to you or your organization.",
                "If you receive a suspicious email or text that might be phishing, *do not click any links, open any attachments, or reply to the message*. If it's an email, mark it as junk or phishing. If it's a text, delete it. If the message pretends to be from a company you use, go directly to their official website by typing their URL into your browser (do not use a link from the suspicious message) to check your account."
            }},
        };

        // Method to detect if a keyword from the user's input matches a cybersecurity topic
        // If matched, returns one of the random responses from the array
        public static bool GetResponse(string userInput, out string response)
        {
            foreach (var entry in CybersecurityTopics)
            {
                if (userInput.Contains(entry.Key, StringComparison.OrdinalIgnoreCase))
                {
                    // Select a random response from the array
                    var random = new Random();//randomising the responses for the user
                    response = entry.Value[random.Next(entry.Value.Length)];
                    return true;
                }
            }
            response = null;
            return false;
        }
        // Same as TryGetResponse but for follow-up questions to go deeper on a topic
        public static bool GetFollowUpResponse(string userInput, out string response)
        {
            foreach (var entry in FollowUpResponses)
            {
                if (userInput.Contains(entry.Key, StringComparison.OrdinalIgnoreCase))
                {
                    // Select a random follow-up response from the array
                    var random = new Random();
                    response = entry.Value[random.Next(entry.Value.Length)];
                    return true;
                }
            }
            response = null;
            return false;
        }
        // Sentiment detection + response feature: uses how the user is feeling,and return a message that shows empathy.
        public static string GetSentimentResponse(string usedMood)
        {
            switch (usedMood) // This switch matches known moods and returns a supportive message accordingly
            {
                case "worried":
                    return "Don't worry, you're not alone — we can figure this out together!";
                case "frustrated":
                    return "I get it, cybersecurity can be tricky! Let’s take it one step at a time.";
                case "curious":
                    return "Ooo, love that curiosity! Let's dig in!";
                case "bored":
                    return "Let's spice it up! Cybersecurity's way more interesting than it sounds.";
                default:
                    return null;
            }
        }

    }
}
