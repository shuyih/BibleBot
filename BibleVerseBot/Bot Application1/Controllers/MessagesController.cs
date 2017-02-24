using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Bot.Connector;
using Newtonsoft.Json;
using System.Web;
using Bot_Application1.Models;
using Bot_Application1.Services;

namespace Bot_Application1
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));
            Activity reply = null; 
            if (activity.Type == ActivityTypes.Message)
            {
                
                // calculate something for us to return                
                string request = activity.Text;
                string errorMsg = "Verse not found, please try again. \r\n E.g., Please find John 3:16, \r\nJohn 3:16, \r\nLook up John 3:16, \r\nfind me 3:16, \r\ngive me John chapter 12, verse 12, etc"; 
                string book = null, chapter = null, ver = null;
                var resp = await GetUserIntent(request); 
 
                // return response to user
                if (resp != null)
                {
                    book = resp.entities[0].entity;
                    chapter = resp.entities[1].entity;
                    ver = resp.entities[2].entity;

                    string passage = await GetBiblePassage(book, chapter, ver);

                    if (passage != null)
                    {
                        VerseModel verse = JsonConvert.DeserializeObject<VerseModel>(passage);
                        string message = string.Format("{0} {1}:{2} \r\n {3}", book.ToUpper(), chapter, ver, verse.text);
                        await connector.Conversations.ReplyToActivityAsync(activity.CreateReply(message));
                    }
                    else
                    {
                        await connector.Conversations.ReplyToActivityAsync(activity.CreateReply(errorMsg));
                    }
                }
                else
                {
                    await connector.Conversations.ReplyToActivityAsync(activity.CreateReply(errorMsg));
                }
            }
            else
            {
                reply = HandleSystemMessage(activity);
                await connector.Conversations.ReplyToActivityAsync(reply);

            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        private async Task<BibleLuis> GetUserIntent(string input)
        {
            BibleLuis result = await LuisSvc.GetUserIntent(input);

            return result;

        }

        private async Task<string> GetBiblePassage(string book, string chapter, string verse)
        {
            Bible bible = new Bible();
            string result = await bible.GetPassage(book, chapter, verse);
            return result; 
        }

        private Activity HandleSystemMessage(Activity message)
        {
            if (message.Type == ActivityTypes.DeleteUserData)
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == ActivityTypes.ConversationUpdate)
            {
                // Handle conversation state changes, like members being added and removed
                // Use Activity.MembersAdded and Activity.MembersRemoved and Activity.Action for info
                // Not available in all channels
            }
            else if (message.Type == ActivityTypes.ContactRelationUpdate)
            {
                // Handle add/remove from contact lists
                // Activity.From + Activity.Action represent what happened
                return message.CreateReply("hello, I am bot.");
            }
            else if (message.Type == ActivityTypes.Typing)
            {
                // Handle knowing tha the user is typing
            }
            else if (message.Type == ActivityTypes.Ping)
            {
            }

            return null;
            
        }
    }
}