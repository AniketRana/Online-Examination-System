<%@ Page Title="" Language="C#" MasterPageFile="~/Teacher.Master" AutoEventWireup="true" CodeBehind="T_PaperMst.aspx.cs" Inherits="ProjExamOnline.T_PaperMst" %>

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
                            <h4 class="widgettitle" align="center">Paper Type Details</h4>
                            <div class="widgetcontent" style="padding-left: 100px;">
                                <div id="form1" class="stdform">
                                    <div class="par control-group">
                                        <label class="control-label">
                                            QuestionPaperID
                                        </label>
                                        <div class="controls">
                                            <asp:TextBox ID="txtQpid" Enabled="false" class="input-xlarge" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="par control-group">
                                        <label class="control-label">
                                            Paper Type
                                        </label>
                                        <div class="controls">
                                            <asp:TextBox ID="txtPaperType" class="input-xlarge" runat="server"></asp:TextBox>                                            
                                        </div>
                                    </div>
                                    <p class="stdformbutton">
                                        <asp:Button class="btn btn-primary" ID="btnsubmit" runat="server" Text="Submit" Width="100px" OnClick="btnsubmit_Click" />
                                        <asp:Button class="btn btn-danger" ID="btncancel" runat="server" Text="Cancel" Width="100px" OnClick="btncancel_Click" />
                                        <br>
                                        <br>
                                        <asp:Label Style="color: red; font-size: large;" ID="lblmsg" runat="server" Text=""></asp:Label>
                                    </p>
                                </div>
                            </div>
                            <!--widgetcontent-->
                        </asp:Panel>
                        <asp:Panel ID="pnlgrid" Visible="true" runat="server">
                            
                            <asp:Button ID="btnAddNew" class="btn btn-default" runat="server" Text="Add New PaperType" OnClick="btnAddNew_Click" />
                            <br>
                            <br>
                            <br>
                            <h4 class="widgettitle" style="margin-top: 25px;">
                                <center>
                                    Question Paper Type Details</center>
                                </h4>
                                <asp:Label ID="lblerr" runat="server" Style="color: Red;" Text=""></asp:Label>
                                <div style="height: 630px; width: 100%; overflow: scroll;">
                                    <asp:GridView ID="grvQuesPaperMst" runat="server" align="center" AllowPaging="false" AutoGenerateColumns="False" class="table table-bordered" PageSize="10" Width="100%">
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <center>
                                                        QPID</center>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <center>
                                                        <asp:Label ID="lblQpID" runat="server" Text='<%# Bind("QPID") %>'></asp:Label>
                                                    </center>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <center>
                                                        Paper Type</center>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <center>
                                                        <asp:Label ID="lblQuePaperType" runat="server" Text='<%# Bind("PaperType")%>'></asp:Label>
                                                    </center>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <center>
                                                        Edit
                                                    </center>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <center>
                                                        <asp:ImageButton ID="imgEdit" runat="server" CommandArgument='<%# Eval("QPID") %>' Height="20px" ImageUrl="~/image/Edit.jpg" OnCommand="imgEdit_Command" ToolTip="Edit" Width="20px" />
                                                    </center>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <center>
                                                        Delete
                                                    </center>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <center>
                                                        <asp:ImageButton ID="imgDel" runat="server" CommandName='<%# Eval("QPID") %>' Height="20px" ImageUrl="~/image/del.png" OnClientClick="Confirm()" OnCommand="imgDel_Command" ToolTip="Delete" Width="20px" />
                                                    </center>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <script type="text/javascript">




                                    function Confirm() {
                                        var confirm_value = "";
                                        confirm_value = document.createElement("INPUT");

                                        confirm_value.type = "hidden";
                                        confirm_value.name = "confirm_value";
                                        if (confirm("Are you sure you want to delete ?")) {
                                            confirm_value.value = "";
                                            confirm_value.value = "Y";
                                        } else {
                                            confirm_value.value = "";
                                            confirm_value.value = "N";
                                        }
                                        document.forms[0].appendChild(confirm_value);
                                    }
                                </script>
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
