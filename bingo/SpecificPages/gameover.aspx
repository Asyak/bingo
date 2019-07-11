<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Front.Master" AutoEventWireup="true" CodeBehind="Gameover.aspx.cs" Inherits="bingo.SpecificPages.gameover" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceHolder" runat="server">

    <asp:Panel ID="GameOverPanel" runat="server">
        <div class="container content-container">
            <div class="title-div">
                <h1> Game Over </h1>

                <div id="TxtCongrats" class="center-text" runat="server"></div>

                <div id="BadgeImgCont" class="image-container" runat="server">
                    <asp:Image ID="BadgeImg" runat="server" ImgText="Badge Image"/>
                </div>

                 <h4 class="text-center" href="#">Score:<span><asp:Label id="Score" runat="server" /></span></h4>

               <asp:Button id="BtnPlay" CssClass="btn btn-success center" runat="server" Text="Play again" OnClick="BtnPlayClicked" />
            </div>
        </div>
    </asp:Panel>

</asp:Content>
