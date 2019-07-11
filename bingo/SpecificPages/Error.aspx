<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Front.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="bingo.SpecificPages.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceHolder" runat="server">
        <asp:Panel ID="ErrorPanel" runat="server">
        <div class="container content-container error-panel">
            <div class="title-div">
                <h1> Oups... an error has occured. Please try again. </h1>

                 <div id="ErrorImgCont" class="image-container" runat="server">
                    <asp:Image ID="ErrorImg" runat="server" ImageUrl="/Images/error.png" ImgText="Error Image"/>
                </div>

               <div class="center-text"><asp:Button id="BtnReset" CssClass="btn btn-success" runat="server" Text="Reset" OnClick="BtnResetClicked" /></div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
