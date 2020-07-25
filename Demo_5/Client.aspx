<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Client.aspx.cs" Inherits="Demo_5.Client" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> OpenTok Getting Started </title>
    <link href="css/app.css" rel="stylesheet" type="text/css"/>

    <script src="https://static.opentok.com/v2/js/opentok.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <div id="videos">
        <div id="subscriber"></div>
        <div id="publisher"></div>
    </div>
    </div>

    <script type="text/javascript" src="js/config.js"></script>
    <script type="text/javascript" src="js/app.js"></script>
    </form>
</body>
</html>
