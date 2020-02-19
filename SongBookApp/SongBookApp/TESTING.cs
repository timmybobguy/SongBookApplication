using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SongBookApp
{
    class TESTING
    {
        static void Main(string[] args)
        {

            string filePath = "C:\\Users\\TimDesk\\Source\\Repos\\SongBookApplication\\ModelAndDataTesting\\ModelAndDataTesting\\songs.xml";

            //Loading the file
            XmlDocument document = new XmlDocument();
            document.Load(filePath);


            //Getting count of songs for loop
            XmlElement root = document.DocumentElement;
            XmlNodeList elemList = root.GetElementsByTagName("Songs");
            int songCount = elemList.Count;
            Console.WriteLine(songCount);

            //For testing purposes rerouting the save file to a testing one instead of the actual file
            filePath = "C:\\Users\\TimDesk\\Source\\Repos\\SongBookApplication\\ModelAndDataTesting\\ModelAndDataTesting\\testingOutput.xml";

            //Creating instance of songbook
            SongBook songBook1 = new SongBook(songCount, filePath);

            //Setting the first node (first song in the XML file)
            XmlNode currNode = document.DocumentElement.FirstChild;

            //Adding all songs into the model
            for (var i = 0; i < songCount; i++)
            {
                XmlElement songElement = (XmlElement)currNode;
                songBook1.AddSong(i, int.Parse(songElement["SongID"].InnerText), int.Parse(songElement["BookID"].InnerText), int.Parse(songElement["SongNum"].InnerText), songElement["Title"].InnerText, songElement["Key"].InnerText, songElement["Body"].InnerText);
                currNode = currNode.NextSibling; //Going to next song in the XML file
            }


            //Testing below here ->


            //This is for printing string arrays to the console

            //Array.ForEach(songBook1.GetSongBody(0), Console.WriteLine);

            //Array.ForEach(songBook1.GetAllTitles(), Console.WriteLine);

            // Search song takes a code, 0 for titles, 1 for body text and 2 for both
            Array.ForEach(songBook1.SearchSongs("The", 0), Console.WriteLine);

            //Console.WriteLine(songBook1.GetCount());
            //Console.WriteLine(songBook1.allMySongs[0]);

            //XmlNode currNode = document.DocumentElement.FirstChild;
            //Console.WriteLine("First song...");
            //Console.WriteLine(currNode.OuterXml);


            Console.ReadKey();
        }
    }
}
