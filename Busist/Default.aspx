<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Busist._Default" %>
<asp:Content runat="server" ID="DefaultHead" ContentPlaceHolderID="HeadContent">
   
</asp:Content>
<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    
    <h3>We suggest the following:</h3>
    <br />
    <div class="right col-md-2">
        <label>Your Picking Stop:</label>
    <asp:DropDownList class="form-control" ID="Customer_Locations" runat="server"></asp:DropDownList><br />
    <label>Your Destination:</label>
    <asp:DropDownList CssClass="form-control" ID="Destinations" runat="server">
    </asp:DropDownList>
        <button class="btn-default" runat="server" ID="Go" value="Find me A Bus">Find Me A Bus</button>
    </div>    
    <br />
    <div id="map-canvas"  ></div>
</asp:Content>
