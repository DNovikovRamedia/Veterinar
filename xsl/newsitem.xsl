<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0"
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="html"/>
  <xsl:param name="appPath"/>

  <xsl:template name="main" match="//NewsTitle">
    <xsl:if test="count(./Picture/@PictureUrl) != 0">
      <img src="{$appPath}/i/news/{./Picture/@PictureUrl}" 
        style="border: black 0px solid; margin: 0px 10px 10px 0px; height:200px;" align="left"/>
    </xsl:if>

    <div style="margin-bottom: 7px;">
      <xsl:value-of select="@DateCreated" />
    </div>

    <xsl:if test="string-length(@Brief) != 0">
      <div>
        <b>
          <xsl:value-of select="@Brief" disable-output-escaping="yes"/>
        </b>
      </div>
    </xsl:if>

    <xsl:value-of select="@Content" disable-output-escaping="yes"/>

    <xsl:if test="count(./Pictures/Picture) != 0">
      <h2>Фотографии</h2>
    </xsl:if>
    <xsl:for-each select="./Pictures/Picture">
      <a class="fancy" rel="news"  href="{$appPath}/i/news/{./@PictureUrl}">
        <img src="{$appPath}/i/news/{./@PreviewUrl}" style="border:2px #E9E9E9 solid; height:100px; margin: 0px 21px 10px 0px; float: left;" />
      </a>
    </xsl:for-each>

  </xsl:template>
</xsl:stylesheet>