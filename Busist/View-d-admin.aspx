<%@ Page Title="Admin Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="View-d-admin.aspx.cs" Inherits="Busist._Default" %>
<asp:Content runat="server" ID="DefaultHead" ContentPlaceHolderID="HeadContent">
   
</asp:Content>
<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    
    <h3>Admin View:</h3>
    <br />
      <asp:DropDownList class="form-control" ID="Customer_Locations" Visible="false" runat="server"></asp:DropDownList><br />
    
    <asp:DropDownList CssClass="form-control" ID="Destinations" Visible="false" runat="server">
    </asp:DropDownList>
    <div id="map-canvas"  ></div>
</asp:Content>
