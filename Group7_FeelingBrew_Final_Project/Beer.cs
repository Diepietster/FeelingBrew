using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Group7_FeelingBrew_Final_Project
{
    public class Beer
    {
        public int BeerCode { get; set; }
        public string BeerName { get; set;}
        public string BeerDescription { get; set; }
        public float BeerUnitPricePerBottle { get; set; }
        public int BeerBottleSize { get; set; }
        public int BeerQtyOnHand { get; set; }
    }
}