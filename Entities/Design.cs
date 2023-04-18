using System.ComponentModel.DataAnnotations;

namespace PrintShopDesigns.Entities
{
    public class Design
    {
        [Key]
        public int DesignID { get; set; }

        public string Item { get; set; }

        public string Color { get; set; }

        public Boolean Hold { get; set; }
            
        public string? Notes { get; set; }
    }
}
