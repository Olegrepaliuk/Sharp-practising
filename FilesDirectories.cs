using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WorkingWithFiles
{
    
    class Program
    {
        static void Main(string[] args)
        {
            List<FileInfo> myFiles = new List<FileInfo>();
            var file1 = new FileInfo(".mp3");
            myFiles.Add(file1);
            var myDirs = GetAlbums(myFiles);
            foreach (var d in myDirs)
            {
                Console.WriteLine(d);
            }

            File.Create("D:\\test.txt");
            
            Console.ReadKey(); 
        }
        public static List<DirectoryInfo> GetAlbums(List<FileInfo> files)
        {
            var dirs = new List<DirectoryInfo>();
            foreach(var file in files)
            {
                if ((file.Extension == ".mp3")|(file.Extension == ".wav"))
                {
                    dirs.Add(file.Directory);
                }
            }
            return dirs;	
        }
    }
}
