using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity_Framework_Core.Objects
{
    [Table("user", Schema = "Store")]
    public class User
    {
        [Key]
        [Column("id")]
        public String Id {  get; set; } = String.Empty;

        [Column("name")]
        public String Name { get; set; } = String.Empty;

        [Column("email")]
        public String Email { get; set; } = String.Empty;

        public ICollection<UserOrder>? UserOrder { get; set; }
    }
}
