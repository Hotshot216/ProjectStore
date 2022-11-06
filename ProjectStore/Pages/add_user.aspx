<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/default.Master" AutoEventWireup="true" CodeBehind="add_user.aspx.cs" Inherits="ProjectStore.Pages.add_user" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnl_addUser" runat="server">
                <form>
                    <div class="form-group">
                        <h5><label>Email address</label></h5>
                        <asp:TextBox ID="tb_email" runat="server" CssClass="form-control" placeholder="Enter email"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" Text="*Email is required" ControlToValidate="tb_email" ValidationGroup="register"></asp:RequiredFieldValidator>        
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Text="*Invalid email" ForeColor="Red" ControlToValidate="tb_email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="register">*Invalid email</asp:RegularExpressionValidator>
                        <small id="emailHelp" class="form-text text-muted">We'll never share your email with anyone else.</small>
                    </div>                    
                    <div class="form-group">
                        <h5><label>Fill the name</label></h5>
                        <div class="form-row">
                            <div class="col">         
                                <asp:TextBox ID="tb_firstName" runat="server" CssClass="form-control" placeholder="First name"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ForeColor="Red" runat="server" Text="First name required" ControlToValidate="tb_firstName" ValidationGroup="register"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col"> 
                                <asp:TextBox ID="tb_lastName" runat="server" CssClass="form-control" placeholder="Last name"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ForeColor="Red" runat="server" Text="Last name is required" ControlToValidate="tb_lastName" ValidationGroup="register"></asp:RequiredFieldValidator>
                            </div>      
                        </div>
                    </div>
                    <div class="form-group">
                        <h5><label>Set a temporary password</label></h5>
                        <asp:TextBox ID="tb_password" runat="server" CssClass="form-control" TextMode="Password" placeholder="Enter your password"></asp:TextBox>
                        <div class="row">
                            <div class="col">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ForeColor="Red" runat="server" Text="Password is required" ControlToValidate="tb_password" ValidationGroup="register"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col">
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="tb_password" ForeColor="Red" ValidationExpression="^(?=.*[A-Z])(?=.*[!#$%&amp;@_&quot;.,£€])(?=.*[0-9])(?=.*[a-z].*[a-z].*[a-z])(?!.*[']).{8,}$" ValidationGroup="Register">*Weak password</asp:RegularExpressionValidator>
                            </div>            
                        </div>                
                    </div>
                    <div class="form-group">
                        <h5><label>Confirm the password</label></h5>
                        <asp:TextBox ID="tb_confPass" runat="server" CssClass="form-control" TextMode="Password" placeholder="Enter password again"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ForeColor="Red" runat="server" Text="This field is required" ControlToValidate="tb_confPass" ValidationGroup="register"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator2" ForeColor="Red" ValidationGroup="register" runat="server" Text="Passwords aren't identical" ControlToCompare="tb_password" ControlToValidate="tb_confPass"></asp:CompareValidator>
                    </div>
                    <div class="form-group">
                        <h5><label>Enter an address <small>(Optional)</small></label></h5>
                        <div class="form-row">
                            <div class="col-8">                
                                <asp:TextBox ID="tb_address" runat="server" CssClass="form-control" TextMode="Multiline" placeholder="Address"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="RegularExpressionValidator" ControlToValidate="tb_address" ForeColor="Red" ValidationExpression="/^Rua.*|Avenida.*|Av.*|Praceta.*|Pc.*|Travessa.*|Tv.*$" ValidationGroup="register">*Invalid address</asp:RegularExpressionValidator>
                            </div>
                            <div class="col-4">
                                <asp:TextBox ID="tb_zipCode" runat="server" CssClass="form-control" TextMode="Singleline" placeholder="Enter Zip-Code"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="tb_zipCode" ForeColor="Red" ValidationExpression="^\d{4}(-\d{3})?$" ValidationGroup="register">*Invalid Zip-Code</asp:RegularExpressionValidator>
                            </div>
                        </div>
                    </div>    
                    <br />
                    <asp:Label runat="server" ID="lbl_message" Text="" ForeColor="Red" Visible="False"></asp:Label>
                    <br />
                    <asp:Button ID="btn_register" runat="server" CssClass="btn btn-dark" ValidationGroup="register" Text="Create user" OnClick="btn_register_Click" />
                </form>

            </asp:Panel>
            <asp:Panel ID="pnl_success" Visible="false" runat="server">
                <div class="alert alert-success" role="alert">
                    <h4 class="alert-heading">User created!</h4>
                    <p>
                    We will now redirect you to the dashboard.
                    </p>
                    <hr>
                    <p class="mb-0">Wait 5 seconds</p>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
