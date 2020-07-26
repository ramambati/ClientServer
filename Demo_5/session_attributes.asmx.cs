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
    /// Summary description for session_attributes
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class session_attributes : System.Web.Services.WebService
    {

        [WebMethod]
        public int Add(int a, int b)
        {
            return (a + b);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetSession_id1()
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
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = Int32.MaxValue;
            Context.Response.Write(js.Serialize(attributes));


        }
        [WebMethod]
        public string GetSession_id()

        {
            string str_session = string.Empty;

            int ApiKey = 46850414; // YOUR API KEY
            string ApiSecret = "9c00391936455ff1b66a56637241f6b4401e0897";
            var OpenTok = new OpenTok(ApiKey, ApiSecret);

            // Create an automatically archived session:
            var session = OpenTok.CreateSession(mediaMode: MediaMode.ROUTED);
            // Store this sessionId in the database for later use:
            string sessionId = session.Id;
            sessionId = "2_MX40Njg1MDQxNH5-MTU5NTc3NDc4MTQzMX5Tb2hZMlZ6YXlCd3BOeCsyQnczcDJwU3Z-fg";
            // Generate a token by calling the method on the Session (returned from CreateSession)
            //string token = session.GenerateToken();

            // Generate a token from a sessionId (fetched from database)
            string token = OpenTok.GenerateToken(sessionId);

            string str_concat = ApiKey + "~!@" + sessionId + "~!@" + token;
            return str_concat;
        }

        public class Server_attributes
        {
            public string apiKey { get; set; }
            public string sessionId { get; set; }
            public string token { get; set; }
        }
    }
}
