<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ContactForm.ascx.vb" Inherits="varisafe.ContactForm" %>

<div class="whitebox">
<h2 class="contact">Contact Our Team</h2>

<div id="Divcontact" runat="server">

<div class="contactInputs">
			
			<div class="l">
			<label>Name:</label>
			<asp:TextBox id="txtname" runat="server" Columns="30"></asp:TextBox>
			<asp:RequiredFieldValidator ControlToValidate="txtname" ErrorMessage="Required" runat="server" ID="RequiredFieldValidator1"></asp:RequiredFieldValidator>
			<div class="clear"></div>
			</div>
		
			<div class="r">
			<label>Phone Number:</label>
			<asp:TextBox ID="txtphone" Runat="server"></asp:TextBox>
			<asp:RequiredFieldValidator ControlToValidate="txtphone" Runat="server" ID="Requiredfieldvalidator2"></asp:RequiredFieldValidator>
				<div class="clear"></div>
			</div>
			
			<div class="clear"></div>
			
			
			
			<div class="l">
			
			
			<label>Message:</label>
			
			<asp:TextBox ID="txtmessage" Runat="server" TextMode="MultiLine" Columns="40" Rows="6"></asp:TextBox>
			<asp:RequiredFieldValidator ControlToValidate="txtmessage" Runat="server" ErrorMessage="Required" ID="Requiredfieldvalidator4"></asp:RequiredFieldValidator>
			<div class="clear"></div></div>
			
			
			
			<div class="r">
			
			<label>Email Address:</label>
			<asp:textbox ID="txtemail" Runat="server" Columns="30"></asp:textbox>	
			<asp:RequiredFieldValidator ControlToValidate="txtemail" Runat="server" ErrorMessage="Required" ID="Requiredfieldvalidator3"></asp:RequiredFieldValidator>
			<asp:regularexpressionvalidator controltovalidate="txtEmail" validationexpression="\S+@\S+\.\S{2,3}" 
	runat="server" cssclass="validatorMessage" id="Regularexpressionvalidator1" text="Please enter a valid email address"  />
		
			</div>
			
			<asp:Button ID="btnsubmit" Text="Send" class="btn" Runat="server"></asp:Button>
			<div class="clear"></div>
			</div>
			
	</div>		


<a name="thankYou"></a>
<div id="divThankyou" runat="server" visible="false">
    <p></p>
			<p>Your message has been sent to the Vari SAFE Team.</p> 
			<p>Thank you for your interest, we will respond to your inquiry as soon as possible.</p>
	
	<p></p>
</div>

<div class="whiteboxBtm"></div></div>
