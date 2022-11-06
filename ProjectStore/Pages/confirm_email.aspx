<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/default.Master" AutoEventWireup="true" CodeBehind="confirm_email.aspx.cs" Inherits="ProjectStore.Pages.confirm_email" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <div class="alert alert-success" role="alert">
        <h4 class="alert-heading">Thanks for joining us!</h4>
        <p>
        To complete your registration you just need to confirm your account.<br />
        To do this simply click on the link we sent to your email address.<br />
        </p>
        <hr>
        <p class="mb-0"> You can refresh this page after confirming your account.</p>
    </div>

</asp:Content>
