<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProjExamOnline.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="css/style.default.css" type="text/css" />
    <script type="text/javascript" src="js/jquery-1.9.1.min.js"></script>
    <script type="text/javascript" src="js/jquery-migrate-1.1.1.min.js"></script>
    <style>
        input[type="submit"] {
            background-color: #82cbff;
            color: black;
        }

        body, html {
            height: 100%;
            margin: 0;
        }

        .bg {
            /* The image used */
            background-image: url("image/shortGamma.jpg"); /* Full height */
            height: 100%; /* Center and scale the image nicely */
            background-position: center;
            background-repeat: no-repeat;
            background-size: cover;
        }
    </style>
</head>
<body class="loginbody">
    <div class="bg" style="height: 100%;">
        <form id="form1" runat="server">
            <div>

                <div class="loginwrapper" style="margin-top: 0px; padding-top: 125px;">

                    <div class="loginwrap zindex100 animate2 bounceInDown">
                        <center><h1><font style="color:black;"> Online Exam</font></h1></center>
                        <h1 class="logintitle">

                            <span class="iconfa-lock"></span>Sign In <span class="subtitle">Hello! Sign in to get
                        you started!</span></h1>
                        <div class="loginwrapperinner">
                            <form id="loginform" action="#" method="post">
                                <p class="animate4 b    ounceIn">
                                    <asp:TextBox ID="txtusername" AutoCompleteType="Disabled" required placeholder="Email" runat="server"></asp:TextBox>
                                </p>
                                <p class="animate5 bounceIn">
                                    <asp:TextBox ID="txtpassword" AutoCompleteType="Disabled" required placeholder="Password" TextMode="Password"
                                        runat="server"></asp:TextBox>
                                </p>
                                <p class="animate6 bounceIn">

                                    <asp:Button ID="btnSubmit" class="btn btn-default btn-block" OnClick="btnSubmit_Click" runat="server" Text="Submit" />

                                </p>
                                <b>
                                    <asp:Label Style="color: white; font" ID="lblmsg" runat="server" Text=""></asp:Label><b>
                            </form>
                        </div>
                        <!--loginwrapperinner-->
                    </div>
                    <%--<div class="loginshadow animate3 fadeInUp">
            </div>--%>
                </div>
            </div>
        </form>
    </div>
</body>
<script type="text/javascript">
    jQuery.noConflict();

    jQuery(document).ready(function () {

        var anievent = (jQuery.browser.webkit) ? 'webkitAnimationEnd' : 'animationend';
        jQuery('.loginwrap').bind(anievent, function () {
            jQuery(this).removeClass('animate2 bounceInDown');
        });

        jQuery('#username,#password').focus(function () {
            if (jQuery(this).hasClass('error')) jQuery(this).removeClass('error');
        });

        jQuery('#loginform button').click(function () {
            if (!jQuery.browser.msie) {
                if (jQuery('#username').val() == '' || jQuery('#password').val() == '') {
                    if (jQuery('#username').val() == '') jQuery('#username').addClass('error'); else jQuery('#username').removeClass('error');
                    if (jQuery('#password').val() == '') jQuery('#password').addClass('error'); else jQuery('#password').removeClass('error');
                    jQuery('.loginwrap').addClass('animate0 wobble').bind(anievent, function () {
                        jQuery(this).removeClass('animate0 wobble');
                    });
                } else {
                    jQuery('.loginwrapper').addClass('animate0 fadeOutUp').bind(anievent, function () {
                        jQuery('#loginform').submit();
                    });
                }
                return false;
            }
        });
    });

    //    function preventback() 
    //    {
    //        window.history.forward(); 
    //    }
    //    settimeout("preventback()", 0);
    //    window.onunload = function () 
    //    {
    //        null
    //    };

    // Back Button Disable
    window.history.forward();
    function noBack() {
        window.history.forward();
    }

</script>
</html>
