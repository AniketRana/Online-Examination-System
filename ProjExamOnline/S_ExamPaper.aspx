<%@ Page Title="" Language="C#" MasterPageFile="~/Student.Master" AutoEventWireup="true" CodeBehind="S_ExamPaper.aspx.cs" Inherits="ProjExamOnline.S_ExamPaper" %>

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
                            <br>
                            <br>
                            <h4 class="widgettitle" style="margin-top: 25px;">
                                <center>
                                    Exam Paper</center>

                            </h4>
                            <asp:Label ID="lblerr" runat="server" Style="color: Red;" Text=""></asp:Label>
                            <div style="height: 630px; width: 100%; overflow: scroll;">
                                <asp:Repeater ID="RepterPaper" runat="server" >
                                    <HeaderTemplate>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <table style="border: 1px solid #0000FF; width: 500px;margin:20px 10px 10px 10px ;" cellpadding="0" height="100px">
                                            <tr style="background-color: #89b7d6; color: #000000; font-size: large; font-weight: bold;">
                                                <td colspan="2">
                                                    <b>Exam Paper</b>
                                                </td>
                                            </tr>
                                            <tr style="background-color: #EBEFF0">
                                                <td colspan="2">Paper Type :
                                                                <asp:Label ID="lblPaperType" runat="server" Text='<%#Eval("PaperType") %>' Font-Bold="true" />
                                                </td>

                                            </tr>
                                            <tr>
                                                <td>Question Paper ID :
                                                    <asp:Label ID="lblQPID" runat="server" Text='<%#Eval("QPID") %>' />
                                                </td>
                                                <td>User ID :
                                                    <asp:Label ID="lblID" runat="server" Text='<%#Eval("AssignToID") %>' />
                                                </td>
                                            </tr>
                                             <tr style="background-color: #89b7d6; color: #000000; font-size: large; font-weight: bold;">
                                                <td colspan="2">
                                                    <asp:Button class="btn btn-primary" OnCommand="btnsubmit_Command" CommandName='<%# Eval("QPID") %>' CommandArgument='<%# Eval("AssignToID") %>' ID="btnsubmit" runat="server" Text="Test Now" Width="100px" />
                                                </td>
                                            </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </table>  
                                    </FooterTemplate>
                                </asp:Repeater>
                            </div>
                        </asp:Panel>
                    </div>
                    <!--contentinner-->
                </div>
                <!--maincontent-->
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
