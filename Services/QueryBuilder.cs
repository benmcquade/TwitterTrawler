using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterTrawler.Services
{
    public class QueryBuilder
    {
        /// <summary>
        /// Builds a query to be used in the twitter repo
        /// </summary>
        /// <param name="text">the username or hashtag that the user wishes to search with</param>
        /// <param name="isUsername">Whether the user searched via username(true) or hastag(true)</param>
        /// <returns>the URI ready for the twitter repository</returns>
        public string GenerateQuery(string text, bool isUsername)
        {
            var basicQuery = "https://api.twitter.com/2/tweets/search/recent?query=";

            if (isUsername)
            {
                return $"{basicQuery}from:{text}";
            }
            else
            {
                return $"{basicQuery}%23{text}";
            }
        }
    }
}
