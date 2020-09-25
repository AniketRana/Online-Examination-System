<%@ Page Title="" Language="C#" MasterPageFile="~/Teacher.Master" AutoEventWireup="true" CodeBehind="T_AddQuesDetails.aspx.cs" Inherits="ProjExamOnline.T_AddQuesDetails" %>

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
    
    <asp:updatepanel id="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="rightpanel">
                <div class="maincontent">

                    <div class="contentinner">
                        <asp:Label ID="lblException" Style="color: red;" runat="server" Text=""></asp:Label>
                        <div id="mydid" runat="server">
                        </div>
                        <asp:Panel ID="pnlform" Visible="false" runat="server">
                            <h4 class="widgettitle" align="center">Add Question Details</h4>
                            <div class="widgetcontent" style="padding-left: 100px;">
                                <div id="form1" class="stdform">
                                    <div class="par control-group">
                                        <label class="control-label">
                                            Subject
                                        </label>
                                        <div class="controls">
                                            <asp:DropDownList ID="ddlSubject" runat="server"></asp:DropDownList>
                                            <asp:HiddenField ID="hdQdid" runat="server"></asp:HiddenField>
                                        </div>
                                    </div>
                                    <div class="par control-group">
                                        <label class="control-label">
                                            Question
                                        </label>
                                        <div class="controls">
                                            <asp:TextBox ID="txtQuestion" class="input-xlarge" runat="server"></asp:TextBox>                                            
                                        </div>
                                    </div>
                                     <div class="par control-group">
                                        <label class="control-label">
                                            Ans1
                                        </label>
                                        <div class="controls">
                                            <asp:TextBox ID="txtAns1" class="input-xlarge" runat="server"></asp:TextBox>                                            
                                        </div>
                                    </div>
                                     <div class="par control-group">
                                        <label class="control-label">
                                            Ans2
                                        </label>
                                        <div class="controls">
                                            <asp:TextBox ID="txtAns2" class="input-xlarge" runat="server"></asp:TextBox>                                            
                                        </div>
                                    </div>
                                    <div class="par control-group">
                                        <label class="control-label">
                                            Correct Ans
                                        </label>
                                        <div class="controls">
                                           <asp:DropDownList class="selector" ID="ddlCorrectAns" runat="server" >
                                                <asp:ListItem>Ans1</asp:ListItem>
                                                <asp:ListItem>Ans2</asp:ListItem>
                                                <asp:ListItem>Ans3</asp:ListItem>
                                                <asp:ListItem>Ans4</asp:ListItem>                                
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    
                                    <p class="stdformbutton">
                                        <asp:Button class="btn btn-primary" ID="btnsubmit" runat="server" Text="Submit" Width="100px"  />
                                        <asp:Button class="btn btn-danger" ID="btncancel" runat="server" Text="Cancel" Width="100px" />
                                        <br>
                                        <br>
                                        <asp:Label Style="color: red; font-size: large;" ID="lblmsg" runat="server" Text=""></asp:Label>
                                    </p>
                                </div>
                            </div>
                            <!--widgetcontent-->
                        </asp:Panel>
                        <asp:Panel ID="pnlgrid" Visible="true" runat="server">                            
                            <asp:Button ID="btnAddNew" class="btn btn-default" runat="server" Text="Add New Ques" />
                            <br>
                            <br>
                            <br>
                            <h4 class="widgettitle" style="margin-top: 25px;">
                                <center>
                                    Add Question Details</center>

                            </h4>
                            <asp:Label ID="lblerr" runat="server" Style="color: Red;" Text=""></asp:Label>
                            <div style="height: 630px; width: 100%; overflow: scroll;">
                                <asp:GridView ID="grvAddQues" runat="server" align="center" AllowPaging="false" AutoGenerateColumns="False" 
                                    class="table table-bordered" PageSize="10" Width="100%">
                                    <Columns>
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
                                        <%--<asp:TemplateField>
                                            <HeaderTemplate>
                                                <center>
                                                        Subject</center>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <center>
                                                        <asp:Label ID="lblSubject" runat="server" Text='<%# Bind("Subject") %>'></asp:Label>
                                                    </center>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
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
                                                        Ans1</center>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <center>
                                                        <asp:Label ID="lblAns1" runat="server" Text='<%# Bind("Ans1")%>'></asp:Label>
                                                    </center>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <center>
                                                        Ans2</center>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <center>
                                                        <asp:Label ID="lblAns2" runat="server" Text='<%# Bind("Ans2")%>'></asp:Label>
                                                    </center>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <center>
                                                        Ans3</center>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <center>
                                                        <asp:Label ID="lblAns3" runat="server" Text='<%# Bind("Ans3")%>'></asp:Label>
                                                    </center>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <center>
                                                        Ans4</center>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <center>
                                                        <asp:Label ID="lblAns4" runat="server" Text='<%# Bind("Ans4")%>'></asp:Label>
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

                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <center>
                                                        Edit
                                                    </center>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <center>
                                                        <asp:ImageButton ID="imgEdit" runat="server" CommandArgument='<%# Eval("QID") %>' 
                                                            Height="20px" ImageUrl="~/image/Edit.jpg" OnCommand="imgEdit_Command"
                                                            ToolTip="Edit" Width="20px" />
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
                                                        <asp:ImageButton ID="imgDel" runat="server" CommandName='<%# Eval("QID") %>' 
                                                            Height="20px" ImageUrl="~/image/del.png" OnClientClick="Confirm()" OnCommand="imgDel_Command" 
                                                            ToolTip="Delete" Width="20px" />
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
    </asp:updatepanel>
</asp:Content>
