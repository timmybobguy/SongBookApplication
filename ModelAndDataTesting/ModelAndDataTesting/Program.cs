using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ModelAndDataTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            //Loading the file
            XmlDocument document = new XmlDocument();
            document.Load("C:\\Users\\TimDesk\\Source\\Repos\\SongBookApplication\\ModelAndDataTesting\\ModelAndDataTesting\\songs.xml");


            //Getting count of songs for loop
            XmlElement root = document.DocumentElement;
            XmlNodeList elemList = root.GetElementsByTagName("Songs");
            int songCount = elemList.Count;
            Console.WriteLine(songCount);

            //Creating instance of songbook
            SongBook songBook1 = new SongBook(songCount);

            //Setting the first node (first song in the XML file)
            XmlNode currNode = document.DocumentElement.FirstChild;

            for (var i = 0; i < songCount; i++)
            {
                XmlElement songElement = (XmlElement)currNode;
                songBook1.AddSong(i, Int32.Parse(songElement["SongID"].InnerText), Int32.Parse(songElement["BookID"].InnerText), Int32.Parse(songElement["SongNum"].InnerText), songElement["Title"].InnerText, songElement["Key"].InnerText, songElement["Body"].InnerText);
                currNode = currNode.NextSibling; //Going to next song in the XML file
            }


            //Testing below here


            Console.WriteLine(songBook1.GetCount());
            Console.WriteLine(songBook1.GetAllTitles());
            

            //XmlNode currNode = document.DocumentElement.FirstChild;
            //Console.WriteLine("First song...");
            //Console.WriteLine(currNode.OuterXml);


            Console.ReadKey();
        }
    }
}
