using System;
using System.IO; // to use Directory class
using System.IO.Compression; // to use ZipFile class

namespace LazyBackupper
{
    class Program
    {
        static void Main(string[] args)
        {
            // check that there is only 1 arg (string)
            if (args.Length != 1)
            {
                Console.WriteLine("ERROR only one argument allowed, you need to put the path between quotes");
                Environment.Exit(1);
            }

            // check argument, should be a valid folder path between quotes
            if (!Directory.Exists(args[0]))
            {
                Console.WriteLine("ERROR argument is not a valid path");
                Environment.Exit(1);
            }

            string folderToBackup = args[0];
            Console.WriteLine($"INFO path of folder to backup: {folderToBackup}");

            // https://stackoverflow.com/a/5229311
            string directoryName = new DirectoryInfo(folderToBackup).Name;
            Console.WriteLine($"INFO directory name: {directoryName}");

            string parentFolder = new DirectoryInfo(folderToBackup).Parent.FullName;
            Console.WriteLine($"INFO parent folder: {parentFolder}");

            string zipFileName = $"{DateTime.Now.ToString("yyyyMMddTHHmmss")}_backup_{directoryName}.zip";
            Console.WriteLine($"INFO zip filename: {zipFileName}");

            string zipFullPath = Path.Combine(parentFolder, zipFileName);
            Console.WriteLine($"INFO zip full path: {zipFullPath}");

            // https://docs.microsoft.com/en-us/dotnet/api/system.io.compression.zipfile?view=net-6.0#examples
            ZipFile.CreateFromDirectory(folderToBackup, zipFullPath);

            Console.WriteLine($"INFO zip file created: {zipFullPath}");
        }
    }
}
