using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipesGitHub.Models.display
{
    public class FullAcount
    {
        public FullAcount(String user, String pass, String email)
        {
            this.Username = user;
            this.Password = pass;
            this.AccountPermission_id  = 0;
            this.Email = email;
        }

        public String Email { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public int AccountPermission_id { get; set; }

    }
}