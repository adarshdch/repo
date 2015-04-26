<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
	<xsl:template match="Buttons">
		<tr>
			<td></td>
			<td colspan="*">
				<xsl:apply-templates/>
			</td>
		</tr>
	</xsl:template>
	<xsl:template name="Button" match="Button[not(@visible)]">
		<button>
			<xsl:attribute name="data-dojo-type">
				<xsl:text>dijit/form/Button</xsl:text>
			</xsl:attribute>
			<xsl:attribute name="type">
				<xsl:choose>
					<xsl:when test="@type">
						<xsl:value-of select="@type"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:text>button</xsl:text>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:attribute>
			<xsl:value-of select="@label"/>
			<xsl:choose>
				<xsl:when test="not(Script)">
					<script type="dojo/on" data-dojo-event="click" data-dojo-args="evt">
						this.getParent().submit();
					</script>
				</xsl:when>
			</xsl:choose>
			<xsl:apply-templates/>
		</button>
	</xsl:template>

	<xsl:template match="Script">
		<script type="dojo/on" data-dojo-args="evt">
			<xsl:attribute name="data-dojo-event">
				<xsl:choose>
					<xsl:when test="@event">
						<xsl:value-of select="@event"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:text>click</xsl:text>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:attribute>
			<xsl:value-of disable-output-escaping="yes" select="."/>
		</script>
	</xsl:template>

</xsl:stylesheet>
