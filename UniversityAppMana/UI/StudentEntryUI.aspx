<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentEntryUI.aspx.cs" Inherits="UniversityAppMana.UI.StudentEntryUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Student Entry</h1>
            <table>
                <tr>
                    <td>Name</td>
                    <td><asp:TextBox ID="nameTextBox" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Email</td>
                    <td><asp:TextBox ID="emailTextBox" runat="server"></asp:TextBox></td>
                </tr>
            
                <tr>
                    <td>RegNo</td>
                    <td><asp:TextBox ID="regNoTextBox" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Address</td>
                    <td><asp:TextBox ID="addressTextBox" runat="server" TextMode="MultiLine"></asp:TextBox></td>
                </tr>
                  <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="SaveButton" runat="server" Text="Save" OnClick="SaveButton_Click" />
                        <asp:Button ID="ShowButton" runat="server" Text="Show" OnClick="ShowButton_Click"/>
                    </td>
                </tr>
            </table>
            <h4>Student List</h4>
            <asp:GridView runat="server" ID="studentGridView"></asp:GridView>
        </div>
        
      
    </form>
</body>
</html>
