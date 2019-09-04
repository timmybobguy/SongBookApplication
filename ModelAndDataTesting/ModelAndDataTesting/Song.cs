using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAndDataTesting
{
    public class Song
    {
        private int songId;
        private int bookId;
        private int songNum;
        private string title;
        private string key;
        private string body;

        public Song(int newSongID, int newBookID, int newSongNum, string newTitle, string newKey, string newBody)
        {
            songId = newSongID;
            bookId = newBookID;
            songNum = newSongNum;
            title = newTitle;
            key = newKey;
            body = newBody;
        }

    }
}
