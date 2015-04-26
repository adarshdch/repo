<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">

	<xsl:template match="Field">
		<tr>
			<td>
				<label>
					<xsl:attribute name="for">
						<xsl:value-of select="@sid"/>
					</xsl:attribute>
					<xsl:value-of select="@label"/>
				</label>
			</td>
			<td>
				<xsl:choose>
					<xsl:when test="@type='text'">
						<input type="text" data-dojo-type="dijit/form/ValidationTextBox">
							<xsl:attribute name="sid">
								<xsl:value-of select="@sid"/>
							</xsl:attribute>
							<xsl:attribute name="name">
								<xsl:value-of select="@sid"/>
							</xsl:attribute>
						</input>
					</xsl:when>
				</xsl:choose>
			</td>
		</tr>

	</xsl:template>
</xsl:stylesheet>