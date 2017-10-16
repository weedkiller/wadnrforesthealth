﻿/*-----------------------------------------------------------------------
<copyright file="GoogleChartConfigurationViewModel.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
<author>Sitka Technology Group</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Newtonsoft.Json;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Shared
{
    public class GoogleChartConfigurationViewModel : IValidatableObject
    {
        [JsonProperty(PropertyName = "options")]
        public string ChartConfigurationJson { get; set; }
        [JsonProperty(PropertyName = "chartType")]
        public string ChartType { get; set; }

        public void UpdateModel(Models.PerformanceMeasure performanceMeasure, int performanceMeasureSubcategoryID)
        {            
            //Remove certain properties that we don't want saved to the DB
            var chartConfigurationString = CleanAndSerializeChartJsonString(ChartConfigurationJson);
            var perfomanceMeasureSubcategory = performanceMeasure.PerformanceMeasureSubcategories.Single(x => x.PerformanceMeasureSubcategoryID == performanceMeasureSubcategoryID);
            var googleChartType = ConverChartTypeStringToGoogleChartType();
            perfomanceMeasureSubcategory.GoogleChartTypeID = googleChartType != null ? googleChartType.GoogleChartTypeID : (int?)null;
            perfomanceMeasureSubcategory.ChartConfigurationJson = chartConfigurationString;
        }

        public string CleanAndSerializeChartJsonString(string json)
        {
            var chartConfiguration = JsonConvert.DeserializeObject<GoogleChartConfiguration>(json);
            chartConfiguration.SanitizeForSaving();
            return JsonConvert.SerializeObject(chartConfiguration);
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();
            
            //Ensure our new values can be parsed without exceptions. No need to store the values.
            JsonConvert.DeserializeObject<GoogleChartConfiguration>(ChartConfigurationJson);
            Enum.Parse(typeof(GoogleChartType), ChartType);
            
            return validationResults;
        }

        private GoogleChartType ConverChartTypeStringToGoogleChartType()
        {
            return GoogleChartType.All.SingleOrDefault(x => x.GoogleChartTypeDisplayName == ChartType);
        }
    }
}
