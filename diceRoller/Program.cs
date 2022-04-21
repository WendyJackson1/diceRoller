public class Program
{

    static Random random = new Random();
    static int roll1;
    static int roll2;
    static int sidesToTheDie;
    static int total;
    static bool runAgain = true;

    public static void Main()
    {
        while (runAgain)
        {
            Console.WriteLine("Hello and welcome to the dice rolling game! ");
            DiceRoll(sidesToTheDie);
            runAgain = RunAgain();
        }
    }


    public static void DiceRoll(int sidesToTheDie)
    {
        while (true)
        {

            sidesToTheDie = GetDiceSides("Please enter how many side you would like your dice to have.");

            roll1 = random.Next(1, sidesToTheDie);
            roll2 = random.Next(1, sidesToTheDie);
            total = roll1 + roll2;

            if (sidesToTheDie >= 1)
            {
                Console.WriteLine($"You choose to have {sidesToTheDie} sided die");
                break;
            }
            else
            {
                Console.WriteLine(" I didnt understand. Please enter a valid number.");
                continue;
            }
        }


        Console.WriteLine($"You rolled a {roll1} and a {roll2}");
        Console.WriteLine($"The total dice roll was {total}");

        if (sidesToTheDie == 6 && roll1 == 1 && roll2 == 1)
        {
            Console.WriteLine("Snake Eyes!");
        }
        else if (sidesToTheDie == 6 && roll1 == 1 && roll2 == 2)
        {
            Console.WriteLine("Ace Deuce!");
        }
        else if (sidesToTheDie == 6 && roll1 == 2 && roll2 == 1)
        {
            Console.WriteLine("Ace Deuce");
        }
        else if (sidesToTheDie == 6 && roll1 == 6 && roll2 == 6)
        {
            Console.WriteLine("Box Cars!");
        }
        else if (sidesToTheDie == 6 && total == 7 || total == 11)
        {
            Console.WriteLine("Win!");
        }
        else if (sidesToTheDie == 6 && total == 2 || total == 3 || total == 12)
        {
            Console.WriteLine("Crap!");
        }

    }

    static int GetDiceSides(string prompt)
    {
        while (true)
        {
            try
            {
                Console.WriteLine(prompt);
                int input = int.Parse(Console.ReadLine());
                return input;
            }
            catch
            {
                Console.WriteLine("sorry not a valid intput");
                continue;
            }
        }
    }


    public static int GetUserInput(string prompt)
    {
        Console.WriteLine(prompt);
        int input = int.Parse(Console.ReadLine().Trim());
        return input;
    }
    public static bool RunAgain()
    {
        Console.WriteLine("Would you like play again? y/n");
        string input = Console.ReadLine().ToLower().Trim();

        if (input == "y")
        {
            return true;
        }
        else if (input == "n")
        {
            Console.WriteLine("Goodbye!");
            return false;
        }
        else
        {
            Console.WriteLine("Sorry didn't understand that, lets try again");
            return RunAgain();
        }
    }

}



