using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SongBookApp
{
    public class SongBook
    {
        public int songCount;
        public List<object> allMySongs = new List<object>();
        private string savePath;

        public SongBook(int numberOfSongs, string newSavePath)
        {
            songCount = 0;
            savePath = newSavePath;
        }

        public void AddSong(int id, int newSongID, int newBookID, int newSongNum, string newTitle, string newKey, string newBody)
        {
            object newSong = new Object();
            if (newBody.Contains("CHORUS"))
            {
                newSong = new Song(id, newSongID, newBookID, newSongNum, newTitle, newKey, newBody, true);
            }
            else
            {
                newSong = new Song(id, newSongID, newBookID, newSongNum, newTitle, newKey, newBody);
            }
            allMySongs.Add(newSong);
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


        //This needs to be changed, just returning string for testing --changed to string array-- NEEDS TO BE PASSING BACK SONG OBJECTS???
        

        public object[] GetSearchedTitles(string searchString, bool firstLetter)
        {

            List<object> resultList = new List<object>();

            for (var i = 0; i < allMySongs.Count; i++)
            {
                
                if (firstLetter)
                {
                    if (char.ToUpper(((Song)allMySongs[i]).title[0]) == char.ToUpper(searchString[0]))
                    {
                        resultList.Add(((Song)allMySongs[i]));
                    }
                }
                else
                {
                    if (((Song)allMySongs[i]).title.ToUpper().Contains(searchString.ToUpper()))
                    {
                        resultList.Add(((Song)allMySongs[i]));
                    }
                } 
            }

            object[] result = resultList.ToArray();
            return result;
        }

        public object[] SearchSongs(string query, int type)
        {
            StringComparison stringComparison = StringComparison.CurrentCultureIgnoreCase;

            List<object> results = new List<object>();

            for (var i = 0; i < allMySongs.Count; i++)
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
