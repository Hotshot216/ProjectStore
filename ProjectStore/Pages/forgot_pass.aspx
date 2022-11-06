<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/default.Master" AutoEventWireup="true" CodeBehind="forgot_pass.aspx.cs" Inherits="ProjectStore.Pages.forgot_pass" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Panel ID="pnl_before" runat="server">
                    <div class="container">
                        <h2 class="text-center">Forgot your password?</h2>
                        <br />
        
                        <div class="form-group">
                            <h5 ><label>Insert the email you registered with.</label></h5>
                            <asp:TextBox ID="tb_email" CssClass="form-control" runat="server" placeholder="Email"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Label CssClass="text-secondary" ID="lbl_msg" runat="server" Text="If the email you inserted is registered you'll receive a token in it to change your password."></asp:Label>
                        </div>
                        <div class="form-group">
                            <asp:Button ID="btn_send" CssClass="btn btn-dark" runat="server" Text="Send Email" OnClick="btn_send_Click" />
                            <br />
                            <asp:Label ID="lbl_error" runat="server" Visible="false" CssClass="text-danger" Text="It seems that email is not registered."></asp:Label>
                        </div>        
                    </div>
                </asp:Panel>
                <%----%>
                <asp:Panel ID="pnl_after" Visible="false" runat="server">
                    <div class="alert alert-warning" role="alert">
                       <h5 class="alert-heading">Token sent!</h5>                       
                       <hr />
                       <p>Check your email and click the embeded link.</p>
                        <hr />
                        <p  class="mb-0">You can close this page</p>
                    </div>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    
</asp:Content>
