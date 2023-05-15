using System.ComponentModel.DataAnnotations;

namespace PrintShopDesigns.Entities
{
    public class Color
    {
        [Key]
        public int ColorID { get; set; }

        [Required]
        public string ColorName { get; set; }
    }
}
