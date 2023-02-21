using System.ComponentModel.DataAnnotations;

namespace PrintShopDesigns.Entities
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        [Required]
        public string CustomerName { get; set; }
        
        public string Address { get; set; }

        public string Address2 { get; set;}

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }

        public Boolean Active { get; set; }
    }
}
