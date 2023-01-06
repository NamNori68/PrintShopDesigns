using System.ComponentModel.DataAnnotations;

namespace PrintShopDesigns.Entities
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Required]
        public string ProductName { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        public DateOnly Created { get; set; }

        public DateOnly Updated { get; set;}

        public Boolean  Archived { get; set; } 
    }
}
