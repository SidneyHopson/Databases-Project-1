using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TeamProject1.Models
{
    public class MyRecipe_Seasoning
    {
        public int Id { get; set; }
        [ForeignKey("MyRecipe")]
        [Display(Name = "Recipe")]
        public int R_id { get; set; }
        public decimal Weight { get; set; }
        [ForeignKey("Ingredient")]
        [Display(Name = "Ingredient")]
        public int I_id { get; set; }

        public Ingredient Ingredient { get; set; }
        [Display(Name = "My Recipe")]
        public MyRecipe MyRecipe { get; set; }
    }
}
