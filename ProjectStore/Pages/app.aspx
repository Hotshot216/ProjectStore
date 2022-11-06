<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/default.Master" AutoEventWireup="true" CodeBehind="app.aspx.cs" Inherits="ProjectStore.Pages.app" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1"   runat="server">
     
     <div class="container-sm text-center border-bottom">
                <div class=" container-sm input-group rounded">
                    <asp:TextBox ID="searchbar" Placeholder="Search" CssClass="form-control rounded" runat="server"></asp:TextBox>
                    <asp:Button ID="btn_search" runat="server" CssClass="btn btn-outline-dark" Text="Search" OnClick="btn_search_Click"></asp:Button> 
                </div>
                <br />
            </div>
            <br />
     
        <div class="text-right" >
            <label>Filter by</label>
            <asp:DropDownList ID="ddl_filter" CssClass="btn btn-sm btn-secondary dropdown-toggle" runat="server" OnSelectedIndexChanged="ddl_filter_SelectedIndexChanged" AutoPostBack="True">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>Price Asc</asp:ListItem>
                <asp:ListItem>Price Desc</asp:ListItem>
                <asp:ListItem>Alphabetic Asc</asp:ListItem>
                <asp:ListItem>Alphabetic Desc</asp:ListItem>
            </asp:DropDownList>
        </div>

    
    <asp:UpdatePanel ID="UpdatePanel1"  runat="server" EnableViewState="false">
        <ContentTemplate>

            <asp:Panel ID="pnl_normal" runat="server">
                <div class="container-fluid">
                <br />
                <div class="container">
                    <asp:Repeater ID="store_repeater" runat="server">
                        <HeaderTemplate>
                            <div class="row">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div class="col">
                                <div class="card" style="width: 18rem;">
                                    <img class="card-img-top" height="300" src="<%#Eval("image")%>" alt="Card image cap">
                                    <div class="card-body">
                                        <h5 class="card-title"><%#Eval("name")%></h5>
                                        <p class="card-text text-dark" style="font-size:medium">
                                            <asp:Label ID="lbl_price" runat="server" ><%#Eval("value")%>€</asp:Label>                                           
                                            <asp:Label ID="lbl_idProd" Visible="false" runat="server"><%#Eval("id_prod")%></asp:Label>
                                        </p>
                                       <a href="soloproduct.aspx?id=<%#Eval("id_prod")%>" class="btn btn-dark">Add to cart</a>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                        <FooterTemplate>
                            </div>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
            </div>
            </asp:Panel>

            <asp:Panel ID="pnl_resale" Visible="false" runat="server">
                <div class="container-fluid">
                <br />
                <div class="container">
                    <asp:Repeater ID="Repeater1" runat="server">
                        <HeaderTemplate>
                            <div class="row">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div class="col">
                                <div class="card" style="width: 18rem;">
                                    <img class="card-img-top" height="300" src="<%#Eval("image")%>" alt="Card image cap">
                                    <div class="card-body">
                                        <h5 class="card-title"><%#Eval("name")%></h5>
                                        <p class="card-text text-dark" style="font-size:medium">
                                            <s><asp:Label ID="lbl_price" runat="server" ><%#Eval("value")%>€</asp:Label></s>
                                            <asp:Label ID="lbl_priceResale" Visible="true" runat="server" ><%#Eval("value_resale")%>€</asp:Label>
                                            <asp:Label ID="lbl_idProd" Visible="false" runat="server"><%#Eval("id_prod")%></asp:Label>
                                        </p>
                                       <a href="soloproduct.aspx?id=<%#Eval("id_prod")%>" class="btn btn-dark">Add to cart</a>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                        <FooterTemplate>
                            </div>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
            </div>
            </asp:Panel>
            
           
           

        </ContentTemplate>
    </asp:UpdatePanel>
    
</asp:Content>
