using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterTrawler.Models
{
    public class Archive
    {
        public DateTime Timestamp { get; set; }

        public bool IsUsernameSearch { get; set; }

        public string SearchText { get; set; }

        public List<Tweet> Tweets { get; set; }
    }
}
