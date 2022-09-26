using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Group7_FeelingBrew_Final_Project.Entities
{
    public class LoginUser
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public bool isAdmin { get; set; }
    }
}