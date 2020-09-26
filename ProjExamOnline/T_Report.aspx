<%@ Page Title="" Language="C#" MasterPageFile="~/Teacher.Master" AutoEventWireup="true" CodeBehind="T_Report.aspx.cs" Inherits="ProjExamOnline.T_Report" %>

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
                        <asp:Panel ID="pnlgrid" Visible="true" runat="server">
                            <br>
                            <br>
                            <h4 class="widgettitle" style="margin-top: 25px;">
                                <center>
                                    Student Exam Paper Report </center>

                            </h4>
                            <asp:Label ID="lblerr" runat="server" Style="color: Red;" Text=""></asp:Label>
                            <div style="height: 630px; width: 100%; overflow: scroll;">
                                <asp:GridView ID="grvReport" runat="server" align="center" AllowPaging="false" AutoGenerateColumns="False" class="table table-bordered" PageSize="10" Width="100%">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <center>
                                                        PaperType</center>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <center>
                                                        <asp:Label ID="lblPaperType" runat="server" Text='<%# Bind("PaperType") %>'></asp:Label>
                                                    </center>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <center>
                                                        Student Name</center>
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
                                                        <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("Email") %>'></asp:Label>                          
                                                    </center>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <center>
                                                        IsCompleted/Status</center>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <center>
                                                        <asp:Label ID="lblQuestion" runat="server" Text='<%# Eval("IsCompleted").ToString() == "True" ? "Completed" : "Pending" %>'></asp:Label>
                                                    </center>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <center>
                                                        Marks</center>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <center>
                                                        <asp:Label ID="lblmarks" runat="server" Text='<%# Bind("Marks")%>'></asp:Label>
                                                    </center>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
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
