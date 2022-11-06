<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/default.Master" AutoEventWireup="true" CodeBehind="add_product.aspx.cs" Inherits="ProjectStore.Pages.add_product" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnl_addProduct" runat="server">
                <form>
                <div class="form-group">
                    <h5><label>Product Name</label></h5>
                    <asp:TextBox ID="tb_name" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="red" ErrorMessage="Required Field" ValidationGroup="add" ControlToValidate="tb_name"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">                    
                    <div class="row">
                        <div class="col-6">
                            <h5><label>Price</label></h5>
                            <asp:TextBox ID="tb_price" CssClass="form-control" runat="server" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="red" ErrorMessage="Required Field" ValidationGroup="add"  ControlToValidate="tb_price"></asp:RequiredFieldValidator>
                             <asp:RegularExpressionValidator runat="server" ErrorMessage="Decimal Only" ID="RegularExpressionValidator1" ValidationGroup="Insert" ControlToValidate="tb_price" ValidationExpression="^\d+\.\d{0,2}$"></asp:RegularExpressionValidator>
                        </div>
                        <div class="col-6">
                            <h5><label>Resale Price</label></h5>                            
                            <asp:TextBox ID="tb_resalePrice" CssClass="form-control"  ReadOnly="true" Text="-" runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator runat="server" ErrorMessage="Decimal Only" ID="txtregpre" ValidationGroup="Insert" ControlToValidate="tb_resalePrice" ValidationExpression="^\d+\.\d{0,2}$"></asp:RegularExpressionValidator>  
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="red" ErrorMessage="Required Field" ValidationGroup="add"  ControlToValidate="tb_resalePrice"></asp:RequiredFieldValidator>
                            <br />
                            <asp:Button ID="btn_apply" CssClass="btn btn-dark" runat="server" Text="Apply Discount" OnClick="btn_apply_Click" />
                            <asp:Button ID="btn_personalizedValue" CssClass="btn btn-dark" runat="server" Text="Personalize value" OnClick="btn_personalizedValue_Click" />
                        </div>                        
                    </div>                   
                </div>                
                <div class="form-group">
                    <div class="row">
                        <div class="col-6">
                            <h5><label>Sales</label></h5>
                            <asp:TextBox ID="tb_sales" CssClass="form-control" runat="server" TextMode="Number">0</asp:TextBox>
                        </div>
                        <div class="col-6">
                            <h5><label>Stock</label></h5>
                            <asp:TextBox ID="tb_stock" CssClass="form-control" runat="server" TextMode="Number">0</asp:TextBox>
                        </div>
                    </div>                    
                </div>               
               
                </form>
            </asp:Panel>
             
        </ContentTemplate>
       
        <Triggers>
            <asp:PostBackTrigger ControlID="btn_addProd" />
        </Triggers>
    </asp:UpdatePanel>

    <div class="form-group">
                    <h5><asp:Label ID="lbl_image" runat="server" Text="Image"></asp:Label></h5>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                    
                </div>
                <div class="form-group">
                    <asp:Label ID="lbl_message" Visible="false" runat="server" ForeColor="red" Text=""></asp:Label>
                    <br />
                    <asp:Button ID="btn_addProd" runat="server" cssclass="btn btn-dark" ValidationGroup="add"  Text="Add Product" OnClick="btn_addProd_Click" />
                </div>
    <asp:Panel ID="pnl_success" Visible="false" runat="server">
                <div class="alert alert-success" role="alert">
                    <h4 class="alert-heading">Product created!</h4>
                    <p>
                    We will now redirect you to the dashboard.
                    </p>
                    <hr>
                    <p class="mb-0">Wait 5 seconds</p>
                </div>
            </asp:Panel>
</asp:Content>
