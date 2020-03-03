using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace SongBookApp
{
    public class SongBook
    {
        [XmlIgnore]
        public int songCount;
        public List<Song> allMySongs = new List<Song>();
        [XmlIgnore]
        private string savePath;
        [XmlIgnore]
        public int fontSize;
        [XmlIgnore]
        public FileFunctions fileFunctions;

        public void AddSongBook(int numberOfSongs, string newSavePath, int newFontSize, FileFunctions newFileFunctions)
        {
            songCount = numberOfSongs;
            savePath = newSavePath;
            fontSize = newFontSize;
            fileFunctions = newFileFunctions;
        }

        public void AddSong(int id, int newSongID, int newBookID, int newSongNum, string newTitle, string newKey, string newBody)
        {
            Song newSong = new Song();
            if (newBody.Contains("CHORUS"))
            {
                newSong.AddSong(id, newSongID, newBookID, newSongNum, newTitle, newKey, newBody, true);
            }
            else
            {
                newSong.AddSong(id, newSongID, newBookID, newSongNum, newTitle, newKey, newBody, false);
            }
            allMySongs.Add(newSong);
        }
      
        public int GetCount()
        {
            return songCount;
        }
        
        public object[] GetSearchedTitles(string searchString, bool firstLetter)
        {

            List<Song> resultList = new List<Song>();

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

            
            Song[] result = resultList.ToArray();
            Array.Sort(result, delegate (Song user1, Song user2) {
                return user1.title.CompareTo(user2.title);
            });

            return result;
        }

        public object[] SearchSongs(string query, int type)
        {
            StringComparison stringComparison = StringComparison.CurrentCultureIgnoreCase;

            List<Song> results = new List<Song>();

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

            Song[] result = results.ToArray();

            Array.Sort(result, delegate (Song user1, Song user2) {
                return user1.title.CompareTo(user2.title);
            });

            return result;
        }
    }
}
