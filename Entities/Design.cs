using System.ComponentModel.DataAnnotations;

namespace PrintShopDesigns.Entities
{
    /// <summary>
    /// Represents the design 
    /// </summary>
    public class Design
    {
        [Key]
        public Int32 DesignID { get; set; }

        public string KingDesignID { get; set; }

        public string Item { get; set; }

        public string Color { get; set; }

        public Boolean Hold { get; set; }
            
        public string? Notes { get; set; }

        public string? Customer { get; set; }

        public Int32 LabelPosition { get; set; }

        public string? Description { get; set; }

        public string? Weight { get; set; }

        public string? UPC { get; set; }

        public string? CustomerItemCode { get; set; }

        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }

        public bool Archived { get; set; }

        public string Type { get; set; }

    }
}
