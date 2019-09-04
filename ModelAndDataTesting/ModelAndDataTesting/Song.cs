using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAndDataTesting
{
    public class Song
    {
        public int songId;
        public int bookId;
        public int songNum;
        public string title;
        public string key;
        public string body;

        public Song(int newSongID, int newBookID, int newSongNum, string newTitle, string newKey, string newBody)
        {
            songId = newSongID;
            bookId = newBookID;
            songNum = newSongNum;
            title = newTitle;
            key = newKey;
            body = newBody;
        }

        //This method will return the body of the song split into paragraphs
        public string[] GetSongBody()
        {
            string[] result = new string[5];

            return result;
        }
    }
}
