using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFU8
{
    class Songs
    {
        string name;
        string author;
        Songs prev;

        public Songs(string name, string author)
        {
            this.name = name;
            this.author = author;
            prev = null;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public void SetAuthor(string author)
        {
            this.author = author;
        }

        public void SetPrev(Songs prev)
        {
            this.prev = prev;
        }
        public string Title()
        {
            return this.name + " - " + this.author;
        }

        public override bool Equals(object d)
        {
            if (d is Songs)
            {
                Songs otherSong = (Songs)d;
                return this.name == otherSong.name && this.author == otherSong.author;
            }

            return false;
        }
    }
}

