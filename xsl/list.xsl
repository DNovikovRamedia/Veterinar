<?xml version="1.0" encoding="utf-8"?>

<xsl:stylesheet version="1.0"
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:param name="appPath"/>

  <xsl:template match="List">
    <table class="items">
      <tr>
        <th>#</th>
        <th>Город</th>
        <th>Адрес</th>
        <th>Тип</th>
        <th>Материал</th>
        <th>Комнат</th>
        <th>Площадь</th>
        <th>Этажи</th>
        <th>Примечание</th>
        <th>Цена</th>
      </tr>
      <xsl:for-each select="//Item">
        <tr>
          <td align="right">
            <xsl:value-of select="@ID"/>
          </td>
          <td>
            <xsl:value-of select="@CityName"/>
          </td>
          <td>
            <xsl:value-of select="@Address"/>
          </td>
          <td>
            <xsl:value-of select="@Specific"/>
          </td>
          <td>
            <xsl:value-of select="@Material"/>
          </td>
          <td>
            <xsl:value-of select="@RoomCount"/>
          </td>
          <td>
            <xsl:if test="@SquareTotal != 0">
              <xsl:text disable-output-escaping="yes"><![CDATA[общ. ]]></xsl:text>
              <strong><xsl:value-of select="@SquareTotal"/></strong>
              <xsl:text disable-output-escaping="yes"><![CDATA[м<sup>2</sup>  ]]></xsl:text>
            </xsl:if>
            <xsl:if test="@SquareLiving != 0">
              <xsl:text disable-output-escaping="yes"><![CDATA[жил. ]]></xsl:text>
              <strong><xsl:value-of select="@SquareLiving"/></strong>
              <xsl:text disable-output-escaping="yes"><![CDATA[м<sup>2</sup>  ]]></xsl:text>
            </xsl:if>
            <xsl:if test="@SquareKitchen != 0">
              <xsl:text disable-output-escaping="yes"><![CDATA[кух. ]]></xsl:text>
              <strong><xsl:value-of select="@SquareKitchen"/></strong>
              <xsl:text disable-output-escaping="yes"><![CDATA[м<sup>2</sup>  ]]></xsl:text>
            </xsl:if>
            <xsl:if test="@SquareGround != 0">
              <xsl:text disable-output-escaping="yes"><![CDATA[зем. ]]></xsl:text>
              <strong><xsl:value-of select="@SquareGround"/></strong>
              <xsl:text disable-output-escaping="yes"><![CDATA[м<sup>2</sup>  ]]></xsl:text>
            </xsl:if>
          </td>
          <td>
            <xsl:if test="@Floor != 0">
              <strong><xsl:value-of select="@Floor"/></strong>
            </xsl:if>
            <xsl:if test="@FloorsTotal != 0">
              <span class="small">
                <xsl:text disable-output-escaping="yes"><![CDATA[/]]></xsl:text>
                <xsl:value-of select="@FloorsTotal"/>
              </span>
            </xsl:if>
          </td>
          <td>
            <xsl:value-of select="@Details"/>
          </td>
          <td align="right">
            <xsl:value-of select="@Price"/>
          </td>
        </tr>
      </xsl:for-each>
    </table>
  </xsl:template>

</xsl:stylesheet>