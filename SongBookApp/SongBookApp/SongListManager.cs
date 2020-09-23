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

            //Convert the string into an array
            //string[] test = newSongListArray.Split(',');
            //int[] result = new int[test.Length];
            //for (var i = 0; i < test.Length; i++)
            //{
            //    result[i] = Int32.Parse(test[i]);
            //}

            x.AddSongList(newSongListArray, newListName);
            allMySongLists.Add(x);
        }

        public void LoadSongLists()
        {
            
        }

    }
}
