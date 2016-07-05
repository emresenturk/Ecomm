using System.ComponentModel.DataAnnotations;

namespace Ecomm.Web.Models
{
    public class OrderRequest
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Required]
        public string HouseNumber { get; set; }

        [Required]
        public string ZipCode { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}