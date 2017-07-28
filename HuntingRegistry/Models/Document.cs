namespace HuntingRegistry.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Document
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Document()
        {
            AnimalsDocuments = new HashSet<AnimalsDocument>();
        }

        public int Id { get; set; }

        [StringLength(100)]
        public string Number { get; set; }

        public int? HunterId { get; set; }

        public int? AreaId { get; set; }

        public int? HunterFarmId { get; set; }

        [StringLength(512)]
        public string HunterFarmName { get; set; }

        [StringLength(100)]
        public string RegNumber { get; set; }

        [Column(TypeName = "money")]
        public decimal? Summ { get; set; }

        public DateTime? RegDate { get; set; }

        public DateTime? IssueDate { get; set; }

        public DateTime? ActivityDateStart { get; set; }

        public DateTime? ActivityDateEnd { get; set; }

        public int? TypeId { get; set; }

        public int? SignId { get; set; }

        public int? HuntTypeId { get; set; }

        public int? OldId { get; set; }

        public DateTime? PaymentDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        [StringLength(512)]
        public string Result { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AnimalsDocument> AnimalsDocuments { get; set; }

        public virtual Area Area { get; set; }

        public virtual DocumentType DocumentType { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual HunterFarm HunterFarm { get; set; }

        public virtual Hunter Hunter { get; set; }

        public virtual HuntType HuntType { get; set; }
    }
}
