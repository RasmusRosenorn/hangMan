namespace HangMan;

class Program
{
    static void Main(string[] args)
    {
        HangManState state = new();
        Console.WriteLine("Welcome to HangMan game with programming words");
        Console.WriteLine($"Health: {state.health}");
        Console.Write("Remaining letters: ");
        foreach (char c in state.alphabet)
        {
            if (c != '0')
            {
                Console.Write($"{c} ");
            }
        }
        Console.WriteLine();
        foreach (char c in state.wordToGuessProgress)
        {
            Console.Write(c + " ");
        }
        Console.WriteLine();

        while (state.wordToGuessProgress.Contains('_'))
        {
            Console.Write("Try letter: ");
            char input = Console.ReadKey().KeyChar;
            Console.WriteLine();
            Console.WriteLine();
            if (char.IsLetter(input))
            {
                if (!state.TryLetter(input))
                {
                    state.health--;
                    if (state.health == 0)
                    {
                        Console.WriteLine("You have killed the man and lost the game");
                        break;
                    }
                }
                Console.WriteLine($"Health: {state.health}");
                Console.Write("Remaining letters: ");
                foreach (char c in state.alphabet)
                {
                    if (c != '0')
                    {
                        Console.Write($"{c} ");
                    }
                }

                Console.WriteLine();

                foreach (char c in state.wordToGuessProgress)
                {
                    Console.Write(c + " ");
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Your input was not a letter, try again");
            }
        }
        Console.WriteLine("Game is over");







    }
}
