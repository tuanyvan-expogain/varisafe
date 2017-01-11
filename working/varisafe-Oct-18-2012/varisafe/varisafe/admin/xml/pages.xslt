<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:output method="html"/>

	<xsl:template match="pages">

	<ul>
		<li>	
			<a href="page.aspx?pid={pageID}">
				<xsl:apply-templates select="pageName"></xsl:apply-templates>
			</a>
			<xsl:apply-templates select="pages"></xsl:apply-templates>
		</li>			
	</ul>
</xsl:template>
</xsl:stylesheet>

  