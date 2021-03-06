﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizerDAL.Models
{
    public class Role
    {
        [Key]
        public int roleId { get; set; }
        public string roleName { get; set; }
        public Boolean accessToPageA { get; set; }
        public Boolean accessToPageB { get; set; }
        public Boolean accessToPageC { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
