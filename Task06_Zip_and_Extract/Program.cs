using System;
using System.IO;
using System.IO.Compression;

namespace Task06_Zip_and_Extract
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathToZip = Path.Combine("data", "copyMe.png");
            string pathToExtract = Path.Combine("extract");

            using (ZipArchive zipFile = ZipFile.Open("copyMe.zip", ZipArchiveMode.Create))
            {
                ZipArchiveEntry zipArchiveEntry = zipFile.CreateEntryFromFile(pathToZip, "copyMe.png");
            }
        }
    }
}
