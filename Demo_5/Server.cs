using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenTokSDK;

namespace Demo_5
{
    public class Server
    {
        private string session_id()
        {
            string str_session = string.Empty;

            int ApiKey = 000000; // YOUR API KEY
            string ApiSecret = "YOUR API SECRET";
            var OpenTok = new OpenTok(ApiKey, ApiSecret);

            // Create an automatically archived session:
            var session = OpenTok.CreateSession(mediaMode: MediaMode.ROUTED);
            // Store this sessionId in the database for later use:
            string sessionId = session.Id;
            return str_session;
        }
    }
}