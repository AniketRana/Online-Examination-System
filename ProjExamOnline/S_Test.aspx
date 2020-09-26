<%@ Page Title="" Language="C#" MasterPageFile="~/Student.Master" AutoEventWireup="true" CodeBehind="S_Test.aspx.cs" Inherits="ProjExamOnline.S_Test" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="rightpanel">
                <div class="maincontent">

                    <div class="contentinner">
                        <asp:Label ID="lblException" Style="color: red;" runat="server" Text=""></asp:Label>
                        <div id="mydid" runat="server">
                        </div>
                        <asp:Panel ID="pnlgrid" Visible="true" runat="server">
                            
                            <h4 class="widgettitle" style="margin-top: 25px;">
                                <center>
                                    Test Paper</center>

                            </h4>
                            <asp:Label ID="lblerr" runat="server" Style="color: Red;" Text=""></asp:Label>
                            <div style="height: 630px; width: 100%; overflow: scroll;">
                                <asp:Repeater ID="RepterTestPaper" runat="server">
                                    <HeaderTemplate>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <table style="border: 1px solid #0000FF; width: 500px; margin: 20px 10px 10px 10px;" cellpadding="0" height="100px">
                                            <tr style="background-color: #89b7d6; color: #000000; font-size: large; font-weight: bold;">
                                                <td colspan="2">
                                                    <b>
                                                        <br />
                                                    </b>
                                                </td>
                                            </tr>
                                            <tr style="background-color: #EBEFF0">
                                                <td colspan="2" style="padding-left: 20px;">
                                                    <asp:HiddenField ID="hfQdID" runat="server" Value='<%#Eval("QdID") %>' />
                                                    <asp:HiddenField ID="HfCorrectAns" runat="server" Value='<%#Eval("CorrectAns") %>' />
                                                    Question :
                                                    <asp:Label ID="lblQuestion" runat="server" Text='<%#Eval("Question") %>' Font-Bold="true" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="padding-left: 20px;">Ans1 :
                                                    <asp:Label ID="lblAns1" runat="server" Text='<%#Eval("Ans1") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="padding-left: 20px;">Ans2 :
                                                    <asp:Label ID="lblAns2" runat="server" Text='<%#Eval("Ans2") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="padding-left: 20px;">Ans3 :
                                                    <asp:Label ID="lblAns3" runat="server" Text='<%#Eval("Ans3") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="padding-left: 20px;">Ans4 :
                                                    <asp:Label ID="lblAns4" runat="server" Text='<%#Eval("Ans4") %>' />
                                                </td>
                                            </tr>
                                            <tr style="background-color: palegreen; margin-bottom: 10px;">
                                                <td colspan="2" style="padding-left: 20px;">Choose Your Ans : 
                                                    <asp:DropDownList Style="float: center; height: 30px; width: 75px;" ID="ddluserAns" runat="server">
                                                        <asp:ListItem>Ans1</asp:ListItem>
                                                        <asp:ListItem>Ans2</asp:ListItem>
                                                        <asp:ListItem>Ans3</asp:ListItem>
                                                        <asp:ListItem>Ans4</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            </tr>
                                            <td>&nbsp</td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </table>  
                                    </FooterTemplate>
                                </asp:Repeater>
                            </div>
                            <br />
                            <asp:Button class="btn btn-primary" ID="btnsubmitPaper" runat="server" Text="Submit the Paper" Width="200px" OnClick="btnsubmitPaper_Click" />
                            <br />
                            <br />
                            <asp:Label Style="color: green; font-size: large;" ID="lblmsg" runat="server" Text=""></asp:Label>
                        </asp:Panel>
                    </div>
                    <!--contentinner-->
                </div>
                <!--maincontent-->
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
