<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UseJsonParserMultipla.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p> {"id":"1","name":"Jack","age":"36"} </p>
            <asp:Button ID="btn_convert_1" runat="server" Text="Convert" OnClick="btn_convert_1_Click" />
        </div>
    </form>
</body>
</html>
