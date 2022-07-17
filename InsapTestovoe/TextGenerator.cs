using System.Text;

namespace InsapTestovoe;

public class TextGenerator
{
    private const string Alphabet = "abcdefghijklmnopqrstuvwxyz";
    private readonly Random _rnd = new();
    public IEnumerable<string> GenerateTextArray(int wordsCount, int maxWordLength)
    {
        var wordsArray = Enumerable.Range(0, wordsCount).Select(x =>
        {
            var charsWord = Enumerable.Range(0, _rnd.Next(1, maxWordLength))
                .Select(_ => Alphabet[_rnd.Next(0, Alphabet.Length - 1)]);
            var result = new StringBuilder();
            foreach (var ch in charsWord)
            {
                result.Append(ch);
            }
            return result.ToString();
        });
        return wordsArray;
    }
}