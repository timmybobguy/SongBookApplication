using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAndDataTesting
{
    class SongBook
    {
        private int songCount;
        private object[] allMySongs;

        public SongBook(int numberOfSongs)
        {
            songCount = 0;
            allMySongs = new object[numberOfSongs];
        }

        public void AddSong(int id, int newSongID, int newBookID, int newSongNum, string newTitle, string newKey, string newBody)
        {
            object newSong = new Song(newSongID, newBookID, newSongNum, newTitle, newKey, newBody);
            allMySongs[id] = newSong;
            //Setting if song is chorus or not
            if (((Song)allMySongs[id]).body.Contains("CHORUS"))
            {
                ((Song)allMySongs[id]).isChorus = true;
            }
            songCount++;
        }

        public int GetCount()
        {
            return songCount;
        }

        //This method will return the body of the song split into paragraphs
        public string[] GetSongBody(int id)
        {
            string[] lines = ((Song)allMySongs[id]).body.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            int numOfParagraphs = 1;
            
            //Getting the number of paragraphs
            for (var i = 0; i < lines.Length; i++)
            {
                if (lines[i] == "")
                {
                    numOfParagraphs += 1;
                }
            }

            if (((Song)allMySongs[id]).isChorus == true)
            {
                numOfParagraphs += (numOfParagraphs-2); // This is the extra choruses inbetween verses
            }

            
            string[] paragraphs = new string[numOfParagraphs];

            

            



            return paragraphs;
        }

        //This needs to be changed, just returning string for testing --changed to string array--
        public string[] GetAllTitles()
        {
            string[] result = new string[songCount];

            for (var i = 0; i < songCount; i++)
            {
                result[i] = ((Song)allMySongs[i]).title;
            }

            return result;
        }

        public object[] SearchByName(string query)
        {
            /*
            if (query is in the name of a song)
            {

            }
            else if (query is in body of song)
            {

            }
            else
            {
                no results were found
            }
            

            */
            object[] result = new object[1];


            return result;
        }

        //Sorts songs alphabetically
        public void SortSongs()
        {
            //Array.Sort(allMySongs);
        }
    }
}
