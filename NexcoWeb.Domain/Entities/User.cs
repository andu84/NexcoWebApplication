﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexcoWeb.Domain.Entities
{
    public class User
    {
        [Key]
        public string UserId { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public DateTime CreateDate { get; set; }

    }
}
