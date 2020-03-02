using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongBookApp
{
    public class Songlist
    {
        public int[] songListArray;
        public string listName;

        public override string ToString()
        {
            return listName;
        }

        public void AddSongList(int[] newSongListArray, string newListName)
        {
            songListArray = newSongListArray;
            listName = newListName;
        }

    }
}
