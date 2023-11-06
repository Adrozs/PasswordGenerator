namespace PasswordGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Welcome message
            Console.WriteLine("\r\n _  _ ____ __    ___ __  _  _ ____    ____ __      __  ____ ____ __  __   __ _  ____       \r\n/ )( (  __|  )  / __)  \\( \\/ |  __)  (_  _)  \\    / _\\(    (  _ (  )/ _\\ (  ( \\/ ___)      \r\n\\ /\\ /) _)/ (_/( (_(  O ) \\/ \\) _)     )((  O )  /    \\) D ()   /)(/    \\/    /\\___ \\      \r\n(_/\\_|____)____/\\___)__/\\_)(_(____)   (__)\\__/   \\_/\\_(____(__\\_|__)_/\\_/\\_)__)(____/      \r\n ____  __  ____ ____ _  _  __ ____ ____     ___ ____ __ _ ____ ____  __ ____ __ ____       \r\n(  _ \\/ _\\/ ___) ___) )( \\/  (  _ (    \\   / __|  __|  ( (  __|  _ \\/ _(_  _)  (  _ \\      \r\n ) __/    \\___ \\___ \\ /\\ (  O )   /) D (  ( (_ \\) _)/    /) _) )   /    \\)((  O )   /      \r\n(__) \\_/\\_(____(____(_/\\_)\\__(__\\_|____/   \\___(____)_)__|____|__\\_)_/\\_(__)\\__(__\\_)      \r\n");

            // Declare variables outside loop to be able to use them after loop has closed
            int numValue;
            bool isNumber;

            // Re-promts user until input is a positive integer of 8 or above
            do
            {

                Console.Write("Enter desired length of password (min 8): ");
                isNumber = int.TryParse(Console.ReadLine(), out numValue);
            }
            while (isNumber == false || numValue < 8);

            int length = numValue;

            Console.WriteLine("----------"); // Divider for formatting

            // Creates 3 char arrays of the length that the user chose
            char[] password1 = new char[length];
            char[] password2 = new char[length];
            char[] password3 = new char[length];

            while (true)
            {
                password1 = RandomPassword(length);
                password2 = RandomPassword(length);
                password3 = RandomPassword(length);

                // Prints out password options
                Console.WriteLine(password1);
                Console.WriteLine(password2);
                Console.WriteLine(password3);

                ConsoleKeyInfo key; // Declare variable to save keypress

                while (true)
                {

                    Console.WriteLine("----------"); // Divider for formatting
                    Console.WriteLine("Do you want to pick one of the above password options \n or do you want to genereate new ones?");
                    Console.WriteLine("[1-3]: Pick password");
                    Console.WriteLine("[Enter]: Generate new");

                    key = Console.ReadKey(true); // Saves keypress 

                    // Checks if keypress matches the options, else repeats prompt
                    if (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.NumPad1 && key.Key != ConsoleKey.NumPad2 && key.Key != ConsoleKey.NumPad3)
                    {
                        Console.WriteLine("----------"); // Divider for formatting
                        Console.WriteLine("Invalid keypress");
                    }
                    else { break; }

                }

                Console.WriteLine("----------"); // Divider for formatting

                // If user pressed enter they want new passwords so just continue with the loop
                if (key.Key == ConsoleKey.Enter)
                {

                    continue;
                }
                // If not then we confirm password has been changed and print it out with a loop after we check which password the user chose
                else
                {
                    Thread.Sleep(500); // Waits for 0,5 seconds to give some time for user to see changes

                    Console.WriteLine("Password has been changed.");
                    switch (key.Key)
                    {
                        case ConsoleKey.NumPad1:
                            Console.Write("New password: ");

                            for (int i = 0; i < length; i++)
                                Console.Write(password1[i]);

                            Console.WriteLine("\n----------"); // Divider for formatting

                            Environment.Exit(0);
                            break;
                        case ConsoleKey.NumPad2:
                            Console.Write("New password: ");

                            for (int i = 0; i < length; i++)
                                Console.Write(password2[i]);

                            Console.WriteLine("\n----------"); // Divider for formatting

                            Environment.Exit(0);
                            break;
                        case ConsoleKey.NumPad3:
                            Console.Write("New password: ");

                            for (int i = 0; i < length; i++)
                                Console.Write(password1[i]);

                            Console.WriteLine("\n----------"); // Divider for formatting

                            Environment.Exit(0);
                            break;
                    }
                }
            }
        }

        static internal char[] RandomPassword(int length)
        {
            Random rnd = new Random();

            char[] password = new char[length];

            bool oneUpper = false;
            bool oneLower = false;
            bool oneNumber = false;
            bool oneSpecial = false;

            // Remake the password until there's at least one of each required type
            while(true)
            {
                // Loops length amount of times and assigns a random char to the password(s) on each loop
                for (int i = 0; i < length; i++)
                {
                    // Random value between 1-4 to randomly select between upper- lowercase, numbers and special chars
                    int selector = rnd.Next(1, 5);

                    // Returns chars by randomizing ascii characters
                    switch (selector)
                    {
                        case 1:
                            password[i] = randomUpper(); // Uppercase
                            oneUpper = true;
                            break;
                        case 2:
                            password[i] = randomLower(); // Lowercase
                            oneLower = true;
                            break;
                        case 3:
                            password[i] = randomNumber(); // Number
                            oneNumber = true;
                            break;
                        case 4:
                            password[i] = randomSpecialChar(); // Special character
                            oneSpecial = true;
                            break;
                        default:
                            password[i] = randomNumber(); // Number for default value because we need a default value for all codepaths to return true or code wont compile
                            oneNumber = true;
                            break;
                    }
                }

                // If one of them are false, reset all to false and continue the loop
                if (oneUpper == false || oneLower == false || oneNumber == false || oneSpecial == false)
                {
                    oneUpper = false;
                    oneLower = false;
                    oneNumber = false;
                    oneSpecial = false;
                    continue;
                }
                // When at least one of each exist in a password, exit the loop and return the password
                else
                {
                    break;
                }
            }

            return password;
        }

        // Returns a random uppercase letter
        static char randomUpper()
        {
            Random rnd = new Random();
            return (char)(rnd.Next(65, 90));
        }

        // Returns a random lowercase letter
        static char randomLower()
        {
            Random rnd = new Random();
            return (char)(rnd.Next(97, 122));
        }

        // Returns a random number between 0-9
        static char randomNumber()
        {
            Random rnd = new Random();
            return (char)(rnd.Next(48, 57));
        }

        // Returns a random special character
        static char randomSpecialChar()
        {
            Random rnd = new Random();
            return (char)(rnd.Next(33, 47));
        }

    }
}