using System.ComponentModel.DataAnnotations;

namespace PrintShopDesigns.Entities
{
    public class Machine
    {
        [Key]
        public int MachineId { get; set; }

        [Required]
        public string MachineName { get; set; }
    }
}
