using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using System.Web.Script.Serialization;
using OpenTokSDK;
namespace Demo_5
{
    /// <summary>
    /// Summary description for Service
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class Service : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string GetSession_id()
        {
            string str_session = string.Empty;

            int ApiKey = 46850414; // YOUR API KEY
            string ApiSecret = "9c00391936455ff1b66a56637241f6b4401e0897";
            var OpenTok = new OpenTok(ApiKey, ApiSecret);

            // Create an automatically archived session:
            var session = OpenTok.CreateSession(mediaMode: MediaMode.ROUTED);
            // Store this sessionId in the database for later use:
            string sessionId = session.Id;

            // Generate a token by calling the method on the Session (returned from CreateSession)
            string token = session.GenerateToken();

            var attributes = new List<Server_attributes>();
            var cust = new Server_attributes
            {
                apiKey = ApiKey.ToString(),
                sessionId = sessionId,
                token = token
            };
            attributes.Add(cust);
            string myJsonString = (new JavaScriptSerializer()).Serialize(attributes);
            return myJsonString;


        }


        public class Server_attributes
        {
            public string apiKey { get; set; }
            public string sessionId { get; set; }
            public string token { get; set; }
        }
    }
}
