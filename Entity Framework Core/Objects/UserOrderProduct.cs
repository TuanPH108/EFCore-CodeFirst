using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity_Framework_Core.Objects
{
    [Table("user_order_product", Schema = "Store")]
    public class UserOrderProduct
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("note")]
        public String Note { get; set; } = String.Empty;

        [Column("quantity")]
        public int Quantity { get; set; }

        [Column("discount")]
        public double Discoint { get; set; }

        [ForeignKey("UserOrder")]
        [Column("user_order_id")]
        public String UserOrderId { get; set; } = string.Empty;

        [ForeignKey("Product")]
        [Column("product_id")]
        public String ProductId { get; set; } = string.Empty;

        public UserOrder? UserOrder { get; set; }
        public Product? Product { get; set; }
    }
}
