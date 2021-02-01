using System;
using System.IO;

namespace Таск04_Copy_Binary_File
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathToRead = Path.Combine("data", "copyMe.png");
            string pathToWrite = Path.Combine("copyData", "copyMe.png");

            using (FileStream copyFile = new FileStream(pathToRead, FileMode.Open))
            {
                using (FileStream pasteFile = new FileStream(pathToWrite, FileMode.Create))
                {
                    while (true)
                    {
                        byte[] buffer = new byte[4096];
                        int count = copyFile.Read(buffer, 0, buffer.Length); // if count == 0 -> end of the file!!!

                        if(count == 0)
                        {
                            break;
                        }

                        pasteFile.Write(buffer);
                    }
                }
            }
        }
    }
}
