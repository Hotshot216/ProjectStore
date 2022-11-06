<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/default.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="ProjectStore.Pages.register" %>

<%@ Register Src="~/UC/uc_register.ascx" TagPrefix="uc1" TagName="uc_register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:uc_register runat="server" ID="uc_register" />
</asp:Content>
