using System.ComponentModel.DataAnnotations;

namespace PrintShopDesigns.Entities
{
    public class Material
    {
        [Key]
        public int MaterialID { get; set; }

        [Required]
        public string? Name { get; set; }

        public string? Type { get; set; }

        public decimal CubicFootWeight { get; set; }

        public string? Notes1 { get; set; }

        public string? Notes2 { get; set; }
    }
}
