<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/default.Master" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="ProjectStore.Pages.Admin.dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" EnableViewState="false" runat="server">
        <ContentTemplate>
            <h2 class="font-weight-bold">Welcome <asp:Label ID="lbl_admin" runat="server" Text=""></asp:Label>!</h2>            
            <br />
            <div class="border-top text-center form-group">
                <asp:DropDownList CssClass="btn btn-dark dropdown-toggle" ID="ddl_Mode" runat="server" OnSelectedIndexChanged="ddl_Mode_SelectedIndexChanged" AutoPostBack="True">
                    <asp:ListItem>Choose Dashboard</asp:ListItem>
                    <asp:ListItem>User Dashboard</asp:ListItem>
                    <asp:ListItem>Product Dashboard</asp:ListItem>
                </asp:DropDownList>
                                                       
                                </div>
            <asp:Panel ID="pnl_userDash" Visible="false" runat="server">
                
                            <div class="container form-group">
                                <div class="form-group">
                                    <asp:Button ID="btn_add" CssClass="btn btn-dark" runat="server" Text="Add user" OnClick="btn_add_Click" />
                                </div>
                                <div class="table-responsive">                    
                                    <asp:Repeater ID="Repeater1" runat="server">
                                        <HeaderTemplate>
                                            <table class="table table-striped table-hover">
                                                <thead class="thead-dark">
                                                    <tr>
                                                        <th scope="col">ID</th>
                                                        <th scope="col">Name</th>                                            
                                                        <th scope="col">Profile</th>
                                                        <th scope="col">Active</th>
                                                        <th scope="col">Email</th>
                                                        <th scope="col">Address</th>
                                                        <th scope="col">Zip-Code</th>                                               
                                                    </tr>
                                                </thead>
                                                <tbody>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr onclick="window.location='changeUser.aspx?id=<%#Eval("id")%>';">
                                                <th scope="row"><%#Eval("id")%></th>                                    
                                                <td><%#Eval("name") %></td>                                    
                                                <td><%#Eval("profile") %></td>
                                                <td><%#Eval("active") %></td>
                                                <td><%#Eval("email") %></td>
                                                <td><%#Eval("address") %></td>
                                                <td><%#Eval("zipCode") %></td>
                                           </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </tbody>
                                            </table>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                     
            </asp:Panel>

            <asp:Panel ID="pnl_prodDash" Visible="false" runat="server">
                <div>
                    <div class="container form-group">
                                <div class="form-group">
                                    <asp:Button ID="btn_addProd" CssClass="btn btn-dark" runat="server" Text="Add product" OnClick="btn_addProd_Click" />
                                </div>
                                <div class="table-responsive">                    
                                    <asp:Repeater ID="Repeater2" runat="server">
                                        <HeaderTemplate>
                                            <table class="table table-striped table-hover">
                                                <thead class="thead-dark">
                                                    <tr>
                                                        <th scope="col">Reference</th>
                                                        <th scope="col">Name</th>                                            
                                                        <th scope="col">Price</th>
                                                        <th scope="col">Resale price</th>
                                                        <th scope="col">Sales</th>
                                                        <th scope="col">Stock</th>
                                                        <th scope="col">Image</th>                                               
                                                    </tr>
                                                </thead>
                                                <tbody>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr onclick="window.location='changeProduct.aspx?id=<%#Eval("id_prod")%>';">
                                                <th scope="row"><%#Eval("id_prod")%></th>                                    
                                                <td><%#Eval("name") %></td>                                    
                                                <td><%#Eval("value") %>€</td>
                                                <td><%#Eval("value_resale") %>€</td>
                                                <td><%#Eval("sales") %></td>
                                                <td><%#Eval("stock") %></td>
                                                <td><img src="<%#Eval("image") %>" width="200"/></td>
                                           </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </tbody>
                                            </table>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
