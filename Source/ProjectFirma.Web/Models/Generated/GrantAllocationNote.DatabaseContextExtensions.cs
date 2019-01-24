//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[GrantAllocationNote]
using System.Collections.Generic;
using System.Linq;
using Z.EntityFramework.Plus;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static GrantAllocationNote GetGrantAllocationNote(this IQueryable<GrantAllocationNote> grantAllocationNotes, int grantAllocationNoteID)
        {
            var grantAllocationNote = grantAllocationNotes.SingleOrDefault(x => x.GrantAllocationNoteID == grantAllocationNoteID);
            Check.RequireNotNullThrowNotFound(grantAllocationNote, "GrantAllocationNote", grantAllocationNoteID);
            return grantAllocationNote;
        }

        public static void DeleteGrantAllocationNote(this IQueryable<GrantAllocationNote> grantAllocationNotes, List<int> grantAllocationNoteIDList)
        {
            if(grantAllocationNoteIDList.Any())
            {
                grantAllocationNotes.Where(x => grantAllocationNoteIDList.Contains(x.GrantAllocationNoteID)).Delete();
            }
        }

        public static void DeleteGrantAllocationNote(this IQueryable<GrantAllocationNote> grantAllocationNotes, ICollection<GrantAllocationNote> grantAllocationNotesToDelete)
        {
            if(grantAllocationNotesToDelete.Any())
            {
                var grantAllocationNoteIDList = grantAllocationNotesToDelete.Select(x => x.GrantAllocationNoteID).ToList();
                grantAllocationNotes.Where(x => grantAllocationNoteIDList.Contains(x.GrantAllocationNoteID)).Delete();
            }
        }

        public static void DeleteGrantAllocationNote(this IQueryable<GrantAllocationNote> grantAllocationNotes, int grantAllocationNoteID)
        {
            DeleteGrantAllocationNote(grantAllocationNotes, new List<int> { grantAllocationNoteID });
        }

        public static void DeleteGrantAllocationNote(this IQueryable<GrantAllocationNote> grantAllocationNotes, GrantAllocationNote grantAllocationNoteToDelete)
        {
            DeleteGrantAllocationNote(grantAllocationNotes, new List<GrantAllocationNote> { grantAllocationNoteToDelete });
        }
    }
}