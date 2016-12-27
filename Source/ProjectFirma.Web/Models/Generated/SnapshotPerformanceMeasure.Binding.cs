//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[SnapshotPerformanceMeasure]
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    [Table("[dbo].[SnapshotPerformanceMeasure]")]
    public partial class SnapshotPerformanceMeasure : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected SnapshotPerformanceMeasure()
        {
            this.SnapshotPerformanceMeasureSubcategoryOptions = new HashSet<SnapshotPerformanceMeasureSubcategoryOption>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public SnapshotPerformanceMeasure(int snapshotPerformanceMeasureID, int snapshotID, int performanceMeasureID, int calendarYear, double actualValue) : this()
        {
            this.SnapshotPerformanceMeasureID = snapshotPerformanceMeasureID;
            this.SnapshotID = snapshotID;
            this.PerformanceMeasureID = performanceMeasureID;
            this.CalendarYear = calendarYear;
            this.ActualValue = actualValue;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public SnapshotPerformanceMeasure(int snapshotID, int performanceMeasureID, int calendarYear, double actualValue) : this()
        {
            // Mark this as a new object by setting primary key with special value
            SnapshotPerformanceMeasureID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.SnapshotID = snapshotID;
            this.PerformanceMeasureID = performanceMeasureID;
            this.CalendarYear = calendarYear;
            this.ActualValue = actualValue;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public SnapshotPerformanceMeasure(Snapshot snapshot, PerformanceMeasure performanceMeasure, int calendarYear, double actualValue) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.SnapshotPerformanceMeasureID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.SnapshotID = snapshot.SnapshotID;
            this.Snapshot = snapshot;
            snapshot.SnapshotPerformanceMeasures.Add(this);
            this.PerformanceMeasureID = performanceMeasure.PerformanceMeasureID;
            this.PerformanceMeasure = performanceMeasure;
            performanceMeasure.SnapshotPerformanceMeasures.Add(this);
            this.CalendarYear = calendarYear;
            this.ActualValue = actualValue;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static SnapshotPerformanceMeasure CreateNewBlank(Snapshot snapshot, PerformanceMeasure performanceMeasure)
        {
            return new SnapshotPerformanceMeasure(snapshot, performanceMeasure, default(int), default(double));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return SnapshotPerformanceMeasureSubcategoryOptions.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(SnapshotPerformanceMeasure).Name, typeof(SnapshotPerformanceMeasureSubcategoryOption).Name};

        [Key]
        public int SnapshotPerformanceMeasureID { get; set; }
        public int SnapshotID { get; set; }
        public int PerformanceMeasureID { get; set; }
        public int CalendarYear { get; set; }
        public double ActualValue { get; set; }
        public int PrimaryKey { get { return SnapshotPerformanceMeasureID; } set { SnapshotPerformanceMeasureID = value; } }

        public virtual ICollection<SnapshotPerformanceMeasureSubcategoryOption> SnapshotPerformanceMeasureSubcategoryOptions { get; set; }
        public virtual Snapshot Snapshot { get; set; }
        public virtual PerformanceMeasure PerformanceMeasure { get; set; }

        public static class FieldLengths
        {

        }
    }
}