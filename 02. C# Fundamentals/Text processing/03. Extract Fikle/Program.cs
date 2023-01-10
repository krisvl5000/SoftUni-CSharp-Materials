using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace My_New_Program
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] filePath = Console.ReadLine().Split('\\');

            string fileInfo = filePath.Last();

            string fileName = fileInfo
                .Substring(0, fileInfo
                .LastIndexOf('.'));

            string fileExtension = fileInfo.Substring(fileInfo.LastIndexOf('.') + 1);

            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {fileExtension}");
            
        }
    }
}