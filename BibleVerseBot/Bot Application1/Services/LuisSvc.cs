using System;
using System.Collections.Generic;
using System.Net;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Bot_Application1.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace Bot_Application1.Services
{
    public class LuisSvc
    {
        public static async Task<BibleLuis> GetUserIntent(string input)
        {
            using (var client = new HttpClient()) 
	        {
                input = WebUtility.UrlEncode(input);
                string uri = $"https://westus.api.cognitive.microsoft.com/luis/v2.0/apps/6bbd3529-e4fa-4368-90be-48e21f53d491?subscription-key=3521f51941544cdc80f6a3ba75662bc8&q={input}&verbose=true";
                HttpResponseMessage message = await client.GetAsync(uri);

                if (message.IsSuccessStatusCode)
                {
                    var jsonMessage = await message.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<BibleLuis>(jsonMessage);
                    if (data.entities.Length !=3)
                    {
                        return null;
                    }
                    else return data;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}