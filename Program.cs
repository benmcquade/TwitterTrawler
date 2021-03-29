using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterTrawler.Repository;
using TwitterTrawler.Services;

namespace TwitterTrawler
{

    public class Program
    {
        static void Main(string[] args)
        {
            QueryBuilder queryBuilder = new QueryBuilder();
            TwitterRepository twitterRepository = new TwitterRepository();
            ArchiveRepository archiveRepository = new ArchiveRepository();

            var isUsername = isUsernameNotHashtag();
            var searchText = GetSearchText(isUsername);

            var builtQuery = queryBuilder.GenerateQuery(searchText, isUsername);
            var result = twitterRepository.GetTweetsByUri(builtQuery, 10).ConfigureAwait(false);

            Console.WriteLine("Archiving results");

        }

        /// <summary>
        /// checks if the user wants to search by username or a hashtag
        /// </summary>
        /// <returns>true if user wants to search by username, false if hashtag</returns>
        private static bool isUsernameNotHashtag()
        {
            Console.Clear();
            Console.WriteLine("Please type 'U' for username or 'H' for hashtag search");
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.U)
            {
                return true;
            }
            else if (key.Key == ConsoleKey.H)
            {
                return false;
            }
            else
            {
                Console.WriteLine("That was neither, please press a key to try again.");
                Console.ReadKey();
                return isUsernameNotHashtag();
            }
        }

        /// <summary>
        /// gets the text the user wants to search with
        /// </summary>
        /// <param name="isUsername">whether the user wants to search by username (true) or hashtag (false)</param>
        /// <returns>the text that the user wants to search for, username or hashtag</returns>
        private static string GetSearchText(bool isUsername)
        {
            var question = isUsername ? "username" : "hashtag";
            Console.Clear();
            Console.WriteLine($"Please enter the {question} you wish to retrieve tweets from");
            var possibleSearchText = Console.ReadLine();
            Console.WriteLine($"{possibleSearchText}, is that correct? press 'Y' if correct, or any other key to try again.");
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.Y)
            {
                return possibleSearchText;
            }
            else
            {
                return GetSearchText(isUsername);
            }
        }
    }
}
