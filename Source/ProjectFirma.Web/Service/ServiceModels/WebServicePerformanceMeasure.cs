﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Service.ServiceModels
{
    [DataContract]
    public class WebServicePerformanceMeasure : SimpleModelObject
    {
        public WebServicePerformanceMeasure(PerformanceMeasure performanceMeasure)
        {
            PerformanceMeasureID = performanceMeasure.PerformanceMeasureID;
            PerformanceMeasureName = performanceMeasure.PerformanceMeasureDisplayName;
            PerformanceMeasureUnits = performanceMeasure.MeasurementUnitType.MeasurementUnitTypeDisplayName;

            if (performanceMeasure.HasRealSubcategories)
            {
                var currentSubcategoryIndex = 1;
                foreach (var performanceMeasureSubcategory in performanceMeasure.PerformanceMeasureSubcategories)
                {
                    if (currentSubcategoryIndex == 1)
                    {
                        PMSubcategoryName1 = performanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName;
                        PMSubcategoryOptionCount1 = performanceMeasureSubcategory.PerformanceMeasureSubcategoryOptions.Count;
                    }
                    else if (currentSubcategoryIndex == 2)
                    {
                        PMSubcategoryName2 = performanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName;
                        PMSubcategoryOptionCount2 = performanceMeasureSubcategory.PerformanceMeasureSubcategoryOptions.Count;
                    }
                    else if (currentSubcategoryIndex == 3)
                    {
                        PMSubcategoryName3 = performanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName;
                        PMSubcategoryOptionCount3 = performanceMeasureSubcategory.PerformanceMeasureSubcategoryOptions.Count;
                    }
                    else if (currentSubcategoryIndex == 4)
                    {
                        PMSubcategoryName4 = performanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName;
                        PMSubcategoryOptionCount4 = performanceMeasureSubcategory.PerformanceMeasureSubcategoryOptions.Count;
                    }
                    else
                    {
                        throw new NotImplementedException("Cannot handle more than four subcategories on a PM");
                    }
                    currentSubcategoryIndex++;
                }
            }
        }    

        [DataMember] public int PerformanceMeasureID { get; set; }
        [DataMember] public string PerformanceMeasureName { get; set; }
        [DataMember] public string PerformanceMeasureDescription { get; set; }
        [DataMember] public string PerformanceMeasureUnits { get; set; }
        
        [DataMember] public string PMSubcategoryName1 { get; set; }
        [DataMember] public int? PMSubcategoryOptionCount1 { get; set; }
        [DataMember] public string PMSubcategoryName2 { get; set; }
        [DataMember] public int? PMSubcategoryOptionCount2 { get; set; }
        [DataMember] public string PMSubcategoryName3 { get; set; }
        [DataMember] public int? PMSubcategoryOptionCount3 { get; set; }
        [DataMember] public string PMSubcategoryName4 { get; set; }
        [DataMember] public int? PMSubcategoryOptionCount4 { get; set; }

        public static List<WebServicePerformanceMeasure> GetPerformanceMeasures()
        {
            var performanceMeasures = HttpRequestStorage.DatabaseEntities.PerformanceMeasures.ToList();
            return performanceMeasures.Select(x => new WebServicePerformanceMeasure(x)).OrderBy(x => x.PerformanceMeasureID).ToList();
        }
    }

    public class WebServicePerformanceMeasureGridSpec : GridSpec<WebServicePerformanceMeasure>
    {
        public WebServicePerformanceMeasureGridSpec()
        {
            Add("PerformanceMeasureID", x => x.PerformanceMeasureID, 0);
            Add("PerformanceMeasureName", x => x.PerformanceMeasureName, 0);
            Add("PerformanceMeasureDescription", x => x.PerformanceMeasureDescription, 0);
            Add("PerformanceMeasureUnits", x => x.PerformanceMeasureUnits, 0);

            Add("PMSubcategoryName1", x => x.PMSubcategoryName1, 0);
            Add("PMSubcategoryOptionCount1", x => x.PMSubcategoryOptionCount1, 0);
            Add("PMSubcategoryName2", x => x.PMSubcategoryName2, 0);
            Add("PMSubcategoryOptionCount2", x => x.PMSubcategoryOptionCount2, 0);
            Add("PMSubcategoryName3", x => x.PMSubcategoryName3, 0);
            Add("PMSubcategoryOptionCount3", x => x.PMSubcategoryOptionCount3, 0);
            Add("PMSubcategoryName4", x => x.PMSubcategoryName4, 0);
            Add("PMSubcategoryOptionCount4", x => x.PMSubcategoryOptionCount4, 0);
        }
    }
}