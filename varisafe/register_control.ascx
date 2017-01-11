<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="register_control.ascx.vb" Inherits="varisafe.register_control" %>
<%@ Register TagPrefix="recaptcha" Namespace="Recaptcha" Assembly="Recaptcha" %>

<div id="sidebar-register">
<div id="dvStep1" runat="server">
    <a href="register1.aspx?cid=1&step=2">Babysitters Course</a><br />
    <a href="register1.aspx?cid=2&step=2">Home Alone Course</a><br />
</div>

<div id="dvStep2" runat="server" visible="false">
    <label>Choose your Region</label>
    <asp:dropdownlist id="ddlRegion" runat="server" datatextfield="Region" datavaluefield="RegionID" autopostback="true"></asp:dropdownlist>
</div>

<div id="dvStep3" runat="server" visible="false">
    <label>Choose your City</label>
    <asp:dropdownlist id="ddlCity" runat="server" datatextfield="City" datavaluefield="City" autopostback="true"></asp:dropdownlist>
</div>

<div id="dvStep4" runat="server" visible="false">
    <asp:label id="lblNumCourses" runat="server"></asp:label>
    <asp:gridview id="dgCourses" runat="server" autogeneratecolumns="false" datakeynames="CourseID">
        <columns>
            <asp:boundfield datafield="City" headertext="City" />
            <asp:boundfield datafield="CourseDate" headertext="Date" />
            <asp:boundfield datafield="CourseID" visible="false" />
             <asp:boundfield datafield="CourseType" visible="false" />
              <asp:boundfield datafield="CourseDate" visible="false" />
              <asp:templatefield headertext="Location">
                <itemtemplate>
                    <asp:hyperlink id="lnkMap" runat="server" navigateurl='<%# Bind("MapLink") %>'>
                        <asp:label id="lblLocation" runat="server" text='<%# Bind("Location") %>'></asp:label>
                    </asp:hyperlink>
                </itemtemplate>
              </asp:templatefield>
            <asp:hyperlinkfield text="Register" headertext="Register" navigateurl="register1.aspx" datanavigateurlfields="CourseID,City,CourseType,CourseDate" datanavigateurlformatstring="register1.aspx?courseid={0}&city={1}&coursedate={3}&coursetype={2}&step=5" />
        </columns>
    </asp:gridview>
</div>

<div id="dvStep5" runat="server" visible="false">
    <h5>Registration Details</h5>
    <h6><asp:literal id="ltlCourseType" runat="server"></asp:literal> - <asp:literal id="ltlCity" runat="server"></asp:literal> - <asp:literal id="ltlCourseDate" runat="server"></asp:literal></h6>
    <div>
        <div class="row">
            <span class="labelwide">Child First * / Last *</span>
            <asp:textbox id="txtFirstName" runat="server"></asp:textbox>
            <asp:textbox id="txtLastName" runat="server"></asp:textbox>
            <asp:requiredfieldvalidator id="RequiredFieldValidator1" controltovalidate="txtFirstName" runat="server" errormessage="*"></asp:requiredfieldvalidator>
            <asp:requiredfieldvalidator id="RequiredFieldValidator2" controltovalidate="txtLastName" runat="server" errormessage="*"></asp:requiredfieldvalidator>
        </div>
        <div class="row">
            <span class="labelwide">Age *</span>
            <asp:textbox id="txtAge" runat="server"></asp:textbox>
            <asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" errormessage="*" controltovalidate="txtAge" display="Dynamic"></asp:requiredfieldvalidator>
            <asp:rangevalidator id="RangeValidator1" runat="server" errormessage="Invalid Age" controltovalidate="txtAge" display="Dynamic" maximumvalue="99" minimumvalue="8" type="Integer"></asp:rangevalidator>
        </div>
        <div class="row">
            <span class="labelwide">Emergency Phone *</span>
            <asp:textbox id="txtEmergPhone" runat="server"></asp:textbox>
            <asp:requiredfieldvalidator id="RequiredFieldValidator7" runat="server" errormessage="*" controltovalidate="txtEmergPhone" display="Dynamic"></asp:requiredfieldvalidator>
        </div>        
        <div class="row">
            <span class="labelwide">Email *</span>
            <asp:textbox id="txtEmail" runat="server" cssclass="txtlrg"></asp:textbox>
             <asp:requiredfieldvalidator id="RequiredFieldValidator6" runat="server" errormessage="*" controltovalidate="txtEmail" display="Dynamic"></asp:requiredfieldvalidator>
             <asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" errormessage="Invalid Email Format" controltovalidate="txtEmail" validationexpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:regularexpressionvalidator>
         </div>
          <div class="row">
            <span class="labelwide">Confirm Email *</span>
            <asp:textbox id="txtEmail2" runat="server" cssclass="txtlrg"></asp:textbox>
            <asp:comparevalidator id="valCompare" runat="server" errormessage="Emails do not match" controltovalidate="txtEmail" controltocompare="txtEmail2"></asp:comparevalidator>
         </div>
         <div class="row">
            <span class="labelwide">Known Allergies</span>
            <asp:textbox id="txtAllergies" textmode="multiline" runat="server"></asp:textbox>
        </div>
        <div class="row">
            <span class="labelwide">Health Concerns</span>
            <asp:textbox id="txtHealth" textmode="multiline" runat="server"></asp:textbox>
        </div>
        <div class="row">
            <span class="labelwide">Additional Comments</span>
            <asp:textbox id="txtComments" textmode="multiline" runat="server"></asp:textbox>
        </div>
        <div class="row">
            <span class="labelwide">Promo Code</span>
            <asp:textbox id="txtPromoCode" runat="server"></asp:textbox>
        </div> 
        <div class="row">
            <span class="labelwide">Parent First * / Last *</span>
            <asp:textbox id="txtParentFirst" runat="server"></asp:textbox>
            <asp:textbox id="txtParentLast" runat="server"></asp:textbox>
            <asp:requiredfieldvalidator id="RequiredFieldValidator4" controltovalidate="txtParentFirst" runat="server" errormessage="*"></asp:requiredfieldvalidator>
            <asp:requiredfieldvalidator id="RequiredFieldValidator5" controltovalidate="txtParentLast" runat="server" errormessage="*"></asp:requiredfieldvalidator>
        </div>
        <div class="row">
            <span class="labelwide">Home Phone *</span>
            <asp:textbox id="txtPhone" runat="server"></asp:textbox>
            <asp:requiredfieldvalidator id="RequiredFieldValidator8" runat="server" errormessage="*" controltovalidate="txtPhone" display="Dynamic"></asp:requiredfieldvalidator>
        </div>
        <div class="row">
            <span class="labelwide">Address *</span>
            <asp:textbox id="txtAddress" runat="server" cssclass="txtlrg"></asp:textbox>
            <asp:requiredfieldvalidator id="RequiredFieldValidator9" runat="server" errormessage="*" controltovalidate="txtAddress"></asp:requiredfieldvalidator>
        </div>
        <div class="row">
            <span class="labelwide">Address Line 2</span>
            <asp:textbox id="txtAddress2" runat="server" cssclass="txtlrg"></asp:textbox>
            &nbsp;
        </div>
        <div class="row">
            <span class="labelwide">City * / Province *</span>
            <asp:textbox id="txtCity" runat="server"></asp:textbox>
            <asp:dropdownlist id="ddlProvince" runat="server">
                <asp:listitem>AB</asp:listitem>
                <asp:listitem>BC</asp:listitem>
                <asp:listitem>MB</asp:listitem>
                <asp:listitem>NB</asp:listitem>
                <asp:listitem>NL</asp:listitem>
                <asp:listitem>NS</asp:listitem>
                <asp:listitem>NT</asp:listitem> 
                <asp:listitem>NU</asp:listitem> 
                <asp:listitem selected="true">ON</asp:listitem>
                <asp:listitem>PE</asp:listitem>
                <asp:listitem>QC</asp:listitem> 
                <asp:listitem>SK</asp:listitem>
                <asp:listitem>YT</asp:listitem>
              </asp:dropdownlist>
            <asp:requiredfieldvalidator id="RequiredFieldValidator10" runat="server" errormessage="*" controltovalidate="txtCity" display="Dynamic"></asp:requiredfieldvalidator></div>
        <div class="row">
            <span class="labelwide">Postal Code *</span>
            <asp:textbox id="txtPostalCode" runat="server"></asp:textbox>
            <asp:requiredfieldvalidator id="RequiredFieldValidator11" runat="server" controltovalidate="txtPostalCode"
                display="Dynamic" errormessage="*">*</asp:requiredfieldvalidator>
        </div>
        <div class="row">
            <span class="labelwide">School</span>
            <asp:dropdownlist runat="server" id="ddlSchool">
                <asp:listitem value="-Select">-Select-</asp:listitem>
                <asp:listitem value="Public School">Public School</asp:listitem>
                <asp:listitem value="Private School">Private School</asp:listitem>
                <asp:listitem value="Separate School">Separate School</asp:listitem>
            </asp:dropdownlist>
        </div>       
        <div class="row">
            <asp:Label Visible="false" ID="lblResult" runat="server" />
            <recaptcha:RecaptchaControl
              ID="recaptcha"
              runat="server"
              Theme="red" publickey="6LeRxNcSAAAAAHKggwLtZ6ODSbIRBHv_hjdYWMfE"
              privatekey="6LeRxNcSAAAAAOPnhBfhfti-X7_VlmrRQ4GsVjZl" />
               
        </div>
        
        <asp:literal id="ltlCourseTypeID" runat="server" visible="false"></asp:literal>
        <asp:literal id="ltlRegistrationID" runat="server" visible="false"></asp:literal>
        <input type="button" onclick="javascript:history.go(-1)" value="<< Back" />
        <asp:button id="btnSave" runat="server" text="Finish" />
    </div>
</div>
</div> 