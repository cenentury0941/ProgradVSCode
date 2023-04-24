using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp
{
    internal class Recipe
    {
        public string RecipeName { get; set; }

        public int RecipeID { get; set; }
    
        public List<string> ingredients { get; set; }
        public List<string> instructions { get; set; }
    }
}
