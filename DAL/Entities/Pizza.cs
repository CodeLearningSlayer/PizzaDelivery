namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pizza")]
    public partial class Pizza
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pizza()
        {
            Ingredients = new HashSet<Ingredients>();
            Line_of_order = new HashSet<Line_of_order>();
        }

        public double Pizza_price { get; set; }

        [Required]
        [StringLength(50)]
        public string Pizza_type { get; set; }

        [Key]
        public int Pizza_id { get; set; }

        [Required]
        [StringLength(50)]
        public string Pizza_name { get; set; }

        public bool isAvalaible { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ingredients> Ingredients { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Line_of_order> Line_of_order { get; set; }

        public virtual PizzaType PizzaType { get; set; }
    }
}
