<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Signup.aspx.vb" Inherits="CustomerAdmin_Signup" %>
<%@ Register TagPrefix="UControl" TagName="Menu" Src="~/Menu.ascx" %>
<%@ Register TagPrefix="UControl" TagName="Footer" Src="~/Footer.ascx" %>
<%@ Register TagPrefix="UControl" TagName="skin" Src="~/AddSkin.ascx" %>
<%@ Register TagPrefix="UControl" TagName="CustomerMenu" Src="AddCustomerSubMenu.ascx" %>
<%@ Register TagPrefix="Cart" Namespace="dotnetCART.Web.UI" Assembly="dotnetCART" %>
<%@ Register TagPrefix="Cart" TagName="Button" Src="CustomerAdminButton.ascx" %>
<%@ Register TagPrefix="Cart" TagName="Currency" Src="~/Currencies/CurrencyList.ascx" %>
<%@ Register TagPrefix="UControl" TagName="force_ssl" Src="~/force_ssl.ascx" %>

<%@ Import Namespace="dotnetCART" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>
        <%=dotnetCART.Strings.CustomerAdmin_Signup_PageTitle%></title>

       	<UControl:force_ssl ID="force_ssl1" runat="server"></UControl:force_ssl>
</head>

        <!-- Stylesheets -->
	<link href='<%= ResolveClientUrl("~/Styles/css/reset.css") %>' rel="stylesheet" media="screen" />
	<link href='<%= ResolveClientUrl("~/Styles/css/basics2.css") %>' rel="stylesheet" media="screen" />
	<link href='<%= ResolveClientUrl("~/Styles/css/default.css") %>' rel="stylesheet" media="screen" />
	<link href='<%= ResolveClientUrl("~/Styles/css/elements.css") %>' rel="stylesheet" media="screen" />

    
	<!-- Change this to get other skins, see the documentation -->
		<UControl:skin ID="skin1" runat="server"></UControl:skin>
	
	<link href='<%= ResolveClientUrl("~/Styles/css/jquery.fancybox-1.3.1.css") %>' rel="stylesheet" type="text/css" media="screen" />
		
	<!-- Bugfixes for IE -->
	<!--[if IE]><link href="Styles/css/ie.css" rel="stylesheet" type="text/css"><![endif]-->
	
	<!-- jQuery framework --> 
	<script type="text/javascript" src='<%= ResolveClientUrl("~/Styles/js/jquery-1.4.2.min.js") %>'></script>
	<script type="text/javascript" src='<%= ResolveClientUrl("~/Styles/js/jquery.easing.1.2.js") %>'></script>
	<script type="text/javascript" src='<%= ResolveClientUrl("~/Styles/js/superfish/hoverIntent.js") %>'></script>
	<script type="text/javascript" src='<%= ResolveClientUrl("~/Styles/js/superfish/jquery.bgiframe.min.js") %>'></script>
	
    <!--- dotnetButton -->

    <script type="text/javascript" src='<%= ResolveClientUrl("~/Styles/js/dotnetButton.js") %>'></script>

    
	<!-- Dropdown menu --> 
	<script type="text/javascript" src='<%= ResolveClientUrl("~/Styles/js/superfish/superfish.js") %>'></script>
	<script type="text/javascript" src='<%= ResolveClientUrl("~/Styles/js/superfish/supersubs.js") %>'></script>
	
	<!-- Custom javascript for this template -->
	<script type="text/javascript" src='<%= ResolveClientUrl("~/Styles/js/custom.js") %>'></script> 

    <link href="BlackIce/css/MainFont.css" rel="stylesheet" type="text/css" />
    <link href="BlackIce/css/Signup.css" rel="stylesheet" type="text/css" />
    <link href="BlackIce/Input/Input.css" rel="stylesheet" type="text/css" />
    <link href="BlackIce/ComboBox/combobox.css" type="text/css" rel="stylesheet" />
 <script type="text/javascript">
     $(document).ready(function() {
         if (navigator.userAgent.toLowerCase().indexOf("chrome") >= 0) {
             Form1.setAttribute("autocomplete", "off");
         }
     });
    </script>
<body>
<div id="wrapper">

    <div id="header-container">
	    <div id="top">
		    <UControl:Menu ID="menu" runat="server"></UControl:Menu>
	    <!-- end top -->
	    </div>
    </div>
	<div id="headerWrap" >
		<h1><%=dotnetCART.Strings.CustomerAdmin_Signup_PageTitle%></h1>
	<!-- end headerWrap -->
	</div>
	<div id="contentWrap">
		<div id="content" class="full-width" >
    <form id="Form1" runat="server">
                <fieldset class="fieldset">
                    <legend class="legendFont">
                        <%=dotnetCART.Strings.CustomerAdmin_Signup_LegendLabel%></legend>
                    <div class="field">
                        <span class="lbl labelFont">
                            <%=dotnetCART.Strings.CustomerAdmin_Signup_FirstName%></span>
                        <Cart:MaskedInput runat="server" ID="InputFirstName" Text="" CssClass="valid" EmptyCssClass="empty"
                            FocusedValidCssClass="focused-valid" FocusedCssClass="focused" InvalidCssClass="invalid"
                            DisabledCssClass="disabled" />
                    </div>
                    <div class="field">
                        <span class="lbl labelFont">
                            <%=dotnetCART.Strings.CustomerAdmin_Signup_LastName%></span>
                        <Cart:MaskedInput runat="server" ID="InputLastName" Text="" CssClass="valid" EmptyCssClass="empty"
                            FocusedValidCssClass="focused-valid" FocusedCssClass="focused" InvalidCssClass="invalid"
                            DisabledCssClass="disabled" />
                    </div>
                    <div class="field">
                        <span class="lbl labelFont">
                            <%=dotnetCART.Strings.CustomerAdmin_Signup_Email %></span>
                        <Cart:MaskedInput runat="server" ID="InputEmail" Text="" CssClass="valid" EmptyCssClass="empty"
                            FocusedValidCssClass="focused-valid" FocusedCssClass="focused" InvalidCssClass="invalid"
                            DisabledCssClass="disabled" Transform="EmailAddress" />
                        <asp:RequiredFieldValidator ID="InputEmail_Validator" runat="server" ControlToValidate="InputEmail"
                            CssClass="validator_message labelFont" Display="Dynamic" />
                        <asp:RegularExpressionValidator ID="EmailInput_RegExValidator" runat="server" ControlToValidate="InputEmail"
                            CssClass="validator_message labelFont" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            Display="Dynamic" />
                    </div>
                    <div class="field">
                        <span class="lbl labelFont">
                            <%=dotnetCART.Strings.CustomerAdmin_Signup_Password%></span>
                        <Cart:MaskedInput runat="server" ID="InputPassword" Text="" EmptyText="Password" CssClass="valid"
                            EmptyCssClass="empty" FocusedValidCssClass="focused-valid" FocusedCssClass="focused"
                            InvalidCssClass="invalid" DisabledCssClass="disabled" TextMode="Password" />
                        <asp:RequiredFieldValidator ID="InputPassword_Validator" runat="server" ControlToValidate="InputPassword"
                            CssClass="validator_message labelFont" />
                    </div>
                    <div class="field">
                        <span class="lbl labelFont">
                            <%=dotnetCART.Strings.CustomerAdmin_Signup_PasswordConfirm%></span>
                        <Cart:MaskedInput runat="server" ID="InputPasswordConfirm" Text="" EmptyText="Password"
                            CssClass="valid" EmptyCssClass="empty" FocusedValidCssClass="focused-valid" FocusedCssClass="focused"
                            InvalidCssClass="invalid" DisabledCssClass="disabled" TextMode="Password" />
                        <asp:CompareValidator ID="InputPasswordConfirm_Validator" ControlToValidate="InputPassword"
                            ControlToCompare="InputPasswordConfirm" CssClass="validator_message labelFont"
                            Type="String" runat="server" Display="Dynamic" />
                    </div>
                    <div class="field">
                        <span class="lbl labelFont">
                            <%=dotnetCART.Strings.CustomerAdmin_Signup_Company %></span>
                        <Cart:MaskedInput runat="server" ID="InputCompany" Text="" CssClass="valid" EmptyCssClass="empty"
                            FocusedValidCssClass="focused-valid" FocusedCssClass="focused" InvalidCssClass="invalid"
                            DisabledCssClass="disabled" />
                    </div>
                    <div class="field">
                        <span class="lbl labelFont">
                            <%=dotnetCART.Strings.CustomerAdmin_Signup_Phone%></span>
                        <Cart:MaskedInput runat="server" ID="InputPhone" Text="" CssClass="valid" EmptyCssClass="empty"
                            FocusedValidCssClass="focused-valid" FocusedCssClass="focused" InvalidCssClass="invalid"
                            DisabledCssClass="disabled" />
                    </div>
                    <div class="field">
                        <span class="lbl labelFont">
                            <%=dotnetCART.Strings.CustomerAdmin_Signup_Currency%></span>
                        <div>
                            <Cart:Currency ID="Customer_Currency" ImageFolder="~/Currencies/images/" runat="server" />
                        </div>
                        <div class="lblRight">
                            <img src="images/headline_help.gif" style="vertical-align: middle" alt="Your display currency"
                                title="<%=dotnetCART.Strings.CustomerAdmin_Currency_HelpStringMessage %><% =dotnetCART.Store.Settings.Currency.Base %>." /></div>
                    </div>
                    <div class="field">
                        <span class="lbl labelFont">
                            <%=dotnetCART.Strings.CustomerAdmin_CustomerSettings_Language%></span>
                        <Cart:ComboBox ID="Customer_Language" runat="server" DataTextField="NativeName" DataValueField="Name"
                            CssClass="comboBox" HoverCssClass="comboBoxHover" FocusedCssClass="comboBoxHover"
                            TextBoxCssClass="comboTextBox" DropDownCssClass="comboDropDown" ItemCssClass="comboItem"
                            ItemHoverCssClass="comboItemHover" SelectedItemCssClass="comboItemHover" DropHoverImageUrl="BlackIce/ComboBox/images/drop_hover.gif"
                            DropImageUrl="BlackIce/ComboBox/images/drop.gif" DropDownHeight="50" Width="220"
                            SelectedIndex="0" />
                    </div>
                    <div class="ButtonSignup">
                        <Cart:Button ID="SingUp" runat="server" Button-Width="88px" Button-GenerateJavaScript="True" />
                        <Cart:Button ID="CancelBackToCheckout" runat="server" Visible="false" Button-Width="88px"
                            Button-PostBackUrl="~/Checkout.aspx" Button-CausesValidation="false" />
                    </div>
                </fieldset>
                <asp:Label ID="dotnetCARTmessage" CssClass="error_message labelFont" runat="server"
                    Text=""></asp:Label>
          
    </form>
    </div>

    <!-- end contentWrap -->
	</div>
	
    
  <UControl:Footer ID="FooterControl" runat="server"></UControl:Footer>
	
<!-- end wrapper / end of document -->
</div>
 
 <script type="text/javascript">

     // hightlight the menu
     $('#menu_customerAdmin').addClass('current');

  <UControl:CustomerMenu ID="CustomerMenu" runat="server"></UControl:CustomerMenu>
     
 </script>

    
	
           
    
</body>
</html>
