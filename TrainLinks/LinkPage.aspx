﻿<%@ Page Title="Links Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LinkPage.aspx.cs" Inherits="TrainLinks.LinkPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <form id="form1" runat="server">
        <table style="border-style: 0; border-width: 0px; background-color: #FFFFFF; padding: 0px; margin: 0px; vertical-align: top; width: 98%;" border="0" class="Todd"><tr>
            <td style="padding: 0px; margin: 0px; font-size: x-large; background-color: #FFFFFF;" >&nbsp;&nbsp;<asp:Label ID="lblPageTitle" runat="server" Text="LinkPage" Font-Bold="True" Font-Size="X-Large">Link Page</asp:Label></td>
            <td style="padding: 0px; margin: 0px; font-size: small; background-color: #FFFFFF; text-align: left;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
            </tr>
            </table>
            <asp:Panel ID="Panel1" runat="server" Font-Size="medium" Width="98%"></asp:Panel>
        </form>
    <br />
</asp:Content>
