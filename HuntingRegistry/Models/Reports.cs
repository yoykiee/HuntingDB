namespace HuntingRegistry.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Reports
    {
        public int Id { get; set; }

        [StringLength(512)]
        public string Name { get; set; }

        [StringLength(512)]
        public string Title { get; set; }

        [StringLength(512)]
        public string Template { get; set; }

        public bool f_Default { get; set; }

        public bool f_InstantPrint { get; set; }
    }
}
