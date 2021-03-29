using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterTrawler.Models;

namespace TwitterTrawler.Services
{
    public class ArchiveBuilder
    {
        /// <summary>
        /// Builds the archive model
        /// </summary>
        /// <param name="isUsername">Whether the user searched via username(true) or hastag(true)</param>
        /// <param name="searchText">The text the user searched with</param>
        /// <param name="tweets">the list of tweets returned</param>
        /// <returns>the built object</returns>
        public Archive BuildArchive(bool isUsername, string searchText, List<Tweet> tweets)
        {
            return new Archive()
            {
                Timestamp = DateTime.Now,
                SearchText = searchText,
                IsUsernameSearch = isUsername,
                Tweets = tweets
            };
        }
    }
}
