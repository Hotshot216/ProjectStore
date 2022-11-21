<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/default.Master" AutoEventWireup="true" CodeBehind="soloproduct.aspx.cs" Inherits="ProjectStore.Pages.soloproduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" EnableViewState="False">
        <ContentTemplate>
            <div class="container border-right border-bottom">
        <div class="row">
            <div class="col-6 mt-auto">
                 <div class="form-group">
                        <h4 class="border-bottom"><asp:Label ID="lbl_name"  runat="server" Text=""></asp:Label></h4>
                    </div>

                    <div class="form-group">
                        <asp:Panel ID="Panel1" runat="server">
                            <h5><asp:Label ID="lbl_price"  runat="server" Text=""></asp:Label></h5>
                        </asp:Panel>
                        <asp:Panel ID="Panel2" Visible="false" runat="server">
                            <h5><s><asp:Label ID="lbl_price2"  runat="server" Text=""></asp:Label></s></h5>
                            <h5><asp:Label ID="lbl_priceResale" Visible="true"  runat="server" Text=""></asp:Label></h5>
                        </asp:Panel>
                        
                        
                    </div>
                     <div class="form-group">
                        <h5><asp:Label ID="lbl_stock"  runat="server" Text=""></asp:Label></h5>            
                    </div>
                     <div class="form-group">
                         <asp:Button ID="btn_addProd" cssclass="btn btn-dark" runat="server" Text="Add to Cart" OnClick="btn_addProd_Click" />
                    </div>
            </div>
            <div class="col-6 text-right">
                <asp:Image ID="img_prod" CssClass="rounded" Width="300" runat="server" />                
            </div>            
        </div>
    </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    
</asp:Content>
