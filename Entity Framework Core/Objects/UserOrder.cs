using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity_Framework_Core.Objects
{
    [Table("user_order", Schema = "Store")]
    public class UserOrder
    {
        [Key]
        [Column("id")]
        public String Id { get; set; } = String.Empty;

        [Column("quantity")]
        public int Quantity { get; set; }

        [Column("date")]
        public DateTime Date { get; set; }
        [Column("user_id")]
        public String UserId { get; set; } = string.Empty;

        [Column("user_order_product_id")]
        public String UserOrderProductId { get; set; } = string.Empty;

        [ForeignKey("UserId, UserOrderProductId")]
        public User? User { get; set; }
        public ICollection<UserOrderProduct>? UserOrderProduct { get; set; }
    }
}
