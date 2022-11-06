<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/default.Master" AutoEventWireup="true" CodeBehind="changeUser.aspx.cs" Inherits="ProjectStore.Pages.changeUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <div class="container">
            <h3 class="text-center border-bottom">Modify user <asp:Label ID="lbl_user" runat="server" Text=""></asp:Label></h3><br />
            <div class="row">
                <div class="col table-responsive border-right border-left">
                    <table class="table table-striped table-hover">
                        <thead class="thead-dark">
                            <tr>
                                <th scope="auto"></th>
                                <th scope="auto">Current</th>                                
                                <th scope="auto">Change <small>(Select which ones you want to change)</small></th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <th scope="row">Name:</th>
                                <td>
                                    <asp:Label ID="lbl_name" runat="server" Text=""></asp:Label>
                                </td>
                                
                                <td>
                                    <div class="input-group mb-3">
                                        <div class="input-group-prepend">
                                            <div class="input-group-text">
                                                <asp:CheckBox ID="cb_name" runat="server" AutoPostBack="True" OnCheckedChanged="cb_name_CheckedChanged" />
                                            </div>
                                        </div>
                                        <asp:TextBox ID="tb_name" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    
                                </td>
                            </tr>
                            <tr>
                                <th scope="row">Profile:</th>
                                <td>
                                    <asp:Label ID="lbl_profile" runat="server" Text=""></asp:Label>
                                </td>                                
                                <td>
                                    <div class="input-group mb-3">
                                        <div class="input-group-prepend">
                                            <div class="input-group-text">
                                                <asp:CheckBox ID="cb_profile" runat="server" OnCheckedChanged="cb_profile_CheckedChanged" AutoPostBack="True" />
                                            </div>
                                        </div>
                                        <asp:DropDownList ID="ddl_profile" Enabled="False" CssClass="form-control" runat="server" DataSourceID="SqlDataSource1" DataTextField="profile" DataValueField="cod_profile" ></asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ProjectStoreConnectionString %>" SelectCommand="SELECT [cod_profile], [profile] FROM [profiles]"></asp:SqlDataSource>
                                    </div>                                    
                                </td>
                            </tr>
                            <tr>
                                <th scope="row">Active:</th>                                
                                <td>
                                    <asp:Label ID="lbl_active" runat="server" Text=""></asp:Label>
                                </td>   
                                <td>
                                     <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                            <div class="input-group-text">
                                                 <asp:CheckBox ID="cb_active" runat="server" OnCheckedChanged="cb_active_CheckedChanged" AutoPostBack="True" />
                                            </div>
                                        </div>
                                        <asp:DropDownList ID="ddl_active" Enabled="false" CssClass="form-control" runat="server">
                                        <asp:ListItem Value="1">True</asp:ListItem>
                                        <asp:ListItem Value="0">False</asp:ListItem>
                                     </asp:DropDownList>
                                     <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ProjectStoreConnectionString %>" SelectCommand="SELECT [active] FROM [users]"></asp:SqlDataSource>
                                    </div>                                   
                                </td>                                 
                            </tr>
                            <tr>
                                <th scope="row">Email:</th>
                                <td>
                                    <asp:Label ID="lbl_email" runat="server" Text=""></asp:Label>
                                </td>    
                                <td>
                                     <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                            <div class="input-group-text">
                                                <asp:CheckBox ID="cb_email" runat="server" OnCheckedChanged="cb_email_CheckedChanged" AutoPostBack="True" />
                                            </div>
                                        </div>
                                        <asp:TextBox ID="tb_email" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                                         
                                    </div>                                    
                                </td>                                 
                            </tr>
                            <tr>
                                <th scope="row">Address:</th>
                                <td>
                                    <asp:Label ID="lbl_address" runat="server" Text=""></asp:Label>
                                </td>    
                                <td>
                                     <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                            <div class="input-group-text">
                                                <asp:CheckBox ID="cb_address" runat="server" OnCheckedChanged="cb_address_CheckedChanged" AutoPostBack="True"/>
                                            </div>
                                        </div>
                                        <asp:TextBox ID="tb_address" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                                          
                                    </div>                                    
                                </td>                                
                            </tr>
                            <tr>
                                <th scope="row">Zip-Code:</th>
                                <td>
                                    <asp:Label ID="lbl_zipCode" runat="server" Text=""></asp:Label>
                                </td>       
                                <td>
                                     <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                            <div class="input-group-text">
                                                 <asp:CheckBox ID="cb_zipCode" runat="server" OnCheckedChanged="cb_zipCode_CheckedChanged" AutoPostBack="True"/>
                                            </div>
                                        </div>
                                        <asp:TextBox ID="tb_zipCode" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>                                          
                                    </div>                                   
                                    
                                </td>                                
                            </tr>                            
                        </tbody>
                    </table>
                </div>                
            </div>                    
                
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ForeColor="red"  ErrorMessage="Invalid email address" ValidationGroup="update" ControlToValidate="tb_email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
               <br /> <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ForeColor="red"  ErrorMessage="Invalid address" ControlToValidate="tb_address" ValidationExpression="/^Rua.*|Avenida.*|Av.*|Praceta.*|Pc.*|Travessa.*|Tv.*$" ValidationGroup="update"></asp:RegularExpressionValidator>
               <br /> <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ForeColor="red"  ErrorMessage="Invalid Zip-Code" ControlToValidate="tb_zipCode" ValidationExpression="^\d{4}(-\d{3})?$" ValidationGroup="update"></asp:RegularExpressionValidator>
               <br /> 
                <div class="text-center">
                    <asp:Button ID="btn_update" runat="server" CssClass="btn btn-dark" Text="Update User" ValidationGroup="Update" OnClick="Button1_Click"/>
                    <asp:Label ID="lbl_error" runat="server" Visible="false" Text="It appears something went wrong"></asp:Label>
                </div>
        </div>
            <div class="container">
                <div>
                    <h4>Want to delete the user?</h4>
                    <br />
                    <asp:Button ID="btn_delete" CssClass="btn btn-dark" runat="server" Text="Delete User" OnClick="btn_delete_Click" />
                </div>
                <br />
                <asp:Panel ID="pnl_delete" Visible="false" runat="server" >
                    <div class="form-group">
                        Insert your admin password.
                        <asp:TextBox ID="tb_password" TextMode="Password" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="lbl_warning" ForeColor="Red" Visible="false" runat="server" Text="Incorrect Password"></asp:Label>
                        <br />
                        <asp:Button ID="btn_confirm" CssClass="btn btn-dark" runat="server" Text="Confirm" OnClick="btn_confirm_Click" />
                    </div>
                </asp:Panel>

            </div>
        </ContentTemplate>
    </asp:UpdatePanel>    
</asp:Content>
