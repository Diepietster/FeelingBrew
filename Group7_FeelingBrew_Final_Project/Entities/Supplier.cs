using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Group7_FeelingBrew_Final_Project.Entities
{
    public class Supplier
    {
        public int SplrCode { get; set; }
        public string SplrName { get; set; }
        public string SplrStreetNumber { get; set; }
        public string SplrStreetName { get; set; }
        public DateTime SplrAgreementStartDate { get; set; }
        public DateTime SplrAgreementEndDate { get; set; }
        public int CityCode { get; set; }
        public int ProvinceCode { get; set; }        
    }
}