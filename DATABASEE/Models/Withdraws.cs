﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATABASEE.Models
{
    public class Withdraws : BaseModels
    {


        [ForeignKey("Users/ Id")]
        public int User { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        public DateTime Withdraw_date { get; set; }


    }
}