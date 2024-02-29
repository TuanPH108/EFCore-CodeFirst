using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity_Framework_Core.Objects
{
    [Table ("product", Schema = "Store")]
    public class Product
    {
        [Key]
        [Column("id")]
        public String Id { get; set; } = String.Empty;

        [Column("name")]
        public String Name { get; set; } = String.Empty;

        [Column("note")]
        public String Note { get; set; } = String.Empty;

        [Column("price")]
        public double Price { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }

        [Column("discount")]
        public double Discoint { get; set; } 

        public UserOrderProduct? UserOrderProduct { get; set; }
    }
}
