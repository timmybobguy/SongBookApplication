using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAndDataTesting
{
    public class Song
    {
        public int id;
        public int songId;
        public int bookId;
        public int songNum;
        public string title;
        public string key;
        public string body;
        public bool isChorus;

        public Song(int newId, int newSongID, int newBookID, int newSongNum, string newTitle, string newKey, string newBody, bool newIsChorus = false)
        {
            songId = newSongID;
            bookId = newBookID;
            songNum = newSongNum;
            title = newTitle;
            key = newKey;
            body = newBody;
            isChorus = newIsChorus;
            id = newId;
        } 
    }
}
