using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeamProject1.Models
{
    public class RecipeDetails
    {
        [Display(Name = "My Recipe")]
        public MyRecipe MyRecipe { get; set; }
        public List<Ingredient_W> I_common { get; set; }
        public decimal Total_calories { get; set; }
    }
}
