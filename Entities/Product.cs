using System.ComponentModel.DataAnnotations;

namespace PrintShopDesigns.Entities
{
    /// <summary>
    /// Represents a Product that is produced by King Plastics.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Gets or sets the unique identifier of the Product.
        /// </summary>
        [Key]
        public int ProductID { get; set; }

        /// <summary>
        /// Gets or sets the name of the Product.
        /// </summary>
        [Required]
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the Product's type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the description of the Product.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the Product was created.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the Product was last updated or modified.
        /// </summary>
        public DateTime Updated { get; set;}

        /// <summary>
        /// Gets or sets a flag indicating if the Product is archived.
        /// </summary>
        public Boolean  Archived { get; set; } 
    }
}
