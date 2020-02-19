using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ModelAndDataTesting
{
    class SongBook
    {
        private int songCount;
        private object[] allMySongs;
        private string savePath;

        public SongBook(int numberOfSongs, string newSavePath)
        {
            songCount = 0;
            allMySongs = new object[numberOfSongs];
            savePath = newSavePath;
        }

        public void AddSong(int id, int newSongID, int newBookID, int newSongNum, string newTitle, string newKey, string newBody)
        {
            object newSong = new Song(id, newSongID, newBookID, newSongNum, newTitle, newKey, newBody);
            allMySongs[id] = newSong;
            if (((Song)allMySongs[id]).body.Contains("CHORUS"))
            {
                ((Song)allMySongs[id]).isChorus = true;
            }
            songCount++;
        }

        public void ToXML()
        {
            //for each song etc 

            // Creating xml string and then put string to file 
            //string output = '<?xml version="1.0" encoding="UTF - 8"?>< dataroot >';
            XmlDocument doc = new XmlDocument();

            

            for (var i = 0; i < songCount; i++)
            {
                //output += '<Songs>';
            }
        }

        public int GetCount()
        {
            return songCount;
        }


        //This method will return the body of the song split into paragraphs
        public string[] GetSongBody(int id)
        {
            List<string> paragraphs = new List<string>();
            //paragraphs.Add(paragraphstring);

            string[] lines = ((Song)allMySongs[id]).body.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

            string currentParagraph = "";

            for (var i = 0; i < lines.Length; i++)
            { 
               //Reworking with list currently 
            }

            string[] result = paragraphs.ToArray();
            return result;
        }

        //This needs to be changed, just returning string for testing --changed to string array-- NEEDS TO BE PASSING BACK SONG OBJECTS???
        public string[] GetAllTitles()
        {
            string[] result = new string[songCount];

            for (var i = 0; i < songCount; i++)
            {
                result[i] = ((Song)allMySongs[i]).title;
            }

            return result;
        }

        public object[] SearchSongs(string query, int type)
        {
            StringComparison stringComparison = StringComparison.CurrentCultureIgnoreCase;

            List<object> results = new List<object>();

            for (var i = 0; i < allMySongs.Length; i++)
            {
                if (((Song)allMySongs[i]).body.IndexOf(query, stringComparison) >= 0 && (type == 1 || type == 3))
                {
                    results.Add(((Song)allMySongs[i]));
                }
                if (((Song)allMySongs[i]).title.IndexOf(query, stringComparison) >= 0 && (type == 0 || type == 3))
                {
                    results.Add(((Song)allMySongs[i]));
                }
            }

            object[] result = results.ToArray();
            return result;
        }

        //Sorts songs alphabetically
        public void SortSongs()
        {
            //Array.Sort(allMySongs);
        }
    }
}
