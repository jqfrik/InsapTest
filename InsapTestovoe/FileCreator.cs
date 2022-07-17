namespace InsapTestovoe;

public class FileCreator
{
    public string CreateFileWithData(int wordsCount, int wordLengthLimit)
    {
        var fileName = Guid.NewGuid().ToString() + ".txt";
        var wordsArray = new TextGenerator().GenerateTextArray(wordsCount, wordLengthLimit);
        File.WriteAllLines(fileName,wordsArray);
        return fileName;
    }
}