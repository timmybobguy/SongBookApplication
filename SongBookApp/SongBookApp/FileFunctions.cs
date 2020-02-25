using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SongBookApp
{
    class FileFunctions
    {
        public string filePath;
        public XmlDocument document;
        public int songCount;


        public void SetWorkingDirectory()
        {
            try
            {
                string directory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                
                string finalPath = Path.Combine(directory, "..\\..\\songFiles\\original.xml");
                Console.WriteLine(finalPath);
                filePath = finalPath;
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }

        public void LoadDocument()
        {
            document = new XmlDocument();
            document.Load(filePath);

            // Getting number of songs in file

            XmlElement root = document.DocumentElement;
            XmlNodeList elemList = root.GetElementsByTagName("Songs");
            songCount = elemList.Count;
            //Console.WriteLine(songCount);
        }
        

    }
}
