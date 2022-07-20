using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using InsapTestovoe;

var fileCreator = new FileCreator();
var fileName = fileCreator.CreateFileWithData(10000, 10000);
var data = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), fileName));
var dic = new ConcurrentDictionary<char, int>();
for (int i = 0; i < data.Length; i++)
{
    var word = data[i];
    foreach (var ch in word)
    {
        char charik = ch;
        if (dic.TryGetValue(charik, out var result))
        {
            dic[charik] = ++result;
        }
        else
        {
            dic.TryAdd(charik, 1);
        }
    }
}

var maxValue = dic.Values.Max(x => x);
var pair = dic.FirstOrDefault(x => x.Value == maxValue);
var response = new Response()
{
    Char = pair.Key,
    Count = maxValue,
};