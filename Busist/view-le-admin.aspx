<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="view-le-admin.aspx.cs" Inherits="Busist.view_le_admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <h3>Admin View:</h3>
    <br />
      <asp:DropDownList class="form-control" ID="Customer_Locations" Visible="false" runat="server"></asp:DropDownList><br />
    
    <asp:DropDownList CssClass="form-control" ID="Destinations" Visible="false" runat="server">
    </asp:DropDownList>
    <div id="map-canvas"  ></div>
</asp:Content>
