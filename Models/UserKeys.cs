using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsService.Models
{
    public class UserKeys
    {
        [Key]
        public int Id { get; set; }

        [MinLength(32), MaxLength(32)]
        [RegularExpression("[a-zA-Z0-9].*")]
        public string UserKey { get; set; }
    }
}
