using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Group7_FeelingBrew_Final_Project.Entities;

namespace Group7_FeelingBrew_Final_Project.Helper_Methods
{
    public class HelperMethods
    {
        public string connStr = @"Server=localhost; Database=FeelingBrewWebDb; Trusted_Connection=True;";
        public SqlConnection myConn;
        public SqlCommand myCommand;
        public DataSet myData;
        public SqlDataAdapter myAdapter;
        public SqlDataReader myReader;


        public List<City> populateCity()
        {
            myConn = new SqlConnection(connStr);
            myConn.Open();

            string sqlCity = $"SELECT * " +
                $"FROM City ORDER BY CityCode ASC;";

            myCommand = new SqlCommand(sqlCity, myConn);

            myAdapter = new SqlDataAdapter();
            myData = new DataSet();
            myReader = myCommand.ExecuteReader();
            List<City> cityList = Getlist<City>(myReader);
           

            myCommand.Dispose();
            myConn.Close();
            return cityList != null ? cityList : new List<City>();
        }

        public List<Province> populateProvince()
        {
            myConn = new SqlConnection(connStr);
            myConn.Open();

            string sqlProvince = $"SELECT * " +
                $"FROM Province ORDER BY ProvinceCode ASC;";

            myCommand = new SqlCommand(sqlProvince, myConn);

            myAdapter = new SqlDataAdapter();
            myData = new DataSet();
            myReader = myCommand.ExecuteReader();
            List<Province> provinceList = Getlist<Province>(myReader);

            myCommand.Dispose();
            myConn.Close();

            return provinceList != null ? provinceList : new List<Province>();
        }


        public List<T> Getlist<T>(IDataReader reader)
        {
            List<T> list = new List<T>();
            while (reader.Read())
            {
                var type = typeof(T);
                T obj = (T)Activator.CreateInstance(type);
                foreach (var prop in type.GetProperties())
                {
                    var propType = prop.PropertyType;
                    prop.SetValue(obj, Convert.ChangeType(reader[prop.Name].ToString(), propType));
                }
                list.Add(obj);
            }

            return list;
        }
    }
}