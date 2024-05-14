using System.ComponentModel.DataAnnotations;

namespace PrintShopDesigns.Entities
{
    public class ColorPlate
    {
        [Key]
        public int ColorPlateID { get; set; }

        public int DesignID { get; set; }

        public string Color { get; set; }

        public string Spec { get; set; }
        
        public bool Common { get; set; }
    }
}
