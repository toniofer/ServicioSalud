<?xml version='1.0'?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

  <xsl:template match="/">
    <html>
      <head>
        <title>GeneXus Developer Menu</title>
        <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1"/>
        <link rel="stylesheet" type="text/css">
          <xsl:attribute name="href">
            sp.css
          </xsl:attribute>          
        </link>
        <style type="text/css">
        </style>
      </head>
      <body >
              <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                  <td valign="top">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="#FFFFFF">
                      <tr>
												<td>
													<img src="logo.gif" width="200" height="50"/>
												</td>
												<td align="right">
													<img src="cabezal.png" width="298" height="50"/>
												</td>
											</tr>
                    </table>
                  </td>
                </tr>
                <tr>
                  <td valign="top" style="height: 19px">
                    &#160;
                  </td>
                </tr>
                <tr>
                  <td valign="top">
                    <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
                      <tr>
                        <td width="10">
                          &#160;
                        </td>
                        <td>
                          <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                              <td width="10" style="height: 24px">
                                <img width="10" height="24px"><xsl:attribute name="src">top_izq.gif</xsl:attribute></img>
                              </td>
                              <td style="height: 24px"><xsl:attribute name="background">bg_tops.gif</xsl:attribute>                            
                                <table width="100%" border="0" cellspacing="0" cellpadding="0" margin="10px">
                                  <tr>
                                    <td nowrap="yes" class="txtTitulos">
                                      <strong>Developer Menu</strong>
                                    </td>
                                    <td class="txtTitulos"></td>
                                  </tr>
                                </table>
                              </td>
                              <td width="10" style="height: 24px">
                                <img width="10" height="24px"><xsl:attribute name="src">top_der.gif</xsl:attribute></img>
                              </td>
                            </tr>
                            <tr>
                              <td><xsl:attribute name="background">margin_left.gif</xsl:attribute>&#160;</td>
                              <td  height="100%">                                
                                  <xsl:apply-templates select="/Objects"/>                               
                              </td>
                              <td>
                                <xsl:attribute name="background">margin_right.gif</xsl:attribute>
                                &#160;
                              </td>
                            </tr>
                            <tr>
                              <td>
                                <img width="10" height="19"><xsl:attribute name="src">codo_izq_foot.gif</xsl:attribute></img>
                              </td>
                              <td>
                                <xsl:attribute name="background">foot_middle.gif</xsl:attribute>
                              </td>
                              <td>
                                <img width="10" height="19"><xsl:attribute name="src">codo_der_foot.gif</xsl:attribute></img>
                              </td>
                            </tr>
                          </table>
                        </td>
                        <td width="10">
                          &#160;
                        </td>
                      </tr>
                    </table>
                  </td>
                </tr>
              </table>
      </body>
    </html>
</xsl:template>

<xsl:template match="Objects">
	<xsl:apply-templates select="//Object"/>
		
	
</xsl:template>

<xsl:template match="Object">
	
		<TABLE><TR><TD><IMG style="CURSOR: hand" height="13" width="17">
<xsl:attribute name="src">

<xsl:if test="ObjCls=0">transaction.ico</xsl:if>
<xsl:if test="ObjCls=1">procedure.ico</xsl:if>
<xsl:if test="ObjCls=2">report.ico</xsl:if>
<xsl:if test="ObjCls=12">prompt.ico</xsl:if>
<xsl:if test="ObjCls=13">webpanel.ico</xsl:if>
<xsl:if test="ObjCls=17">mbr.ico</xsl:if>
</xsl:attribute></IMG></TD><TD>
<A class="txtTitulos"><xsl:attribute name="href"><xsl:value-of select="ObjLink"/></xsl:attribute><xsl:value-of select="ObjDesc"/></A></TD></TR></TABLE>
	
</xsl:template>

</xsl:stylesheet>
