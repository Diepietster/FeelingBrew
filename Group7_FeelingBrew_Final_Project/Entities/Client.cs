using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Group7_FeelingBrew_Final_Project.Entities
{
    public class Client
    {
        public int ClientCode { get; set; }
        public string ClientName { get; set; }
        public string ClientSurname { get; set; }
        public string ClientCellphone { get; set; }
        public string ClientStreetNumber { get; set; }
        public string ClientStreetName { get; set; }
        public string ClientType { get; set; }
        public int CityCode { get; set; }
        public int ProvinceCode { get; set; }
    }
}