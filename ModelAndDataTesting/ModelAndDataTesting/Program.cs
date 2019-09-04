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


            XmlNode currNode = document.DocumentElement.FirstChild;

            for (var i = 0; i < songCount; i++)
            {
                XmlElement songElement = (XmlElement)currNode;

                var currentSong = new Song(Int32.Parse(songElement["SongID"].InnerText), Int32.Parse(songElement["BookID"].InnerText), Int32.Parse(songElement["SongNum"].InnerText), songElement["Title"].InnerText, songElement["Key"].InnerText, songElement["Body"].InnerText);
                //Console.WriteLine("Song # {0}:", i);
                //Console.WriteLine(currNode.OuterXml);
                //Console.WriteLine("\r\n");
                currNode = currNode.NextSibling;
            }

            //XmlNode currNode = document.DocumentElement.FirstChild;
            //Console.WriteLine("First song...");
            //Console.WriteLine(currNode.OuterXml);


           // XmlElement songElement = (XmlElement)currNode;

            //string songId = songElement["SongID"].InnerText;


           // Console.WriteLine(songId);



            //XmlNode nextNode = currNode.NextSibling;
            //Console.WriteLine("\r\nSecond song...");
            //Console.WriteLine(nextNode.OuterXml);



            //var filename = "PurchaseOrder.xml";
            //var currentDirectory = Directory.GetCurrentDirectory();
            //var purchaseOrderFilepath = Path.Combine(currentDirectory, filename);





            //var test1 = new Song();



            Console.ReadKey();
        }
    }
}
