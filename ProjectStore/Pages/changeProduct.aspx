<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/default.Master" AutoEventWireup="true" CodeBehind="changeProduct.aspx.cs" Inherits="ProjectStore.Pages.changeProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <div class="container">
            <h3 class="text-center border-bottom">Modify product <asp:Label ID="lbl_product" runat="server" Text=""></asp:Label></h3><br />
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
                                <th scope="row">Price:</th>
                                <td>
                                    <asp:Label ID="lbl_price" runat="server" Text=""></asp:Label>
                                </td>                                
                                <td>
                                    <div class="input-group mb-3">
                                        <div class="input-group-prepend">
                                            <div class="input-group-text">
                                                <asp:CheckBox ID="cb_price" runat="server" OnCheckedChanged="cb_price_CheckedChanged" AutoPostBack="True" />
                                            </div>
                                        </div>
                                        <asp:TextBox ID="tb_price" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>                                    
                                </td>
                            </tr>
                            <tr>
                                <th scope="row">Resale Price:</th>                                
                                <td>
                                    <asp:Label ID="lbl_resalePrice" runat="server" Text=""></asp:Label>
                                </td>   
                                <td>
                                     <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                            <div class="input-group-text">
                                                 <asp:CheckBox ID="cb_resalePrice" runat="server" OnCheckedChanged="cb_resalePrice_CheckedChanged" AutoPostBack="True" />
                                            </div>
                                        </div>
                                         <asp:TextBox ID="tb_resalePrice" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                                         <asp:Button ID="btn_resale" runat="server" Enabled="false" Text="Apply Discount" OnClick="btn_resale_Click" />
                                    </div>                                   
                                </td>                                 
                            </tr>
                            <tr>
                                <th scope="row">Sales:</th>
                                <td>
                                    <asp:Label ID="lbl_sales" runat="server" Text=""></asp:Label>
                                </td>    
                                <td>
                                     <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                            <div class="input-group-text">
                                                <asp:CheckBox ID="cb_sales" runat="server" OnCheckedChanged="cb_sales_CheckedChanged" AutoPostBack="True" />
                                            </div>
                                        </div>
                                        <asp:TextBox ID="tb_sales" CssClass="form-control" TextMode="Number" Enabled="false" runat="server"></asp:TextBox>
                                         
                                    </div>                                    
                                </td>                                 
                            </tr>
                            <tr>
                                <th scope="row">Stock:</th>
                                <td>
                                    <asp:Label ID="lbl_stock" runat="server" Text=""></asp:Label>
                                </td>    
                                <td>
                                     <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                            <div class="input-group-text">
                                                <asp:CheckBox ID="cb_stock" runat="server" OnCheckedChanged="cb_stock_CheckedChanged" AutoPostBack="True"/>
                                            </div>
                                        </div>
                                        <asp:TextBox ID="tb_stock" CssClass="form-control" TextMode="Number" Enabled="false" runat="server"></asp:TextBox>
                                          
                                    </div>                                    
                                </td>                                
                            </tr>                                                   
                        </tbody>
                    </table>
                </div>                
            </div>                                    
                
                <div class="text-center">
                    <asp:RegularExpressionValidator runat="server" ErrorMessage="Decimal Only" ID="RegularExpressionValidator1" ValidationGroup="Update" ControlToValidate="tb_price" ValidationExpression="^\d+\.\d{0,2}$"></asp:RegularExpressionValidator>
                     <asp:RegularExpressionValidator runat="server" ErrorMessage="Decimal Only" ID="txtregpre" ValidationGroup="Update" ControlToValidate="tb_resalePrice" ValidationExpression="^\d+\.\d{0,2}$"></asp:RegularExpressionValidator>  
                    <asp:Button ID="btn_update" runat="server" CssClass="btn btn-dark" Text="Update Product" ValidationGroup="Update" OnClick="Button1_Click"/>
                    <asp:Label ID="lbl_error" runat="server" Visible="false" Text="It appears something went wrong"></asp:Label>
                </div>
        </div>
            </ContentTemplate>
    </asp:UpdatePanel>   
            <br />
    <div class="container border-top">
    <div class="row">
        <div class="col ">
            <h5>Image</h5>
            <br />
            <asp:Image ID="img_prod" Width="400" runat="server" />
        </div>               
        <br />
        <div class="col mt-auto">
            <h6>Change image.</h6>
            
            <asp:FileUpload ID="FileUpload1" runat="server" />
        </div>
        <div class="col mt-auto">
            <asp:Label ID="lbl_imageText" Visible="false" runat="server" Text=""></asp:Label>
            <asp:Button ID="btn_image" CssClass="btn btn-dark" runat="server" Text="Change image" OnClick="btn_image_Click" />
        </div>
    </div>                    
 </div>       
    <br />
    <br />
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <div class="container border-top">
                <div>
                    <h4>Want to delete the product?</h4>
                    <br />
                    <asp:Button ID="btn_delete" CssClass="btn btn-dark" runat="server" Text="Delete Product" OnClick="btn_delete_Click" />
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
