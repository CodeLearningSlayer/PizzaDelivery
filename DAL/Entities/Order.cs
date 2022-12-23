namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            Line_of_order = new HashSet<Line_of_order>();
        }

        [Column(TypeName = "date")]
        public DateTime Order_date { get; set; }

        [Key]
        public int Order_id { get; set; }

        public int Order_state { get; set; }

        public int Customer_id { get; set; }

        public int Courier_id { get; set; }

        [Required]
        [StringLength(50)]
        public string Order_adress { get; set; }

        public int Employee_code { get; set; }

        public int Order_sum { get; set; }

        public virtual Courier Courier { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Employee Employee { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Line_of_order> Line_of_order { get; set; }
    }
}
