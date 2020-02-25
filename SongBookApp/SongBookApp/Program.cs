using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace SongBookApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            // In this main program the file is loaded in and everything is set up, then the visual interface is initiated.

            FileFunctions file = new FileFunctions();

            // Load file 

            file.SetWorkingDirectory();

            file.LoadDocument();

            // Load songs into songbook

            SongBook songBook = new SongBook(file.songCount, file.savePath);

            XmlNode currNode = file.document.DocumentElement.FirstChild;

            for (var i = 0; i < file.songCount; i++)
            {
                XmlElement songElement = (XmlElement)currNode;
                songBook.AddSong(i, int.Parse(songElement["SongID"].InnerText), int.Parse(songElement["BookID"].InnerText), int.Parse(songElement["SongNum"].InnerText), songElement["Title"].InnerText, songElement["Key"].InnerText, songElement["Body"].InnerText);
                currNode = currNode.NextSibling; //Going to next song in the XML file
            }


            // Then load the visual interface

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartScreen(songBook, file));

            

            
        }
    }
}
