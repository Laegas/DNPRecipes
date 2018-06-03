using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipesGitHub.Models.DAO
{
    /**
     * a DAO to handle all activity regarding accounts.
     * This DAO should also have included the functionality to check is the username/password combination is correct
     */
    public class AccountDAO
    {
        public static bool CreateAccount(account anAccount)
        {
            using (var db = new RecipeDBConnection())
            {
                try
                {
                    db.accounts.Add(anAccount);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }

            }

        }
    }
}