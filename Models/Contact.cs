using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsService.Models
{
    public class Contact
    {
        [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int ContactId { get; set; }
        [Required] [StringLength(160)] public string FirstName { get; set; }
        [Required] [StringLength(160)] public string LastName { get; set; }
        [Required] [StringLength(160)] [DataType(DataType.EmailAddress)] public string Email { get; set; }
        [Required] [StringLength(160)] [DataType(DataType.PhoneNumber)] public string PhoneNumber { get; set; }
        [DataType(DataType.Date)][Display(Name = "Date of Birth")] public DateTime BirthDate { get; set; }
        public Status Status { get; set; }
        public Gender Gender { get; set; }
        public Address Address { get; set; }
    }

    public enum Status
    {
        Active = 1,
        InActive = 2
    }
    public enum Gender
    {
        Male = 1,
        Female = 2
    }
}
