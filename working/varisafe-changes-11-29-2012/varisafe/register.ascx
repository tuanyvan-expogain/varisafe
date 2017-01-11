<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="register.ascx.vb" Inherits="varisafe.register" %>
<%@ Register TagPrefix="recaptcha" Namespace="Recaptcha" Assembly="Recaptcha" %>

<h4>Course Registration</h4>
<div id="sidebar-register">
<div id="dvStep1" runat="server">
    <label>Choose your Course</label>
    <a href="registration.aspx?cid=1&step=2"><img src="img/babysitters.jpg" alt="Babysitters Course" /></a>
    <a href="registration.aspx?cid=2&step=2"><img src="img/homealone.jpg" alt="Home Alone Course" /></a>
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
    <asp:gridview id="dgCourses" runat="server" autogeneratecolumns="false" datakeynames="CourseID" CssClass="table table-striped table-bordered">
        <columns>
            <asp:boundfield datafield="City" headertext="City" />
            <asp:templatefield headertext="Date">
                <itemtemplate>
                    <asp:literal id="ltlCourseDate" runat="server" text='<%# Bind("CourseDate") %>'></asp:literal>
                    <strong><asp:literal id="ltlCourseName" runat="server" text='<%# Bind("CourseName") %>'></asp:literal></strong>
                </itemtemplate>
            </asp:templatefield>
            <asp:boundfield datafield="CourseID" visible="false" />
            <asp:boundfield datafield="CourseType" visible="false" />
            <asp:boundfield datafield="CourseDate" visible="false" />
            <asp:templatefield visible="false">
                <itemtemplate>
                    <asp:literal id="ltlRegistrations" runat="server" text='<%# Bind("Registered") %>'></asp:literal>
                </itemtemplate>
            </asp:templatefield>
            <asp:templatefield visible="false">
                <itemtemplate>
                    <asp:literal id="ltlCapacity" runat="server" text='<%# Bind("Capacity") %>'></asp:literal>
                </itemtemplate>
            </asp:templatefield>
            <asp:templatefield headertext="Location">
                <itemtemplate>
                    <asp:hyperlink id="lnkMap" runat="server" navigateurl='<%# Bind("MapLink") %>'>
                        <asp:label id="lblLocation" runat="server" text='<%# Bind("Location") %>'></asp:label>
                    </asp:hyperlink>
                </itemtemplate>
            </asp:templatefield>
            <asp:hyperlinkfield text="Register" headertext="Register" navigateurl="registration.aspx" datanavigateurlfields="CourseID,City,CourseType,CourseDate" datanavigateurlformatstring="registration.aspx?courseid={0}&city={1}&coursedate={3}&coursetype={2}&step=5" />
        </columns>
    </asp:gridview>
</div>

<div id="dvStep5" runat="server" visible="false">

    <h4><asp:literal id="ltlCourseType" runat="server"></asp:literal> - <asp:literal id="ltlCity" runat="server"></asp:literal> - <asp:literal id="ltlCourseDate" runat="server"></asp:literal></h4>
    <div id="dvWait" runat="server" visible="false">
        <p>Hello, unfortunately the particular course date and location you have selected is FULL TO CAPACITY and we are unable to 
        reserve a space for your student at this time.  We do limit our class sizes to maintain a safe, and effective 
        learning environment with increased student to instructor interaction.</p>
        <p>If you would like - we are able to hold your registration request in queue, and in the event of a 
        cancellation – we will provide you with a confirmation email if a space should become available for 
        your student.  Cancellations may occur, however they are generally during the week leading up to the 
        course date.</p>    
        <p>Please complete the form below to add your request to our Waiting List</p>
        <p>Alternatively, you may return to our <a href="registration.aspx">main registration page</a>
         to select an alternative date with available space.</p>
        <p>
        We thank you for your interest in our programming, and appreciate your understanding in limiting course sizes.</p>
    </div>
    
    <div>
        <div class="row control-group">        
            <span class="labelwide control-label">Child First Name *</span>
            <div class="controls">
            <asp:textbox id="txtFirstName" runat="server"></asp:textbox>            
                <asp:requiredfieldvalidator id="RequiredFieldValidator1" controltovalidate="txtFirstName" runat="server" errormessage="*" CssClass="help-inline"></asp:requiredfieldvalidator>            
            </div> 
        </div>
        <div class="row control-group">
            <span class="labelwide control-label">Child Last Name *</span>
            <div class="controls">
                <asp:textbox id="txtLastName" runat="server"></asp:textbox>
                <asp:requiredfieldvalidator id="RequiredFieldValidator2" controltovalidate="txtLastName" runat="server" errormessage="*" CssClass="help-inline"></asp:requiredfieldvalidator>
            </div>
        </div>
        <div class="row control-group">
            <span class="labelwide control-label">Age *</span>
            <div class="controls">
            <asp:textbox id="txtAge" runat="server"></asp:textbox>
            <asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" errormessage="*" CssClass="help-inline" controltovalidate="txtAge" display="Dynamic"></asp:requiredfieldvalidator>
            <asp:rangevalidator id="RangeValidator1" runat="server" errormessage="Invalid Age" controltovalidate="txtAge" display="Dynamic" maximumvalue="99" minimumvalue="8" type="Integer"></asp:rangevalidator>
            </div> 
        </div>
        <div class="row control-group">
            <span class="labelwide control-label">Emergency Phone *</span>
            <div class="controls">
            <asp:textbox id="txtEmergPhone" runat="server"></asp:textbox>
            <asp:requiredfieldvalidator id="RequiredFieldValidator7" runat="server" errormessage="*" CssClass="help-inline" controltovalidate="txtEmergPhone" display="Dynamic"></asp:requiredfieldvalidator>
            </div> 
        </div>        
        <div class="row control-group">
            <span class="labelwide control-label">Email *</span>
            <div class="controls">
            <asp:textbox id="txtEmail" runat="server" cssclass="txtlrg"></asp:textbox>
             <asp:requiredfieldvalidator id="RequiredFieldValidator6" runat="server" errormessage="*" CssClass="help-inline" controltovalidate="txtEmail" display="Dynamic"></asp:requiredfieldvalidator>
             <asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" errormessage="Invalid Email Format" controltovalidate="txtEmail" validationexpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:regularexpressionvalidator>
             </div> 
         </div>
          <div class="row control-group">
            <span class="labelwide control-label">Confirm Email *</span>
            <div class="controls">
            <asp:textbox id="txtEmail2" runat="server" cssclass="txtlrg"></asp:textbox>
            <asp:comparevalidator id="valCompare" runat="server" errormessage="Emails do not match" controltovalidate="txtEmail" controltocompare="txtEmail2"></asp:comparevalidator>
            </div> 
         </div>
         <div class="row control-group">
            <span class="labelwide control-label">Known Allergies</span>
            <div class="controls">
            <asp:textbox id="txtAllergies" textmode="multiline" runat="server"></asp:textbox>
            </div> 
        </div>
        <div class="row control-group">
            <span class="labelwide control-label">Health Concerns</span>
            <div class="controls">
            <asp:textbox id="txtHealth" textmode="multiline" runat="server"></asp:textbox>
            </div> 
        </div>
        <div class="row control-group">
            <span class="labelwide control-label">Additional Comments</span>
            <div class="controls">
            <asp:textbox id="txtComments" textmode="multiline" runat="server"></asp:textbox>
            </div> 
        </div>
        <div class="row control-group">
            <span class="labelwide control-label">Promo Code</span>
            <div class="controls">
            <asp:textbox id="txtPromoCode" runat="server"></asp:textbox>
            </div> 
        </div> 
        <div class="row control-group">
            <span class="labelwide control-label">Parent First Name *</span>
            <div class="controls">
            <asp:textbox id="txtParentFirst" runat="server"></asp:textbox>            
            <asp:requiredfieldvalidator id="RequiredFieldValidator4" controltovalidate="txtParentFirst" runat="server" errormessage="*" CssClass="help-inline"></asp:requiredfieldvalidator>            
            </div> 
        </div>
        <div class="row control-group">
            <span class="labelwide control-label">Parent Last Name *</span>
            <div class="controls">
                <asp:textbox id="txtParentLast" runat="server"></asp:textbox>
                <asp:requiredfieldvalidator id="RequiredFieldValidator5" controltovalidate="txtParentLast" runat="server" errormessage="*" CssClass="help-inline"></asp:requiredfieldvalidator>
            </div> 
        </div>        
        <div class="row control-group">
            <span class="labelwide control-label">Home Phone *</span>
            <div class="controls">
            <asp:textbox id="txtPhone" runat="server"></asp:textbox>
            <asp:requiredfieldvalidator id="RequiredFieldValidator8" runat="server" errormessage="*" CssClass="help-inline" controltovalidate="txtPhone" display="Dynamic"></asp:requiredfieldvalidator>
            </div> 
        </div>
        <div class="row control-group">
            <span class="labelwide control-label">Address *</span>
            <div class="controls">
            <asp:textbox id="txtAddress" runat="server" cssclass="txtlrg"></asp:textbox>
            <asp:requiredfieldvalidator id="RequiredFieldValidator9" runat="server" errormessage="*" CssClass="help-inline" controltovalidate="txtAddress"></asp:requiredfieldvalidator>
            </div> 
        </div>
        <div class="row control-group">
            <span class="labelwide control-label">Address Line 2</span>
            <div class="controls">
            <asp:textbox id="txtAddress2" runat="server" cssclass="txtlrg"></asp:textbox>
            &nbsp;
            </div> 
        </div>
        <div class="row control-group">
            <span class="labelwide control-label">City * / Province *</span>
            <div class="controls">
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
            <asp:requiredfieldvalidator id="RequiredFieldValidator10" runat="server" errormessage="*" CssClass="help-inline" controltovalidate="txtCity" display="Dynamic"></asp:requiredfieldvalidator>
            </div> 
        </div>
        <div class="row control-group">
            <span class="labelwide control-label">Postal Code *</span>
            <div class="controls">
            <asp:textbox id="txtPostalCode" runat="server"></asp:textbox>
            <asp:requiredfieldvalidator id="RequiredFieldValidator11" runat="server" controltovalidate="txtPostalCode"
                display="Dynamic" errormessage="*" CssClass="help-inline">*</asp:requiredfieldvalidator>
            </div> 
        </div>
        <div class="row control-group">
            <span class="labelwide control-label">School</span>
            <div class="controls">
            <asp:dropdownlist runat="server" id="ddlSchool">
                <asp:listitem value="-Select">-Select-</asp:listitem>
                <asp:listitem value="Public School">Public School</asp:listitem>
                <asp:listitem value="Private School">Private School</asp:listitem>
                <asp:listitem value="Separate School">Separate School</asp:listitem>
            </asp:dropdownlist>
            </div> 
        </div>       
        <div class="row control-group">
            <asp:Label Visible="false" ID="lblResult" runat="server" CssClass="control-label" />
            <div class="controls">         
            <recaptcha:RecaptchaControl
              ID="recaptcha"
              runat="server"
              Theme="red" publickey="6LeRxNcSAAAAAHKggwLtZ6ODSbIRBHv_hjdYWMfE"
              privatekey="6LeRxNcSAAAAAOPnhBfhfti-X7_VlmrRQ4GsVjZl" />
            </div>
        </div>  
        <div class="row control-group">
            <span class="labelwide control-label">Terms and Conditions</span>
            <div class="controls">         
              <div id="dvTOC">
                <h6 class="underline">Student Behaviour Policy and Parent/Guardian Consent</h6>
                <p>In order to complete your registration, you will be required to read and agree to the following;</p>
                <h6 class="underline">Student Behaviour Policy</h6>
                <p>To provide a healthy, safe and productive learning environment for all, students who attend our programs are responsible for their own conduct and behaviours, the following ARE NOT acceptable for any participant;</p>
                <ul>
                  <li>Endangering the health and safety of other students and /or instructors</li>
                  <li>Use of profanity or lewd gestures</li>
                  <li> Bullying, teasing, stealing or damaging property</li>
                  <li> Any violent behavior or inappropriate contact with another individual</li>
                  <li> Actions which serve to disrupt the program</li>
                </ul>
                <p>If a student conducts themselves in any manner as above, one or more of the following may occur:</p>
                <ol>
                  <li>Instructors will redirect the student to a more appropriate behaviour, and students will be reminded of the behaviour guidelines and program rules.</li>
                  <li>If the inappropriate behaviour continues, Vari SAFE Education reserves the right to contact the parent/guardian to pick up their child. </li>
                </ol>
                <p><strong>PLEASE NOTE:</strong>  If a student’s behavior at any time threatens the immediate safety of another student or instructor, Vari SAFE will contact the parent/guardian immediately to remove the student from the program.  Reasons for immediate removal include bullying, any incident of hitting, biting, or any other unwanted physical contact.</p>
                <h6 class="underline">Parent or Guardians Consent and Assumption of Responsibility</h6>
                <p>I understand that student participation in the Kidsitters Canada Babysitters training course, or the Home Alone and Stranger Safety course does not guarantee or override the following:</p>
                <ul>
                  <li>It is <strong class="underline">MY</strong> <strong>RESPONSIBILITY AS A PARENT OR GUARDIAN</strong> to ensure the safety and wellbeing of my child at all times, including making the decision as to when they are fit and prepared to be Home Alone, OR when they are prepared and of legal minimum age to be responsible as a Babysitter with the care and wellbeing of another child. </li>
                  <li>The <strong>HOME ALONE AND STRANGER SAFETY PROGRAM</strong> is an excellent course to prepare students, and provide them with skills and ideas to safely stay Home Alone, but ultimately <strong class="underline">IT IS MY DECISION AS THEIR PARENT OR GUARDIAN</strong> as to when they are ready. </li>
                  <li>Completion of the Home Alone and Stranger Safety program does not guarantee or override your judgement as to when a student is ready to stay Home Alone.  Many factors, including the students level of maturity, the time of day, length of time and emergency support immediately available to the student are different in every circumstance, and it is the responsibility of the parent or guardian to make the decision WITH their child as to when they are ready and properly supported to take on this new responsibility.</li>
                  <li> The <strong>KIDSITTERS CANADA BABYSITTERS TRAINING PROGRAM</strong> is an excellent course to prepare students for the exciting responsibility of Babysitting.  Vari SAFE Education strongly encourages all parents and guardians to help new Babysitters through practice, helping with younger siblings and supervised Babysitting until they are ready for this new responsibility on their own.</li>
                  <li>Students who participate in the Kid Sitters Canada Babysitters course <strong>must be of legal minimum age prior to being left in the sole care and control of another child</strong> (specific to your region, the legal minimum age is generally 12 or 13 years of age – older with respect to infant care).</li>
                </ul>
              </div>
              <br />
              <p><strong>I have read and understood the above.</strong></p>
              <p><strong>I will discuss student behaviour with my child prior to the course.</strong></p>
              <p><strong>I acknowledge my responsibility as a parent or guardian, and will be ultimately responsible for my child with respect to staying home alone or babysitting another individual.</strong></p>
              <asp:CheckBox ID="chkTOC" runat="server" /><span id="agreeTOC">I agree to the terms and conditions<asp:CustomValidator runat="server" ID="CheckBoxRequired" ErrorMessage=" - You must agree to the terms and conditions" OnServerValidate="CheckBoxRequired_ServerValidate" ClientValidationFunction="CheckBoxRequired_ClientValidate"> - You must agree to the terms and conditions</asp:CustomValidator></span>                            
            </div>
        </div>
        
        <div class="form-actions">
        <asp:literal id="ltlCourseTypeID" runat="server" visible="false"></asp:literal>
        <asp:literal id="ltlRegistrationID" runat="server" visible="false"></asp:literal>
        <button type="button" onclick="javascript:history.go(-1)" value="<< Back" class="btn"><< Back</button>
        <asp:button id="btnSave" runat="server" text="Finish" CssClass="btn btn-warning" />
        </div>
    </div>
</div>
</div> 