<%@ Page Title="Home Page" Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="false"
    CodeBehind="Default.aspx.vb" Inherits="Prelude.WebFormsSample.Web._Default" %>

<%@ MasterType VirtualPath="~/Site.Master" %>
<%@ Register Src="Controls/AddressControl.ascx" TagName="AddressControl" TagPrefix="uc1" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Welcome to ASP.NET!
    </h2>
    <p>
        Orig:<br />
        <asp:Label ID="lblAddress" Text="" runat="server" />
    </p>
    <p>
        New:<br />
        <asp:Label ID="lblAddress2" Text="" runat="server" />
    </p>
    <p>
        Control:<br />
        <uc1:AddressControl ID="AddressControl1" runat="server" />
    </p>
    <p>
        To learn more about ASP.NET visit <a href="http://www.asp.net" title="ASP.NET Website">
            www.asp.net</a>.
    </p>
    <p>
        You can also find <a href="http://go.microsoft.com/fwlink/?LinkID=152368&amp;clcid=0x409"
            title="MSDN ASP.NET Docs">documentation on ASP.NET at MSDN</a>.
    </p>
</asp:Content>
