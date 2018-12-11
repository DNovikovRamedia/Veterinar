<?xml version="1.0" encoding="utf-8"?>

<xsl:stylesheet version="1.0"
   xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

  <xsl:param name="appPath"/>
  <xsl:output method="html"/>

  <xsl:template match="/List">
    <div class="news">
      <xsl:for-each select="NewsTitle">
        <div class="item">

          <xsl:if test="count(./Picture/@PictureUrl) != 0">
            <div class="img" style="float:left; width:175px;">
              <a href="{$appPath}/news/{@ID}.aspx">
                <img style="height:120px; margin: 0px 5px 5px 5px; border:2px #E9E9E9 solid;"  src="{$appPath}/i/news/{./Picture/@PreviewUrl}" align="left"/>
              </a>
              </div>           
          </xsl:if>

          <div class="date">
            <xsl:value-of select="@DateCreated" />
          </div>

          <div class="title">
            <a href="{$appPath}/news/{@ID}.aspx">
              <xsl:value-of select="@Name" />
            </a>
          </div>          

          <div class="brief">

            <xsl:value-of select="@Brief" />

          </div>

          <!--<xsl:if test="position() != last()">
            <div>
              <img src="{$appPath}/ii/newsdiv.gif" alt="" />
            </div>
          </xsl:if>-->
        </div>

        <div style="clear:both;"></div>

      </xsl:for-each>

    </div>

  </xsl:template>

</xsl:stylesheet>