<%@ Page Title="Helpful Links" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TrainLinks._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <form id="form1" runat="server">
        <table style="border-style: 0; border-width: 0px; background-color: #FFFFFF; padding: 0px; margin: 0px; vertical-align: top; width: 90%;" border="0" class="Todd"><tr>
            <td style="padding: 0px; margin: 0px; font-size: x-large; background-color: #FFFFFF;">&nbsp;&nbsp;<b>Lord of the Links&nbsp;</b></td>
            <td style="padding: 0px; margin: 0px; font-size: small; background-color: #FFFFFF; text-align: left;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;One Link to rule them all, One Link to find them, One Link to bring them all and in the darkness bind them&nbsp;&nbsp;&nbsp;&nbsp;</td></tr>
            <tr style="border-width: 0px; border-color: #FFFFFF"><td style="border-width: 0px; border-color: #FFFFFF; padding: 0px; margin: 0px; font-size: small; background-color: #FFFFFF;" colspan="2">**** The current view for this web page is just the raw data...so for now is it really wide.  Use web browse Find to do a search or click headers to sort.</td></tr>
        </table>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="LinkID" DataSourceID="SqlDataSourceLinkGrid" AllowSorting="True" CellPadding="0" CellSpacing="0" BorderStyle="Solid" Font-Size="Medium" Font-Names="Calibri" CssClass="Todd">
        <Columns>
            <asp:BoundField DataField="LinkPageID" HeaderText="PageID" SortExpression="LinkPageID" HtmlEncode="False" ItemStyle-Wrap="False"  >
            </asp:BoundField>
            <asp:BoundField DataField="LinkName" HeaderText="Name" SortExpression="LinkName" ItemStyle-Wrap="False" >
                <ItemStyle Wrap="False" Font-Bold="True"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="LinkLink" HeaderText="Link" SortExpression="LinkLink" HtmlEncode="false" ItemStyle-Wrap="False" >
            </asp:BoundField>
            <asp:BoundField DataField="LinkDescript" HeaderText="Description" SortExpression="LinkDescript" HtmlEncode="false" ItemStyle-Wrap="False" >
            </asp:BoundField>
            <asp:BoundField DataField="LinkShort" HeaderText="Short Link" SortExpression="LinkShort" HtmlEncode="False" ItemStyle-Wrap="False" >
            </asp:BoundField>
            <asp:BoundField DataField="LinkHelpful" HeaderText="Helpful Info" SortExpression="LinkHelpful" ItemStyle-Wrap="False" >
            </asp:BoundField>
            <asp:BoundField DataField="LinkTraining" HeaderText="Training Link" SortExpression="LinkTraining" HtmlEncode="False" ItemStyle-Wrap="False" >
            </asp:BoundField>
            <asp:BoundField DataField="LinkDownload" HeaderText="Download Link" SortExpression="LinkDownload" HtmlEncode="False" ItemStyle-Wrap="False" >
            </asp:BoundField>
            <asp:BoundField DataField="LinkCat" HeaderText="Category" SortExpression="LinkCat" ItemStyle-Wrap="False" >
            </asp:BoundField>
            <asp:BoundField DataField="LinkSubCat1" HeaderText="SubCat1" SortExpression="LinkSubCat1" ItemStyle-Wrap="False" >
            </asp:BoundField>
            <asp:BoundField DataField="LinkSubCat2" HeaderText="SubCat2" SortExpression="LinkSubCat2" ItemStyle-Wrap="False" >
            </asp:BoundField>
            <asp:BoundField DataField="LinkSubCat3" HeaderText="SubCat3" SortExpression="LinkSubCat3" ItemStyle-Wrap="False" >
            </asp:BoundField>
            <asp:BoundField DataField="LinkMisc1" HeaderText="Misc1" SortExpression="LinkMisc1" ItemStyle-Wrap="False" >
            </asp:BoundField>
            <asp:BoundField DataField="LinkMisc2" HeaderText="Misc2" SortExpression="LinkMisc2" ItemStyle-Wrap="False" >
            </asp:BoundField>
            <asp:BoundField DataField="LinkMisc3" HeaderText="Misc3" SortExpression="LinkMisc3" ItemStyle-Wrap="False" >
            </asp:BoundField>
            <asp:BoundField DataField="LinkDisplay" HeaderText="Display" SortExpression="LinkDisplay" ItemStyle-Wrap="False" >
            </asp:BoundField>
            <asp:BoundField DataField="LinkID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="LinkID" ItemStyle-Wrap="False" >
            </asp:BoundField>
            
        </Columns>
        <HeaderStyle BackColor="#E6B800" ForeColor="Black" Font-Bold="False" Font-Underline="True" Font-Size="Large" />
            <RowStyle ForeColor="Black" Font-Size="12" />
    </asp:GridView>

    <asp:SqlDataSource ID="SqlDataSourceLinkGrid" runat="server" ConnectionString="<%$ ConnectionStrings:TrainLinkConnectionString %>" SelectCommand="GetAllLinks" OnSelecting="SqlDataSourceLinkGrid_Selecting" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

</form>

</asp:Content>
