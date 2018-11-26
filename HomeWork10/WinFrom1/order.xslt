<?xml version="1.0" encoding="utf-8" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
	<xsl:template match="/ArrayOfOrder">
		<html>
			<head>
				<title>Order Info</title>
			</head>
			<body>
				<ul>
					<xsl:for-each select="Order">
						<li>
							订单号：<xsl:value-of select="ID"/>
						</li>
						<li>
							客户姓名：<xsl:value-of select="ClientName"/>
						</li>
						<li>
							客户电话：<xsl:value-of select="ClientNumber"/>
						</li>
						<li>订单明细：
							<ul>
								<xsl:for-each select="list/OrderDetails">
								<li>
									商品名：<xsl:value-of select="stuff"/>
								</li>
								<li>
									单价:<xsl:value-of select="price"/>
								</li>
								<li>
									数量:<xsl:value-of select="num"/>
								</li>
							</xsl:for-each>
							</ul>
						</li>
					</xsl:for-each>
				</ul>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
