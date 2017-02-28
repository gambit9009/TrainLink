<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminLinks.aspx.cs" Inherits="TrainLinks.AdminLinks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
    <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="true" DataKeyNames="LinkID" DataSourceID="SqlDataSource1">

    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TrainLinkConnectionString %>" DeleteCommand="DELETE FROM [Link] WHERE [LinkID] = @LinkID" InsertCommand="INSERT INTO [Link] ([LinkPageID], [LinkName], [LinkLink], [LinkDisplay], [LinkDescript], [LinkHelpful], [LinkDownload], [LinkTraining], [LinkShort], [LinkCat], [LinkSubCat1], [LinkSubCat2], [LinkSubCat3], [LinkMisc1], [LinkMisc2], [LinkMisc3], [LinkTest], [LinkTestDate]) VALUES (@LinkPageID, @LinkName, @LinkLink, @LinkDisplay, @LinkDescript, @LinkHelpful, @LinkDownload, @LinkTraining, @LinkShort, @LinkCat, @LinkSubCat1, @LinkSubCat2, @LinkSubCat3, @LinkMisc1, @LinkMisc2, @LinkMisc3, @LinkTest, @LinkTestDate)" SelectCommand="SELECT * FROM [Link] ORDER BY [LinkPageID], [LinkID]" UpdateCommand="UPDATE [Link] SET [LinkPageID] = @LinkPageID, [LinkName] = @LinkName, [LinkLink] = @LinkLink, [LinkDisplay] = @LinkDisplay, [LinkDescript] = @LinkDescript, [LinkHelpful] = @LinkHelpful, [LinkDownload] = @LinkDownload, [LinkTraining] = @LinkTraining, [LinkShort] = @LinkShort, [LinkCat] = @LinkCat, [LinkSubCat1] = @LinkSubCat1, [LinkSubCat2] = @LinkSubCat2, [LinkSubCat3] = @LinkSubCat3, [LinkMisc1] = @LinkMisc1, [LinkMisc2] = @LinkMisc2, [LinkMisc3] = @LinkMisc3, [LinkTest] = @LinkTest, [LinkTestDate] = @LinkTestDate WHERE [LinkID] = @LinkID">
        <DeleteParameters>
            <asp:Parameter Name="LinkID" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="LinkPageID" Type="Int32" />
            <asp:Parameter Name="LinkName" Type="String" />
            <asp:Parameter Name="LinkLink" Type="String" />
            <asp:Parameter Name="LinkDisplay" Type="String" />
            <asp:Parameter Name="LinkDescript" Type="String" />
            <asp:Parameter Name="LinkHelpful" Type="String" />
            <asp:Parameter Name="LinkDownload" Type="String" />
            <asp:Parameter Name="LinkTraining" Type="String" />
            <asp:Parameter Name="LinkShort" Type="String" />
            <asp:Parameter Name="LinkCat" Type="String" />
            <asp:Parameter Name="LinkSubCat1" Type="String" />
            <asp:Parameter Name="LinkSubCat2" Type="String" />
            <asp:Parameter Name="LinkSubCat3" Type="String" />
            <asp:Parameter Name="LinkMisc1" Type="String" />
            <asp:Parameter Name="LinkMisc2" Type="String" />
            <asp:Parameter Name="LinkMisc3" Type="String" />
            <asp:Parameter Name="LinkTest" Type="Boolean" />
            <asp:Parameter Name="LinkTestDate" Type="DateTime" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="LinkPageID" Type="Int32" />
            <asp:Parameter Name="LinkName" Type="String" />
            <asp:Parameter Name="LinkLink" Type="String" />
            <asp:Parameter Name="LinkDisplay" Type="String" />
            <asp:Parameter Name="LinkDescript" Type="String" />
            <asp:Parameter Name="LinkHelpful" Type="String" />
            <asp:Parameter Name="LinkDownload" Type="String" />
            <asp:Parameter Name="LinkTraining" Type="String" />
            <asp:Parameter Name="LinkShort" Type="String" />
            <asp:Parameter Name="LinkCat" Type="String" />
            <asp:Parameter Name="LinkSubCat1" Type="String" />
            <asp:Parameter Name="LinkSubCat2" Type="String" />
            <asp:Parameter Name="LinkSubCat3" Type="String" />
            <asp:Parameter Name="LinkMisc1" Type="String" />
            <asp:Parameter Name="LinkMisc2" Type="String" />
            <asp:Parameter Name="LinkMisc3" Type="String" />
            <asp:Parameter Name="LinkTest" Type="Boolean" />
            <asp:Parameter Name="LinkTestDate" Type="DateTime" />
            <asp:Parameter Name="LinkID" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
        </form>
</asp:Content>
