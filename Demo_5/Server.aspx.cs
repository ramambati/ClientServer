using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Services;
using System.Web.Script.Serialization;
using OpenTokSDK;

namespace Demo_5
{
    public partial class Server1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
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
            sessionId = "2_MX40Njg1MDQxNH5-MTU5NTc3NDc4MTQzMX5Tb2hZMlZ6YXlCd3BOeCsyQnczcDJwU3Z-fg";
            // Generate a token by calling the method on the Session (returned from CreateSession)
            //string token = session.GenerateToken();

            // Generate a token from a sessionId (fetched from database)
            string token = OpenTok.GenerateToken(sessionId);

            string str_concat = ApiKey + "~!@" + sessionId + "~!@" + token;
            return str_concat;
        }

        [WebMethod]
        public int Add(int a, int b)
        {
            return (a + b);
        }
    }
}