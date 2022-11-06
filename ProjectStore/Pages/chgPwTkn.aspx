<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/default.Master" AutoEventWireup="true" CodeBehind="chgPwTkn.aspx.cs" Inherits="ProjectStore.Pages.forgotPass.chgPwTkn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <br />
            <asp:Panel ID="pnl_token" runat="server">
                <div class="container text-center">                    
                        <div class="row">
                            <div class="col"></div>
                            <div class="form-group col-4">
                                <h5><label>Insert the token we sent you</label></h5>
                                <asp:TextBox ID="tb_token" CssClass="form-control" placeholder="Token" runat="server"></asp:TextBox>
                                <asp:Label ID="lbl_tknMsg" runat="server" ForeColor="red" Text="Incorrect token" Visible="false"></asp:Label><br />
                            </div>
                            <div class="col"></div>
                        </div>
                    
                    <div class="form-group">
                        
                        <asp:Button ID="btn_token" CssClass="btn btn-dark" runat="server" Text="Confirm" OnClick="btn_token_Click" />
                    </div>
                </div>
            </asp:Panel>

            <asp:Panel ID="pnl_pass" Visible="false" runat="server">
                <div class="container text-center">                    
                        <div class="row">
                            <div class="col"></div>
                            <div class="form-group col-4">
                                <h5><label>Choose a new password</label></h5>
                                <asp:TextBox ID="tb_pass" CssClass="form-control" TextMode="Password" placeholder="Password" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" runat="server" Text="Password is required" ControlToValidate="tb_pass" ValidationGroup="newPass"></asp:RequiredFieldValidator>
                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="tb_pass" ForeColor="Red" ValidationExpression="^(?=.*[A-Z])(?=.*[!#$%&amp;@_&quot;.,£€])(?=.*[0-9])(?=.*[a-z].*[a-z].*[a-z])(?!.*[']).{8,}$" ValidationGroup="newPass">*Weak password</asp:RegularExpressionValidator>
                            </div>
                            <div class="col"></div>
                        </div>
                     <div class="row">
                            <div class="col"></div>
                            <div class="form-group col-4">
                                <h5><label>Confirm your password</label></h5>
                                <asp:TextBox ID="tb_confPass" CssClass="form-control" TextMode="Password" placeholder="Confirm password" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ForeColor="Red" runat="server" Text="This field is required" ControlToValidate="tb_confPass" ValidationGroup="newPass"></asp:RequiredFieldValidator>
                                <br /><asp:CompareValidator ID="CompareValidator2" ForeColor="Red" ValidationGroup="newPass" runat="server" Text="Passwords aren't identical" ControlToCompare="tb_pass" ControlToValidate="tb_confPass"></asp:CompareValidator>    
                            </div>
                            <div class="col"></div>
                        </div>
                    <div class="form-group">                        
                        <asp:Button ID="btn_newPass" ValidationGroup="newPass" CssClass="btn btn-dark" runat="server" Text="Confirm" OnClick="btn_newPass_Click" />
                    </div>
                </div>
            </asp:Panel>
            <asp:Panel ID="pnl_warning" Visible="false" runat="server">
                <div class="alert alert-success" role="alert">
                       <h5 class="alert-heading">Password changed!</h5>                       
                       <hr />
                       <p>You can now login with the new password.</p>
                        <hr />
                        <p  class="mb-0">If this page does not refresh in 5 seconds, press the login button.</p>
                    </div>
            </asp:Panel>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
