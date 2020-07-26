<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Client.aspx.cs" Inherits="Demo_5.Client" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title> OpenTok Getting Started </title>
    <script src="https://static.opentok.com/v2/js/opentok.min.js"></script>
   <%-- <link href="css/app.css" rel="stylesheet" type="text/css"/>--%>
     <script type="text/javascript" src="js/config.js"></script>
    <script type="text/javascript" src="js/app.js"></script>
     <style>
         body, html {
    background-color: gray;
    height: 100%;
}
#videos {
    position: relative;
    width: 100%;
    height: 100%;
    margin-left: auto;
    margin-right: auto;
}
#subscriber {
    position: absolute;
    left: 0;
    top: 0;
    width: 100%;
    height: 100%;
    z-index: 10;
}
#publisher {
    position: absolute;
    width: 360px;
    height: 240px;
    bottom: 10px;
    left: 10px;
    z-index: 100;
    border: 3px solid white;
    border-radius: 3px;
}


        /*.github-corner:hover .octo-arm {
            animation: octocat-wave 560ms ease-in-out;
        }

        @keyframes octocat-wave {
            0%,100% {
                transform: rotate(0);
            }

            20%,60% {
                transform: rotate(-25deg);
            }

            40%,80% {
                transform: rotate(10deg);
            }
        }

        @media (max-width:500px) {
            .github-corner:hover .octo-arm {
                animation: none;
            }

            .github-corner .octo-arm {
                animation: octocat-wave 560ms ease-in-out;
            }
        }*/
    </style>

    
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <div id="videos">
        <div id="subscriber"></div>
        <div id="publisher"></div>
    </div>
    </div>

        

   
    </form>
</body>
</html>
