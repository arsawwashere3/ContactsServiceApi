using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsService.Models
{
    public class Address
    {
        [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int AddId { get; set; }
        [Required] [RegularExpression("[A-Za-z0-9].*")] public string AddressLine { get; set; }
        public Region Region { get; set; }
    }


    public class Region
    {
        [Key]
        public int RegionId { get; set; }
        [StringLength(160)] [RegularExpression("[A-Za-z].*")] public string City { get; set; }
        [StringLength(160)] [RegularExpression("[A-Za-z].*")] public string State { get; set; }
        [StringLength(160)] [RegularExpression("[A-Za-z].*")] public string Country { get; set; }
        [DataType(DataType.PostalCode)] public string PostalCode { get; set; }
    }
}
