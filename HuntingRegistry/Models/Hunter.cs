namespace HuntingRegistry.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Hunter
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hunter()
        {
            Documents = new HashSet<Document>();
        }

        public int Id { get; set; }

        [StringLength(512)]
        public string Name { get; set; }

        [StringLength(100)]
        public string LicenceSerial { get; set; }

        [StringLength(100)]
        public string LicenceNumber { get; set; }

        public DateTime? LicenceIssueDate { get; set; }

        [StringLength(512)]
        public string LicenceIssueOrg { get; set; }

        [StringLength(512)]
        public string Address { get; set; }

        [StringLength(512)]
        public string Phone { get; set; }

        [StringLength(512)]
        public string Passport { get; set; }

        [StringLength(512)]
        public string TIN { get; set; }

        public DateTime? BirthDay { get; set; }

        public string test { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Document> Documents { get; set; }
    }
}
