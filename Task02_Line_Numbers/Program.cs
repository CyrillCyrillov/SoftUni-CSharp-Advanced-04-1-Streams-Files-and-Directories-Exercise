using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Task02_Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathToRead = Path.Combine("data", "text.txt");
            var lines = File.ReadAllLines(pathToRead); // string[] lines = ...

            Regex lettersCount = new Regex(@"[a-zA-Z]");
            Regex punctuationMarksCount = new Regex(@"-|,|""|\.|'|\?|!|:|;");

            string pathToWrite = Path.Combine("data", "output.txt");
            string[] linesToWrite = new string[lines.Length];
            int lineNumber = 0;
            foreach (var line in lines)
            {
                lineNumber++;
                int letters = lettersCount.Matches(line).Count; 
                int punctuationMarks = punctuationMarksCount.Matches(line).Count;

                linesToWrite[lineNumber - 1] = $"Line {lineNumber}: {line} ({letters})({punctuationMarks})";

                
                //Console.WriteLine(lineToWrite);

            }

            File.WriteAllLines(pathToWrite, linesToWrite);
            
            //Console.WriteLine("Hello World!");
        }
    }
}
