<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/default.Master" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="ProjectStore.Pages.profile" %>
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
                        <tbody>
                            <tr>
                                <th scope="row">Name:</th>
                                <td>
                                    <asp:TextBox ID="tb_name" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                    
                                </td>                                
                                
                            </tr>                            
                           
                            <tr>
                                <th scope="row">Email:</th>
                                <td>
                                    <asp:TextBox ID="tb_email" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                </td>    
                                                         
                            </tr>
                            <tr>
                                <th scope="row">Address:</th>
                                <td>
                                    <asp:TextBox ID="tb_address" CssClass="form-control" TextMode="MultiLine" ReadOnly="true" runat="server"></asp:TextBox>
                                </td>    
                                                       
                            </tr>
                            <tr>
                                <th scope="row">Zip-Code:</th>
                                <td>
                                    <asp:TextBox ID="tb_zipCode" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                </td>       
                                                   
                            </tr>                            
                        </tbody>
                    </table>
                </div>                
            </div>                    
                
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ForeColor="red"  ErrorMessage="Invalid email address" ValidationGroup="Update" ControlToValidate="tb_email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
               <br /> <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ForeColor="red"  ErrorMessage="Invalid address" ControlToValidate="tb_address" ValidationExpression="/^Rua.*|Avenida.*|Av.*|Praceta.*|Pc.*|Travessa.*|Tv.*$" ValidationGroup="Update"></asp:RegularExpressionValidator>
               <br /> <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ForeColor="red"  ErrorMessage="Invalid Zip-Code" ControlToValidate="tb_zipCode" ValidationExpression="^\d{4}(-\d{3})?$" ValidationGroup="Update"></asp:RegularExpressionValidator>
               <br /> 
               
                <div class="text-center">
                    <asp:Button ID="btn_update" runat="server" Visible="false" CssClass="btn btn-dark" ValidationGroup="Update" Text="Update Profile" OnClick="btn_update_Click" />
                    <asp:Button ID="btn_cancel" runat="server" Visible="false" CssClass="btn btn-dark" Text="Cancel" OnClick="btn_cancel_Click" />
                    <asp:Button ID="btn_change" runat="server" CssClass="btn btn-dark" Text="Change Profile"  OnClick="Button1_Click"/>
                    <asp:Label ID="lbl_error" runat="server" Visible="false" Text="It appears something went wrong"></asp:Label>
                </div>
        </div>           
        </ContentTemplate>
    </asp:UpdatePanel>    

</asp:Content>
