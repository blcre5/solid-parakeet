using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        do{
        Console.Clear(); // Clear the console for a fresh start
        Console.WriteLine("Password Generator");
        Console.WriteLine("=================");
        
        Console.Write("Enter password length (minimum 8): ");
        if (!int.TryParse(Console.ReadLine(), out int length) || length < 8)
        {
            Console.WriteLine("Invalid length. Using default length of 12.");
            length = 12;
        }

        string password = GeneratePassword(length);
        Console.WriteLine($"\nYour generated password is: {password}");
        Console.WriteLine("\nPress 'Y' to generate another password or any other key to exit.");
        }while (Console.ReadKey(true).Key == ConsoleKey.Y); // Loop to generate another password if 'Y' is pressed
    }

    static string GeneratePassword(int length)
    {
        const string uppercaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string lowercaseChars = "abcdefghijklmnopqrstuvwxyz";
        const string numberChars = "0123456789";
        const string specialChars = "!@#$%^&*()_+-=[]{}|;:,.<>?";

        Random random = new Random();
        StringBuilder password = new StringBuilder();

        // Ensure at least one character from each category
        password.Append(uppercaseChars[random.Next(uppercaseChars.Length)]);
        password.Append(lowercaseChars[random.Next(lowercaseChars.Length)]);
        password.Append(numberChars[random.Next(numberChars.Length)]);
        password.Append(specialChars[random.Next(specialChars.Length)]);

        // Fill the rest of the password
        string allChars = uppercaseChars + lowercaseChars + numberChars + specialChars;
        for (int i = 4; i < length; i++)
        {
            password.Append(allChars[random.Next(allChars.Length)]);
        }

        // Shuffle the password
        return new string(password.ToString().ToCharArray()
            .OrderBy(x => random.Next()).ToArray());
    }
}