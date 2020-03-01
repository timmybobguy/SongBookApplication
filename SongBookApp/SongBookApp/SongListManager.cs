using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongBookApp
{
    public class SongListManager
    {
        public List<Songlist> allMySongLists = new List<Songlist>();


        public void AddSongList(int[] newSongListArray, string newListName)
        {
            Songlist x = new Songlist();
            x.AddSongList(newSongListArray, newListName);
            allMySongLists.Add(x);
        }

        public void LoadSongLists()
        {

        }

    }
}
