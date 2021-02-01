using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Task03_Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> wordsCounter = new Dictionary<string, int>();

            string pathToRead = Path.Combine("data", "words.txt");
            var keys = File.ReadAllLines(pathToRead); //string[] keys = ...

            //string[] keys = readFile.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            foreach (string key in keys)
            {
                wordsCounter.Add(key, 0);
            }


            pathToRead = Path.Combine("data", "text.txt");
            var lines = File.ReadAllLines(pathToRead);  //string[] lines = ...

            foreach (var line in lines)
            {
                string[] wordsToChek = line.Split(new char[] { ',', '.', '!', '?', ' ', '-', '-' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                foreach (string word in wordsToChek)
                {
                    if (wordsCounter.ContainsKey(word.ToLower()))
                    {
                        wordsCounter[word.ToLower()]++;
                    }
                }
            }

            string pathToWrite = Path.Combine("data", "expectedResult.txt");
            string[] expectedLinesToWrite = new string[3];
            int index = 0;

            foreach (var element in wordsCounter.OrderByDescending(x => x.Value))
            {
                expectedLinesToWrite[index] = $"{element.Key} - {element.Value}";
                index++;
                //writeToFile.WriteLine($"{element.Key} - {element.Value}");
            }

            File.AppendAllLines(pathToWrite, expectedLinesToWrite);

            pathToWrite = Path.Combine("data", "actualResult.txt");
            string[] actualLinesToWrite = new string[3];
            index = 0;

            foreach (var element in wordsCounter)
            {
                expectedLinesToWrite[index] = $"{element.Key} - {element.Value}";
                index++;
                //writeToFile.WriteLine($"{element.Key} - {element.Value}");
            }

            File.AppendAllLines(pathToWrite, expectedLinesToWrite);
            
            //Console.WriteLine("Hello World!");
        }
    }   
}
