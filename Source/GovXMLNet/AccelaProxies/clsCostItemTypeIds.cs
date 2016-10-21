﻿using System.Collections.Generic;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="CostItemTypeIds">
		<xsd:complexContent>
			<xsd:extension base="elementList">
				<xsd:sequence maxOccurs="unbounded">
					<xsd:element ref="CostItemTypeId"/>
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
    public class clsCostItemTypeIds : clsElementList
    {
        // Members
        [XmlElement(ElementName = "CostItemTypeId")]
        public List<clsCostItemTypeId> CostItemTypeId { get; set; }

        // Constructors
        public clsCostItemTypeIds()
        {
        }
    }
}
