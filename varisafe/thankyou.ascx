<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="thankyou.ascx.vb" Inherits="varisafe.thankyou" %>

<div>
    <p>Thank you for your online registration, we will be sending you a course confirmation message within 
    the next 10 minutes with the following; course location and address, pick-up and drop-off 
    times for your student, what to bring and how to make payment the morning of the course.  
    If you do not receive a reply within 2 business days, please first check your Junk email folder and if necessary, contact us at 
    <a href="mailto:register@varisafe.ca">register@varisafe.ca</a> or toll free at (866) 974-7488
    </p>
    <p>
    <a href="http://www.facebook.com/VariSAFE">LIKE US on FACEBOOK</a> or 
    <a href="https://twitter.com/VariSafeEdu">FOLLOW US on TWITTER</a> for a chance to win a free course registration for your child, or to 
    donate a space to another child in need.
    </p>
    <h4>Registration Details</h4>
    
    <div id="dvThankYou">
    <div class="row">
        <span class="labelwide">Confirmation #</span>
         <asp:label runat="server" id="lblRegistrationID"></asp:label>
    </div>
    <div class="row">
            <span class="labelwide">Child First / Last:</span>
            <asp:label id="txtFirstName" runat="server"></asp:label>
            <asp:label id="txtLastName" runat="server"></asp:label>
        </div>
       
        <div class="row">
            <span class="labelwide">Age:</span>
            <asp:label id="txtAge" runat="server"></asp:label>
        </div>
        <div class="row">
            <span class="labelwide">Email:</span>
            <asp:label id="txtEmail" runat="server" cssclass="txtlrg"></asp:label>
         </div>
        <div class="row">
            <span class="labelwide">Emergency Phone:</span>
            <asp:label id="txtEmergPhone" runat="server"></asp:label>
        </div>
        <div class="row">
            <span class="labelwide">Known Allergies:</span>
            <asp:label id="txtAllergies" runat="server"></asp:label>
        </div>
        <div class="row">
            <span class="labelwide">Health Concerns:</span>
            <asp:label id="txtHealth" runat="server"></asp:label>
        </div>
        <div class="row">
            <span class="labelwide">Additional Comments:</span>
            <asp:label id="txtComments" runat="server"></asp:label>
        </div>
        <div class="row">
            <span class="labelwide">Promo Code:</span>
            <asp:label id="lblPromoCode" runat="server"></asp:label>
        </div>
        <div class="row">
            <span class="labelwide">Parent First / Last:</span>
            <asp:label id="txtParentFirst" runat="server"></asp:label>
            <asp:label id="txtParentLast" runat="server"></asp:label>
        </div>
         
        <div class="row">
            <span class="labelwide">Phone:</span>
            <asp:label id="txtPhone" runat="server"></asp:label>
        </div>
        <div class="row">
            <span class="labelwide">Address:</span>
            <asp:label id="txtAddress" runat="server" cssclass="txtlrg"></asp:label>
        </div>
        <div class="row">
            <span class="labelwide">Address Line 2:</span>
            <asp:label id="txtAddress2" runat="server" cssclass="txtlrg"></asp:label>
            &nbsp;
        </div>
        <div class="row">
            <span class="labelwide">City / Province:</span>
            <asp:label id="txtCity" runat="server"></asp:label>
            <asp:label id="lblProvince" runat="server"></asp:label>
        </div>
        <div class="row">
            <span class="labelwide">Postal Code:</span>
            <asp:label id="txtPostalCode" runat="server"></asp:label>
        </div> 
        <div class="row">
            <span class="labelwide">School:</span>
            <asp:label runat="server" id="ddlSchool"></asp:label>
        </div>
    </div>
</div>
