using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace SongBookApp
{
    public class FileFunctions
    {
        public string filePath;
        public string savePath;
        public XmlDocument document;
        public XmlDocument listDocument;
        public int songCount;
        public SongBook songBook;
        public SongListManager songListManger;
        public int songListCount;

        public void AddFileFunctions(SongBook newSongBook, SongListManager newSongListManager)
        {
            songBook = newSongBook;
            songListManger = newSongListManager;
        }

        public void SetWorkingDirectory()
        {
            try
            {
                string directory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                
                string finalPath = Path.Combine(directory, "..\\..\\songFiles\\original.xml");
                Console.WriteLine(finalPath);
                filePath = finalPath;

                savePath = Path.Combine(directory, "..\\..\\songFiles\\original.xml"); //For testing right now
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
            XmlNodeList elemList = root.GetElementsByTagName("Song");
            songCount = elemList.Count;
            //Console.WriteLine(songCount);
        }

        public void LoadSongLists()
        {
            listDocument = new XmlDocument();
            listDocument.Load(Path.Combine(filePath, "..\\..\\songLists\\test.xml"));

            // Getting number of songs in file

            XmlElement root = listDocument.DocumentElement;
            XmlNodeList elemList = root.GetElementsByTagName("SongList");
            songListCount = elemList.Count;
        }

        public void ToXML()
        {

            XmlSerializer xs = new XmlSerializer(typeof(SongBook));
            FileStream file = File.Create(savePath);

            //XmlIncludeAttribute(Song)


            xs.Serialize(file, songBook);
            



            file.Close();
        }

        public void ListsToXML()
        {
            XmlSerializer xs = new XmlSerializer(typeof(SongListManager));
            FileStream file = File.Create(Path.Combine(filePath, "..\\..\\songLists\\test.xml"));

            //XmlIncludeAttribute(Song)


            xs.Serialize(file, songListManger);




            file.Close();

        }
    }
}
