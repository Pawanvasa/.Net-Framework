using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02
{
    public class Post
    {
        public string ?title{ get; set; }
        public string ?description{ get; set; }
        public DateTime createdDateTime { get; set; }
        public int currentVoteValue;

        public void up_vote()
        {
            currentVoteValue++;
        }
        public void down_vote()
        {
            currentVoteValue--;
        }
    }
}
