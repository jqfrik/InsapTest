﻿using System.Collections.Concurrent;
using InsapTestovoe;

var fileCreator = new FileCreator();
var fileName = fileCreator.CreateFileWithData(10000,10000);
var data = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), fileName));
var dic = new ConcurrentDictionary<char, int>();
var parsed = data.Select(x => new String(x.OrderBy(x => x).ToArray())).ToArray();
Parallel.For(0, parsed.Count(), (i =>
{
    var word = parsed[i];
    foreach (var ch in word)
    {
        if (dic.TryGetValue(ch, out var result))
        {
            dic[ch] = ++result;
        }
        else
        {
            dic.TryAdd(ch, 1);
        }
    }
}));

var maxValue = dic.Values.Max(x => x);
var pair = dic.FirstOrDefault(x => x.Value == maxValue);
var response = new Response()
{
    Char = pair.Key,
    Count = maxValue,
};

return;