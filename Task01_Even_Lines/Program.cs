using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Task01_Even_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathToRead = Path.Combine("data", "Text.txt");

            Regex replace = new Regex(@"-|,|\.|!|\?");

            using(StreamReader readFromFile = new StreamReader(pathToRead))
            {
                int lineCounter = -1;
                while (true)
                {
                    
                    string nextLineRaw = readFromFile.ReadLine();
                    if(nextLineRaw == null)
                    {
                        break;
                    }
                    
                    string[] nextLine = nextLineRaw.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                    lineCounter++;

                    if(lineCounter % 2 == 0)
                    {
                        for (int i = nextLine.Length - 1; i >= 0; i--)
                        {
                            nextLine[i] = replace.Replace(nextLine[i], "@");
                            Console.Write(nextLine[i]);

                            if(i > 0)
                            {
                                Console.Write(" ");
                            }
                        }
                        Console.WriteLine();
                    }
                }


            }
            
            //Console.WriteLine("Hello World!");
        }
    }
}
