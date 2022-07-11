namespace HomeWork._5;
using System;
using System.IO;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Windows;
using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            using (var sr = new StreamReader(@"D:\C#\sample.txt", Encoding.UTF8))
            {                  
                var allText = sr.ReadToEnd();
                var regex = new Regex(@"[.?!...][\s\n]");
                var matches = regex.Matches(allText);
                var result = 0;
                foreach (Match match1 in matches)
                {
                    result++;

                }
                Console.WriteLine($"sentence {result}");

                var regex1 = new Regex(@"\b[a-zA-Z]\w*\b");
                var matches1 = regex1.Matches(allText);
                var words = new List<string>();
                var result1 = 0;
                foreach (Match item in matches1)
                {
                    result1++;
                    words.Add(item.Value);
                }
                Console.WriteLine($"words {result1}");
                words.Sort();

                using (var sw = new StreamWriter(@"D:\C#\sample1.txt", false, Encoding.UTF8))
                {
                    sw.WriteLine($"total number of words {result1}");
                    var results = words.GroupBy(x => x)
                                .Where(x => x.Count() > 1)
                                 .Select(x => new { Word = x.Key, Frequency = x.Count() });
                    foreach (var item in results)
                    {
                        sw.WriteLine($"{item.Word} - {item.Frequency}");
                    }

                }

                var regex2 = new Regex(@"[.,?!;:...-](\w*)");
                var matches3 = regex2.Matches(allText);
                var result2 = 0;
                foreach (Match item in matches3)
                {
                    result2++;
                }
                words.Sort();
                Console.WriteLine($"punctuation marks {result2}");

                using (var sw = new StreamWriter(@"D:\C#\sample2.txt", false, Encoding.UTF8))
                {
                    //string line = sr.ReadToEnd();

                    string[] sentence1 = allText.Split(new[] { ".", "!", "?", "\n" }, StringSplitOptions.None);
                    string senten = "";
                    int ctr = 0;
                    foreach (String s1 in sentence1)
                    {
                        if (s1.Length > ctr)
                        {
                            senten = s1;
                            ctr = s1.Length;
                        }
                    }
                    sw.WriteLine($"longest sentence {senten}");
                    Console.WriteLine($"longest sentence {senten}");

                    string[] sentences = Regex.Split(allText, @"(?<=[\.!\?])\s+");
                    var s = sentences[0];
                    var match = Regex.Matches(s, @"((\b[^\s]+))");
                    var List1 = new List<string>();
                    foreach (Match item in match)
                    {
                        List1.Add(item.Value);
                    }
                    foreach (string sentence in sentences)
                    {
                        var matches2 = Regex.Matches(sentence, @"((\b[^\s]+))");
                        var List2 = new List<string>();
                        foreach (Match item in matches2)
                        {
                            List2.Add(item.Value);
                        }
                        if (List2.Count != 0 && List2.Count < List1.Count)
                        {
                            List1 = List2;
                        }

                    }
                    foreach (var item in List1)
                    {
                        sw.WriteLine($"the shortest sentence  {item}");
                        Console.WriteLine($"the shortest sentence  {item}");
                    }
                    
                    var letters = allText.Where(symbol => char.IsLetter(symbol));

                    if (letters.Any())
                    {
                        var result3 = letters
                            .GroupBy(letter => letter)
                            .MaxBy(group => group, new LettersComparer())!;

                        var letter = result3.Key;
                        var count = result3.Count();

                        sw.WriteLine($"the most repeated letter - {letter} ({count} iteration).");
                        Console.WriteLine($"the most repeated letter - {letter} ({count} iteration).");
                    }

                }

            }

        }
    }
