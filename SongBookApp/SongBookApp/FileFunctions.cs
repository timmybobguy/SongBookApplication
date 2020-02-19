using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongBookApp
{
    class FileFunctions
    {
        public string GetWorkingDirectory()
        {
            try
            {
                string directory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                string finalPath = Path.Combine(directory, "..\\..\\..\\Export");

                return finalPath;
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
                return "error";
            }
        }
    }
}
