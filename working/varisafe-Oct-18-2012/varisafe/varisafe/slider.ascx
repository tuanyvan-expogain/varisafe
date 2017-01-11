<%@ Control Language="vb" AutoEventWireup="false" Codebehind="slider.ascx.vb" Inherits="varisafe.slider" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>

<div class="" id="recentNews">

    <h4 id="recentNewsHeader">
    Recent News
    </h4>

    <ul id="news">
        <asp:repeater runat="server" id="rptFeaturedNews">
            <itemtemplate>
                <li>
		            <p>            		            
	                    <i class="icon-calendar"></i>
                        <span class="date">
                            <asp:Label runat="server" ID="lblMonth" CssClass="month" Text='<%#DataBinder.Eval(Container.DataItem, "mn") %>'></asp:Label>
                            <asp:Label runat="server" ID="lblDay" cssclass="day" Text='<%#DataBinder.Eval(Container.DataItem, "dy") %>'></asp:Label>
	                    </span> -
    			        <a class="newsTitle" href="newsdetail.aspx?nid=<%#DataBinder.Eval(Container.DataItem, "newsID")%>">
	                        <asp:Label  ID="lblTitle" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "title") %>'></asp:Label>
	                    </a> 				                
                        <br />
	                    <asp:literal runat="server" id="ltlShortDescription" text='<%#DataBinder.Eval(Container.DataItem, "shortdesciption")%>'></asp:literal>  
	                </p>
                </li>
            </itemtemplate>
        </asp:repeater>
    </ul>
    <a class="more" href="news.aspx">more...</a>
</div>