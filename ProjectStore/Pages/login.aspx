<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/default.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="ProjectStore.Pages.login" %>

<%@ Register Src="~/UC/uc_login.ascx" TagPrefix="uc1" TagName="uc_login" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:uc_login runat="server" id="uc_login" />
</asp:Content>
