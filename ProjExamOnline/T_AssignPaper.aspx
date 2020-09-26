<%@ Page Title="" Language="C#" MasterPageFile="~/Teacher.Master" AutoEventWireup="true" CodeBehind="T_AssignPaper.aspx.cs" Inherits="ProjExamOnline.T_AssignPaper" %>

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
                            <h4 class="widgettitle" align="center">Assign Paper to students</h4>
                            <div class="widgetcontent" style="padding-left: 100px;">
                                <div id="form1" class="stdform">
                                    <div class="par control-group">
                                        <label class="control-label">
                                            Select Question Paper
                                        </label>
                                        <div class="controls">
                                            <asp:DropDownList ID="ddlQuestionPaper" AutoPostBack="true" OnSelectedIndexChanged="ddlQuestionPaper_SelectedIndexChanged" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <br />
                                    Question Paper And their Respective Question list 
                                    <br />
                                    <div style="height: 250px; width: 100%; overflow: scroll;">
                                        <asp:GridView ID="grvQuesList" runat="server" align="center" AllowPaging="false"
                                            AutoGenerateColumns="False" class="table table-bordered" PageSize="10" Width="100%">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <center>
                                                        PaperType</center>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <center>
                                                        <asp:Label ID="lblPaperType" runat="server" Text='<%# Bind("PaperType")%>'></asp:Label>
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


                                    <br />
                                    Select Students from below list to assign
                                        <br />
                                    <div style="height: 250px; width: 100%; overflow: scroll;">

                                        <asp:GridView ID="grvStudents" runat="server" align="center" AllowPaging="false"
                                            AutoGenerateColumns="False" class="table table-bordered" PageSize="10" Width="100%">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkSelect" Style="height: 20px !important; width: 20px !important;" runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <center>
                                                        ID</center>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <center>
                                                        <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                                    </center>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <center>
                                                        Name</center>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <center>
                                                        <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                                    </center>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <center>
                                                        Email</center>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <center>
                                                        <asp:Label ID="lblSubject" runat="server" Text='<%# Bind("Email")%>'></asp:Label>
                                                    </center>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>

                                    </div>

                                    <p class="stdformbutton">
                                        <asp:Button class="btn btn-primary" ID="btnAssignPaperToStudent" runat="server" OnClick="btnAssignPaperToStudent_Click" Text="Assign Paper to Students" Width="200px" />
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
