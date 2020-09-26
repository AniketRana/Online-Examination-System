<%@ Page Title="" Language="C#" MasterPageFile="~/Teacher.Master" AutoEventWireup="true" CodeBehind="T_CreatePaper.aspx.cs" Inherits="ProjExamOnline.T_CreatePaper" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        tr:hover {
            box-shadow: 1px 1px 4px 2px #82bfff;
            color: Black;
        }

        td:hover {
            background-color: #008acc8a;
            color: Black;
        }
    </style>
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="rightpanel">
                <div class="maincontent">

                    <div class="contentinner">
                        <asp:Label ID="lblException" Style="color: red;" runat="server" Text=""></asp:Label>
                        <div id="mydid" runat="server">
                        </div>
                        <asp:Panel ID="pnlform" Visible="false" runat="server">
                            <h4 class="widgettitle" align="center">Create Paper</h4>
                            <div class="widgetcontent" style="padding-left: 100px;">
                                <div id="form1" class="stdform">
                                    <div class="par control-group">
                                        <label class="control-label">
                                            PaperType
                                        </label>
                                        <div class="controls">
                                            <asp:DropDownList ID="ddlPaperType" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                     <br/>
                                        Select Question from below list 
                                        <br/>
                                    <div style="height: 330px; width: 100%; overflow: scroll;">
                                       
                                        <asp:GridView ID="grvQuesPaperMst" runat="server" align="center" AllowPaging="false"
                                            AutoGenerateColumns="False" class="table table-bordered" PageSize="10" Width="100%">
                                            <Columns>
                                                <asp:TemplateField>                                                    
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkSelect" Style="height: 30px !important; width: 30px !important;padding-left:10px !important;" runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <center>
                                                        QdID</center>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <center>
                                                        <asp:Label ID="lblQdID" runat="server" Text='<%# Bind("QdID") %>'></asp:Label>
                                                    </center>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <center>
                                                        Subject</center>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <center>
                                                        <asp:Label ID="lblSubject" runat="server" Text='<%# Bind("Subject")%>'></asp:Label>
                                                    </center>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <center>
                                                        Question</center>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <center>
                                                        <asp:Label ID="lblQuestion" runat="server" Text='<%# Bind("Question")%>'></asp:Label>
                                                    </center>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <center>
                                                        Correct Ans</center>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <center>
                                                        <asp:Label ID="lblCorrectAns" runat="server" Text='<%# Bind("CorrectAns")%>'></asp:Label>
                                                    </center>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>

                                    </div>

                                    <p class="stdformbutton">
                                        <asp:Button class="btn btn-primary" ID="btnCreatePaper" runat="server" OnClick="btnCreatePaper_Click" Text="Create Paper" Width="100px" />
                                        <br>
                                        <br>
                                        <asp:Label Style="color: green; font-size: large;" ID="lblmsg" runat="server" Text=""></asp:Label>
                                    </p>
                                </div>
                            </div>
                            <!--widgetcontent-->
                        </asp:Panel>
                    </div>
                    <!--contentinner-->
                </div>
                <!--maincontent-->
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
