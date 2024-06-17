namespace HangMan;
public class HangManState
{
    string[] words = {"string", "int", "class", "array", "Collection",
                          "IEnumerable", "IQueryable", "Dependency Injection", "Lifetime", "Scoped"};
    Random random = new();
    int index;
    string wordToGuess;
    public List<char> wordToGuessProgress = new();
    public int health = 6;
    public char[] alphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

    public HangManState()
    {
        index = random.Next(0, words.Length);
        wordToGuess = words[index];
        for(int i=0; i<wordToGuess.Length; i++)
        {
            wordToGuessProgress.Add('_');
        }
    }

    public bool TryLetter(char letter)
    {
        if(!alphabet.Contains(letter))
        {
            Console.WriteLine("You already tried that letter");
            return true;
        }
        int aIndex = Array.IndexOf(alphabet, letter);
        alphabet[aIndex] = '0';

        List<int> indices = FindAllIndicesOfLetterInWord(wordToGuess, letter);

        foreach(int i in indices)
        {
            wordToGuessProgress[i] = letter;
        }
        if(indices.Count>0)
        {
            Console.WriteLine("Congratz, the letter was in the word");
            return true;
        }
        Console.WriteLine("The letter was not in the word, try again");
        return false;
    }
    public List<int> FindAllIndicesOfLetterInWord(string word, char letter)
    {
        List<int> indices = new();
        for(int i=0; i<word.Length; i++)
        {
            if(char.ToLower(letter) == word[i] || char.ToUpper(letter) == word[i])
            {
                indices.Add(i);
            }
        }
        return indices;
    }






}