using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Configuration;
using System.Collections.Specialized;

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

            //Loading in initial font size setting
            string sAttr;
            sAttr = ConfigurationManager.AppSettings.Get("fontSize");



            // In this main program the file is loaded in and everything is set up, then the visual interface is initiated.

            SongBook songBook = new SongBook();

            SongListManager listManager = new SongListManager();

            FileFunctions file = new FileFunctions();
            file.AddFileFunctions(songBook, listManager);

            // Load file 

            file.SetWorkingDirectory();

            file.LoadDocument();

            // Load songs into songbook

            
            songBook.AddSongBook(file.songCount, file.savePath, int.Parse(sAttr), file);
            // Load song lists into songlistmanager

            XmlNode currNode = file.document.DocumentElement.FirstChild.FirstChild;

            for (var i = 0; i < file.songCount; i++)
            {
                XmlElement songElement = (XmlElement)currNode;
                songBook.AddSong(i, int.Parse(songElement["songId"].InnerText), int.Parse(songElement["bookId"].InnerText), int.Parse(songElement["songNum"].InnerText), songElement["title"].InnerText, songElement["key"].InnerText, songElement["body"].InnerText);
                currNode = currNode.NextSibling; //Going to next song in the XML file
            }

            // DOING SONG LISTS

            
            file.LoadSongLists();

            XmlNode currListNode = file.listDocument.DocumentElement.FirstChild.FirstChild;

            for (var i = 0; i < file.songListCount; i++)
            {
                XmlElement listElement = (XmlElement)currListNode;
                listManager.AddSongList(listElement["songListArray"].InnerText, listElement["listName"].InnerText);
                currListNode = currListNode.NextSibling;
            }

            listManager.LoadSongLists();
            // Then load the visual interface

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartScreen(songBook, file));

            

            
        }
    }
}
