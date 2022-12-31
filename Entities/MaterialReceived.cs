using System.ComponentModel.DataAnnotations;

namespace PrintShopDesigns.Entities
{
    public class MaterialReceived
    {
        [Key]
        public int MaterialReceivedID { get; set; }

        [Required]
        #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string Name { get; set; }

        public string? Type { get; set; }

        public string? KingLot { get; set; }

        public string? VendorLot { get; set; }

        public Int16 Quantity { get; set; }

        public decimal CostLb { get; set; }
        
        public string? Notes { get; set; }
    }
}
