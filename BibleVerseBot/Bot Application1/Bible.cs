using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace Bot_Application1
{
    public class Bible
    {
        public async Task<string> GetPassage(string book, string chapter, string verse)
        {
            string url = $"http://bible-api.com/{book}{chapter}:{verse}";
            string result;

            using (WebClient client = new WebClient())
            {
                try
                {
                    result = await client.DownloadStringTaskAsync(url).ConfigureAwait(false);
                    return result;
                } catch
                {
                    return null;
                }
            }
        }
    }
}