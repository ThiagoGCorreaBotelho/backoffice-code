using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Settings
{
    public class spValidateToken
    {
        [Key]
        public long Id { get; set; }
        public bool Exist { get; set; }

    }
}
