<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/MasterPages/Front.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="bingo.Home" %>

<asp:Content id="MainContent" runat="server" ContentPlaceHolderID="contentPlaceHolder">
  
    <nav class="navbar navbar-light">
        <div class="row">
            <div class="play-half col-sm-8 col-md-9">
                <img src="/Images/record.png" alt="record" />
                <a class="navbar-brand" href="#">Welcome</a>
            </div>
            <div class="score-half col-sm-4 col-md-3">
                <a class="navbar-brand" href="#">Score:<span><asp:Label id="Score" runat="server" /></span></a>
            </div>
        </div>
    </nav>
    
    <asp:Panel id="PlayingPanel" runat="server">
        <div class="container content-container">
            <div class="title-div">
                <h1>Where does this Tarantino's soundtrack come from? </h1>
                <h4>Try to gain 100 points within 10 answers! </h4>
            </div>
            <div class="row">
                <div class="col-xs-12 col-sm-8 col-md-6">
                    <asp:Literal id="videoContainer"  runat="server"></asp:Literal>	
                </div>
                <div class="col-xs-12 col-sm-4 col-md-6 radio-container">
                    <div><asp:RadioButton id="Film1Radio" runat="server" GroupName="TitlesGroup" /></div>
                    <div><asp:RadioButton id="Film2Radio" runat="server" GroupName="TitlesGroup" /></div>
                    <div><asp:RadioButton id="Film3Radio" runat="server" GroupName="TitlesGroup" /></div>
                     <asp:Button id="BtnSubmit" CssClass="btn btn-success" runat="server" Text="Submit" OnClick="BtnSubmitClicked" />
                </div>
            </div>
        </div>
    </asp:Panel>

</asp:Content>
