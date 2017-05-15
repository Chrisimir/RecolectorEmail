using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RecolectorEmail
{
    public class Mail
    {
        // If modifying these scopes, delete your previously saved credentials
        // at ~/.credentials/gmail-dotnet-quickstart.json
        static string[] Scopes = { GmailService.Scope.GmailReadonly };
        static string ApplicationName = "RecolectorEmail";

        public SortedList<string, string> GetMails(DateTime lastUpdate)
        {
            UserCredential credential;
            SortedList<string, string> mails = new SortedList<string, string>();

            using (var stream =
                new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = System.Environment.GetFolderPath(
                    System.Environment.SpecialFolder.Personal);
                // TODO: Change this path
                credPath = Path.Combine(credPath, ".credentials/gmail-dotnet-quickstart.json");

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }

            // Create Gmail API service.
            var service = new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            // Takes messages that are after the date in parameter
            List<Message> messages = ListMessages(service, "me", "after:" + lastUpdate.ToString("yyyy/MM/dd"));
            foreach (var messageItem in messages)
            {
                String from = "";
                String body = "";

                var messageContent =
                    service.Users.Messages.Get("me", messageItem.Id).Execute();
                foreach (var mParts in messageContent.Payload.Headers)
                {
                    if (mParts.Name == "From")
                    {
                        if (mParts.Value.Contains('<'))
                        {
                            from = mParts.Value.Split('<', '>')[1];
                        }
                        else
                            from = mParts.Value;
                    }
                    else if (from != "")
                    {
                        if (messageContent.Payload.Parts == null && messageContent.Payload.Body != null)
                        {
                            body = messageContent.Payload.Body.Data;
                        }
                        else
                        {
                            body = getNestedParts(messageContent.Payload.Parts, "");
                        }

                        //need to replace some characters as the data for the email's body is base64
                        body = body.Replace('-', '+');
                        body = body.Replace('_', '/');
                        byte[] data = Convert.FromBase64String(body);
                        body = Encoding.UTF8.GetString(data);

                        // Saves to the mail list
                        if (!mails.ContainsKey(from.ToLower()))
                        {
                            mails.Add(from.ToLower(), body);
                        }
                    }
                }
            }

            return mails;
        }

        public static List<Message> ListMessages(GmailService service, String userId, String query)
        {
            List<Message> result = new List<Message>();
            UsersResource.MessagesResource.ListRequest request = service.Users.Messages.List(userId);
            request.Q = query;

            do
            {
                try
                {
                    ListMessagesResponse response = request.Execute();
                    result.AddRange(response.Messages);
                    request.PageToken = response.NextPageToken;
                }
                catch (Exception e)
                {
                    Console.WriteLine("An error occurred: " + e.Message);
                }
            } while (!String.IsNullOrEmpty(request.PageToken));
            return result;
        }

        static String getNestedParts(IList<MessagePart> part, string curr)
        {
            string str = curr;
            if (part == null)
            {
                return str;
            }
            else
            {
                foreach (var parts in part)
                {
                    if (parts.Parts == null)
                    {
                        // Only returning the first part
                        if (parts.Body != null && parts.Body.Data != null)
                        {
                            return str += parts.Body.Data;
                        }
                    }
                    else
                    {
                        return getNestedParts(parts.Parts, str);
                    }
                }

                return str;
            }

        }
    }
}