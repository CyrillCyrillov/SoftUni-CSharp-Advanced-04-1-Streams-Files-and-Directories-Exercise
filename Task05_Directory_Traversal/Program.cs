using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;


namespace Task05_Directory_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Kiril\Advanced_CSharp\04_Streams-Files-and-Directories-Exercise\Task04_Copy_Binary_File\bin\Debug\netcoreapp3.1";
            string[] filesInfo = Directory.GetFiles(path);

            Dictionary<string, Dictionary<string, double>> filesProperties = new Dictionary<string, Dictionary<string, double>>();

            foreach (string file in filesInfo)
            {
                FileInfo curentFileInfo = new FileInfo(file);
                double size = Math.Round(curentFileInfo.Length / 1024.0, 3);
                string name = curentFileInfo.Name;
                string extention = curentFileInfo.Extension;

                if(!filesProperties.ContainsKey(extention))
                {
                    filesProperties.Add(extention, new Dictionary<string, double>());
                }
                
                
                filesProperties[extention].Add(name, size);
            }

            string pathToPaste = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "report.txt");
            
            using(StreamWriter writeToFile = new StreamWriter(pathToPaste))
            {
                foreach (var ext in filesProperties.OrderByDescending(x => x.Value.Count))
                {
                    writeToFile.WriteLine(ext.Key);
                    //Console.WriteLine(ext.Key);
                    foreach (var file in ext.Value.OrderBy(y => y.Value))
                    {
                        writeToFile.WriteLine($"--{file.Key} - {file.Value}kb");
                        //Console.WriteLine($"--{file.Key} - {file.Value}kb");
                    }
                }
            }
            

            //Console.WriteLine("Hello World!");
        }
    }
}
