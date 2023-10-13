using System.ComponentModel.DataAnnotations;

namespace PrintShopDesigns.Entities
{
    public class Machine
    {
        [Key]
        public int MachineId { get; set; }

        [Required]
        public string MachineName { get; set; }
        public string MachineProduct { get; set; }
        public string MachineType { get; set; }

    }
}
