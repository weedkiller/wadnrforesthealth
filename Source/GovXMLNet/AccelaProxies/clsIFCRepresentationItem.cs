﻿// Based on usage in ifc2x_final_stage2_03

/*  Version 7.1 
<xsd:complexType abstract="true" name="RepresentationItem">
	<xsd:complexContent>
		<xsd:extension base="elementID">
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
    public class clsIFCRepresentationItem : clsIFCelementID
    {
        //Constructors
        public clsIFCRepresentationItem()
        {
        }
    }
}
