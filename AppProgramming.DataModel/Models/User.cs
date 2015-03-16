﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppProgramming.DataModel.Models
{
    public class User
    {
        public int UserID { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MothersName { get; set; }

        public string Password { get; set; }

        public int RoleID { get; set; }

        public string RoleName { get; set; }
        public string RoleFriendlyName { get; set; }
    }
}
