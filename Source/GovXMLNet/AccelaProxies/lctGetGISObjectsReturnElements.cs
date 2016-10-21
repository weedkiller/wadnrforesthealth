﻿using System.Collections.Generic;
using System.Xml.Serialization;

// Defined in AccelaOperationRepository_GIS as local complex type

/* Version Last Modified: 6.7
	<xsd:complexType name="GetGISObjects">
		<xsd:complexContent>
			<xsd:extension base="OperationRequest">
				<xsd:sequence>
					<xsd:element name="returnElements" form="qualified" minOccurs="0">
						<xsd:complexType>
							<xsd:sequence maxOccurs="unbounded">
								<xsd:element name="returnElement" form="qualified">
									<xsd:complexType>
										<xsd:simpleContent>
											<xsd:extension base="gisObjectDetailReturnEnum">
												<xsd:attribute name="detailLevels" type="xsd:nonNegativeInteger" use="optional"/>
											</xsd:extension>
										</xsd:simpleContent>
									</xsd:complexType>
								</xsd:element>
							</xsd:sequence>
						</xsd:complexType>
					</xsd:element>
					<xsd:element ref="MapServiceId"/>
					<xsd:choice maxOccurs="unbounded">
						<xsd:group ref="GISObjectsSearchCollectionSelect"/>
					</xsd:choice>
				</xsd:sequence>
			</xsd:extension>
		</xsd:complexContent>
	</xsd:complexType>
*/

/*
 * Author: Bob Thiele
 * Organization:  Allen County/City of Fort Wayne
 * Date: 2/14/2012
 * Modifications:
*/

namespace GovXMLNet
{
    public class lctGetGISObjectsReturnElements
    {
        // Members
        // TODO need example
        [XmlElement(ElementName = "returnElement")]
        public List<lctGetGISObjectsReturnElement> ReturnElements { get; set; }

        // Constructors
        public lctGetGISObjectsReturnElements()
        {
        }
    }
}
