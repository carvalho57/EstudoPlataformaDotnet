using System;

namespace code.Events
{
    public class FileSearcherSample
    {
        public static void Run()
        {
            var fileLister = new FileSearcher();
            var filecounter = 0;
            EventHandler<FileFoundArgs> onFileFound = (sender, eventArgs) =>
            {
                Console.WriteLine($"{eventArgs.FoundFile} \n");
                eventArgs.CancelRequested = false;
                filecounter++;
            };

            fileLister.DirectoryChanged += (sender, eventArgs) =>
            {
                Console.Write($"Entering '{eventArgs.CurrentSearchDirectory}'.");
                Console.WriteLine($" {eventArgs.CompletedDirs} of {eventArgs.TotalDirs} completed...\n");
            };

            fileLister.FileFound += onFileFound;
            // fileLister.FileFound -= onFileFound;

            // fileLister.DirectoryChanged -= (sender, eventArgs) =>
            // {
            //     Console.Write($"Entering '{eventArgs.CurrentSearchDirectory}'.");
            //     Console.WriteLine($" {eventArgs.CompletedDirs} of {eventArgs.TotalDirs} completed...\n");
            // };
            // fileLister.FileFound = null; retire o keyword event


            fileLister.Search($"{Environment.CurrentDirectory}/Events/FileFoundEvent/search", "*.txt",true);
            Console.WriteLine($"\nFile Counter: {filecounter}");
        }
    }
}