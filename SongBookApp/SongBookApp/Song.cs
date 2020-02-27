using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongBookApp
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

        public override string ToString()
        {
            return title;
        }

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

        //This method will return the body of the song split into paragraphs
        public string[] GetSongBody()
        {
            List<string> paragraphs = new List<string>();
            string[] lines = body.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

            int currentLine = 0;
            string currentParagraph = "";
            int paragraphCount = 0;
            string chorus = "";

            while (currentLine != lines.Length)
            { 
                if (lines[currentLine] != "")
                {
                    currentParagraph += lines[currentLine] + "\n";
                } 
                else
                {
                    paragraphs.Add(currentParagraph);

                    if (isChorus)
                    {
                        paragraphCount++;
                        
                        if (paragraphCount % 2 == 0)
                        {
                            if (paragraphCount == 2)
                            {
                                chorus = currentParagraph;
                            }
                            else
                            {
                                paragraphs.Add(chorus);
                            }
                            paragraphCount++;
                        }
                    }  
                    currentParagraph = "";
                }
                currentLine++;
            }
            paragraphs.Add(currentParagraph);

            if (isChorus)
            {
                paragraphCount++;
                paragraphs.Add(chorus);
            }

            
            return paragraphs.ToArray();
        }
    }
}
