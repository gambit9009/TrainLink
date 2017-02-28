<%@ Page Title="Search" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TrainLinks.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <form id="form1" runat="server">
            <table style="border-style: 0; border-width: 0px; background-color: #FFFFFF; padding: 0px; margin: 0px; vertical-align: top;" border="0" class="Todd">
            <tr>
            <td style="padding: 0px; margin: 0px; background-color: #FFFFFF; width: 100px;" >&nbsp;&nbsp;<asp:Label ID="lblPageTitle" runat="server" Text="LinkPage" Font-Bold="True" Font-Size="X-Large">Search</asp:Label></td>
            <td style="text-align: center; width: 10px;">&nbsp;</td>
            <td style="text-align: center; width: 256px;"><asp:TextBox ID="txtBoxSearch" runat="server" class="Todd" style="width:250px; font-size: medium; background-color: #FFFFCC"></asp:TextBox></td>
            <td style="text-align: left; padding: 0px; margin: 0px; background-color: #FFFFFF; vertical-align: middle;"><asp:ImageButton ID="imgSearch" runat="server" ImageUrl="~/images/search.png" OnClick="ImageButton1_Click" ImageAlign="Middle" OnClientClick="ImageButton1_Click" /></td>
            </tr>
            <tr>
            <td style="padding: 0px; margin: 0px; font-size: small; background-color: #FFFFFF; text-align: left;" colspan="4">&nbsp;&nbsp;*** Single word or phrase searches (I'm not parsing the text for spaces or AND, etc</td>
            </tr>
            </table>
            <br /><br />
            <asp:Panel ID="Panel1" runat="server" Font-Size="medium" Width="98%">

            </asp:Panel>
            <br />
        </form>
</asp:Content>



