using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Group7_FeelingBrew_Final_Project
{
    public class Ingredient
    {
        public int IngredientCode { get; set; }
        public string IngrDescription { get; set; }
        public float IngrLatestCost { get; set; }
        public int QtyOnHand { get; set; }
        public int IngrUnitTypeCode { get; set; }
        public int SplrCode { get; set; }
    }
}