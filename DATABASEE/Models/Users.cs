using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATABASEE.Models
{
    public class Users : BaseModels
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public int Pin { get; set; }

        [Required]
        public int Account_Number { get; set; }

        [Required]
        public double Balance { get; set; }

        [ForeignKey("User_roles/ Id")]
        public int User_role { get; set; }

        [Required]
        public DateTime Created_date { get; set; }

    }
}
