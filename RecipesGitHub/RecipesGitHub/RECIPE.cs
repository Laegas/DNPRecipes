//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RecipesGitHub
{
    using System;
    using System.Collections.Generic;
    
    public partial class RECIPE
    {
        public RECIPE()
        {
            this.comments = new HashSet<comment>();
            this.INGREDIENT_IN_RECIPE = new HashSet<INGREDIENT_IN_RECIPE>();
        }
    
        public decimal ID_RECIPE { get; set; }
        public string NAME { get; set; }
        public string IMAGE_FOLDER { get; set; }
        public string DESCRIPTION { get; set; }
    
        public virtual ICollection<comment> comments { get; set; }
        public virtual ICollection<INGREDIENT_IN_RECIPE> INGREDIENT_IN_RECIPE { get; set; }
    }
}
