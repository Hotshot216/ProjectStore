<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_login.ascx.cs" Inherits="ProjectStore.UC.login" %>
<h2>Login</h2>
<br />
<form>
    <div class="form-group">
        <h5><label>Email</label></h5>
        <asp:TextBox ID="tb_username" runat="server" CssClass="form-control" placeholder="Enter email"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="login" ControlToValidate="tb_username">*Email is required</asp:RequiredFieldValidator>        
    </div>
    <div class="form-group">
        <h5><label>Password</label></h5>
        <asp:TextBox ID="tb_password" runat="server" TextMode="Password" CssClass="form-control" placeholder="Enter password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="login" ControlToValidate="tb_password">*Password required</asp:RequiredFieldValidator>
        <br />
        <small class="text-secondary">Forgot your password? Restore it <a href="forgot_pass.aspx">here</a>!</small>
    </div> 
    
    <asp:Label ID="lbl_message" runat="server" ForeColor="Red" Visible="False"></asp:Label>
    
    <asp:Label ID="lbl_register" runat="server">Still don´t have an account? You can register <a href="register.aspx">here</a>!</asp:Label>
    <br />
    <br />
    <asp:Button ID="btn_login" runat="server" Text="Login" ValidationGroup="login"  CssClass="btn btn-dark" OnClick="btn_login_Click" />
    
</form>
