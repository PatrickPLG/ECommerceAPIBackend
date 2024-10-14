using System.ComponentModel.DataAnnotations;

namespace ECommerceAPI.Models
{
    public class Favorite
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserID { get; set; }
        [Required]
        public int ProductId { get; set; }

    }
}
