namespace HuntingRegistry.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AnimalsDocument
    {
        public int Id { get; set; }

        public int DocumentId { get; set; }

        public int AnimalId { get; set; }

        public int? Count { get; set; }

        public int? Day { get; set; }

        public int? Season { get; set; }

        [StringLength(512)]
        public string Sex { get; set; }

        [StringLength(512)]
        public string Age { get; set; }

        public virtual Animal Animal { get; set; }

        public virtual Document Document { get; set; }

     }
}
