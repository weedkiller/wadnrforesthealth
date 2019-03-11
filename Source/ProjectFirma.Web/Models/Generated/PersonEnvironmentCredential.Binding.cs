//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PersonEnvironmentCredential]
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
    // Table [dbo].[PersonEnvironmentCredential] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[dbo].[PersonEnvironmentCredential]")]
    public partial class PersonEnvironmentCredential : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected PersonEnvironmentCredential()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public PersonEnvironmentCredential(int personEnvironmentCredentialID, int personID, int deploymentEnvironmentID, int authenticatorID, string personUniqueIdentifier) : this()
        {
            this.PersonEnvironmentCredentialID = personEnvironmentCredentialID;
            this.PersonID = personID;
            this.DeploymentEnvironmentID = deploymentEnvironmentID;
            this.AuthenticatorID = authenticatorID;
            this.PersonUniqueIdentifier = personUniqueIdentifier;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public PersonEnvironmentCredential(int personID, int deploymentEnvironmentID, int authenticatorID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.PersonEnvironmentCredentialID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.PersonID = personID;
            this.DeploymentEnvironmentID = deploymentEnvironmentID;
            this.AuthenticatorID = authenticatorID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public PersonEnvironmentCredential(Person person, DeploymentEnvironment deploymentEnvironment, Authenticator authenticator) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.PersonEnvironmentCredentialID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.PersonID = person.PersonID;
            this.Person = person;
            person.PersonEnvironmentCredentials.Add(this);
            this.DeploymentEnvironmentID = deploymentEnvironment.DeploymentEnvironmentID;
            this.AuthenticatorID = authenticator.AuthenticatorID;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static PersonEnvironmentCredential CreateNewBlank(Person person, DeploymentEnvironment deploymentEnvironment, Authenticator authenticator)
        {
            return new PersonEnvironmentCredential(person, deploymentEnvironment, authenticator);
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return false;
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(PersonEnvironmentCredential).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.PersonEnvironmentCredentials.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int PersonEnvironmentCredentialID { get; set; }
        public int PersonID { get; set; }
        public int DeploymentEnvironmentID { get; set; }
        public int AuthenticatorID { get; set; }
        public string PersonUniqueIdentifier { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return PersonEnvironmentCredentialID; } set { PersonEnvironmentCredentialID = value; } }

        public virtual Person Person { get; set; }
        public DeploymentEnvironment DeploymentEnvironment { get { return DeploymentEnvironment.AllLookupDictionary[DeploymentEnvironmentID]; } }
        public Authenticator Authenticator { get { return Authenticator.AllLookupDictionary[AuthenticatorID]; } }

        public static class FieldLengths
        {
            public const int PersonUniqueIdentifier = 100;
        }
    }
}