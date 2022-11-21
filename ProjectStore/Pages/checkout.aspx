<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/default.Master" AutoEventWireup="true" CodeBehind="checkout.aspx.cs" Inherits="ProjectStore.Pages.checkout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container text-center">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <br />
            <h4 class="font-weight-bold">Checkout</h4>
            <br />
            <asp:Repeater ID="Repeater1" runat="server">
                <HeaderTemplate>
                    <div class="row">
                </HeaderTemplate>
                <ItemTemplate>
                    
                <div class="col-8">
                    <asp:Label ID="Label1" runat="server" ><%#Eval("id_prod")%></asp:Label>
                    <asp:Label ID="Label2" runat="server" ><%#Eval("value")%></asp:Label>
                    <asp:Label ID="Label3" runat="server" ></asp:Label>
                </div>
                <div class="col-4">
                    <img src="<%#Eval("image")%>"/>
                </div>
                </ItemTemplate>
                <FooterTemplate>
                    </div>   
                </FooterTemplate>
            </asp:Repeater>                    

        </ContentTemplate>
    </asp:UpdatePanel>
</div>
</asp:Content>
