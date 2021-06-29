using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace ListFiles
{
    /// <summary>
    /// Perform the following tasks:
    ///     Accepts a directory name as the application’s argument.
    ///     The application creates a text file containing all unique file names from the specified directory and its subdirectories.
    ///     Each file name is shown on a new line and doesn’t include the directory name
    ///     File names need to be listed in ASCII traditionally sorted order.  It is not required to sort file names in the naturally human alpha-numeric sort order.
    ///     File names are listed in lower case
    ///     
    ///     Text file output will be created in the same path location.. 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {

            if (args.Count() > 0)
            {

                string path = args[0];
                DirectoryInfo directory = new DirectoryInfo(path);

                SortedSet<string> filesSet = new SortedSet<string>();


                FileInfo[] fileList = directory.GetFiles("*", SearchOption.AllDirectories);

                if (fileList.Count() > 0)
                {
                    foreach (FileInfo file in fileList)
                    {
                        //Console.WriteLine(file.Name);
                        filesSet.Add(file.Name.ToLower()); // ensure file name is unique and lower case
                    }

                    // generate text file with the name sorted FrameWork 3.1
                    using (StreamWriter output = new StreamWriter(Path.Combine(path, "UniqueFileNames.txt")))
                    {
                        foreach (string filename in filesSet)
                        {
                            output.WriteLine(filename);
                        }
                        Console.WriteLine("UniqueFileNames.txt is created at: " + path);
                    }
                }
                else
                {
                    Console.WriteLine("Directory and sub-directories does not contain any files!");
                }


            }
            else
            {
                Console.WriteLine("No path has been provided as arguments, please provide a path when running this application.");
            }

        }

    }
}
