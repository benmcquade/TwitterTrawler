using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using TwitterTrawler.Models;
using TwitterTrawler.Services;

namespace TwitterTrawler.Repository
{
    public class TwitterRepository
    {
        /// <summary>
        /// Attempts to hit the given URI and returns a tweet (couldnt get this call to work, was working in postman and ran out of time while trying to investigate)
        /// </summary>
        /// <param name="uri">a provided URI that the http client will use to perform a get operation</param>
        /// <param name="count">the number of tweets to respond with (search through twitter API documentation and couldnt find how to implement this)</param>
        /// <returns>a list of tweets that meet the query criteria</returns>
        public async Task<List<Tweet>> GetTweetsByUri(string uri, int count)
        {
            using (var client = new HttpClient())
            {
                string bearer = ConfigurationManager.AppSettings["BearerToken"];
                string auth = $"Bearer {bearer}";

                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", auth);
                client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "SynergiTweetTrawler");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "*/*");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Encoding", "gzip, deflate, br");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Connection", "keep-alive");

                try
                {
                    var response = await client.GetAsync(uri);
                    var responseContent = await response.Content.ReadAsStringAsync();

                    JavaScriptSerializer ser = new JavaScriptSerializer();
                    TweetData TwitterResponse = ser.Deserialize<TweetData>(responseContent);

                    return TwitterResponse.tweets;
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    Console.ReadLine();
                    throw;
                }
            }
        }
    }
}
