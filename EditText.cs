using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace SIGMA_5_SECOND_
{
    class EditText
    {
        private string[] content;

        public string[] Content
        {
            get { return content; }
            set { content = value; }
        }

        public void Print()
        {
            for (int i = 0; i < Content.Length; i++)
            {
                Console.WriteLine(Content[i]);
            }
        }
        public void ReadText(string path)
        {
            StreamReader sr = new StreamReader(path);

            string text = sr.ReadToEnd().Replace("\r", String.Empty);

            Content = text.Split('\n');
        }

        public int GetHashSum()
        {
            int hash = 0;

            for (int i = 0; i < Content.Length; i++)
            {

                hash += Content[i].Count(n => n == '#');

            }

            return hash;
        }

        public void ReplaceEdit(string file)
        {
            ReadText(file);

            int hCount = 0;

            int seperate = GetHashSum() / 2;

            int m = 0;


            for (m = 0; m < Content.Length; m++)
            {
                hCount += Content[m].Count(h => h == '#');

                Content[m] = Content[m].Replace("#", "<");

                if (hCount == seperate)
                {
                    break;
                }
            }

            hCount = 0;

            for (int i = m; i < Content.Length; i++)
            {
                hCount += Content[i].Count(h => h == '#');

                
                Content[i] = Content[i].Replace("#", ">");

                if (hCount == seperate)
                {
                    break;
                }
            }

        }
    }
}
