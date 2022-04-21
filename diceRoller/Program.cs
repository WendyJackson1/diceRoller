public class Program
{

    public static void Main()
    {

        do
        {
            Console.WriteLine("Hello and welcome to the dice rolling game! ");
            DiceRoll();
        } while (RunAgain());
    }
    public static void DiceRoll()
    {

        (int roll1, int roll2, int total, int sidesToTheDie) = GetRollData();
        Console.WriteLine($"You rolled a {roll1} and a {roll2}");
        Console.WriteLine($"The total dice roll was {total}");

        string sixSidedDieMessage = TryGetSixSideDieMessage(roll1, roll2, total);
        if (sidesToTheDie == 6 && !string.IsNullOrEmpty(sixSidedDieMessage))
        {
            Console.WriteLine(sixSidedDieMessage);
        }

    }
    public static (int, int, int, int) GetRollData()
    {
        Random random = new Random();

        while (true)
        {

            int sidesToTheDie = GetDiceSides("Please enter how many side you would like your dice to have.");

            int roll1 = random.Next(1, sidesToTheDie);
            int roll2 = random.Next(1, sidesToTheDie);
            int total = roll1 + roll2;

            if (sidesToTheDie >= 1)
            {
                Console.WriteLine($"You choose to have {sidesToTheDie} sided die");
                return (roll1, roll2, total, sidesToTheDie);
            }
            else
            {
                Console.WriteLine(" I didnt understand. Please enter a valid number.");
            }
        }
    }

    static string TryGetSixSideDieMessage(int roll1, int roll2, int total)
    {
        if (roll1 == 1 && roll2 == 1)
        {
            return "Snake Eyes!";

        }
        else if (roll1 == 1 && roll2 == 2 || roll1 == 2 && roll2 == 1)
        {
            return "Ace Deuce!";
        }
        else if (roll1 == 6 && roll2 == 6)
        {
            return "Box Cars!";
        }
        else if (total == 7 || total == 11)
        {
            return "Win!";
        }
        else if (total == 2 || total == 3 || total == 12)
        {
            return "Crap!";
        }
        return null;
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



