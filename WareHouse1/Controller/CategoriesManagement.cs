using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Configuration;
using WareHouse1.Models;
using WareHouse1.Share;
using System.Data.SqlClient;

namespace WareHouse1.Controller
{
    public class CategoriesManagement
    {
        public void CartegoryManagrnt()
        {
            Console.WriteLine("===Category Management===");
            Console.WriteLine("[1]:ListCategory");
            Console.WriteLine("[2]:ListGroupCategory");
            Console.WriteLine("[3]:AddCategory");
            Console.WriteLine("[4]:DeleteCategory");
        }
        public void ListCartegory()
        {
            Console.WriteLine("List Category Product");
            SqlConnection dbcontext = new SqlConnection();
            dbcontext.ConnectionString = ConfigurationManager.ConnectionStrings["WareHouseEntities"].ConnectionString;
            var list = "Select *  " +
                       " From Categories   ";
            SqlCommand query = new SqlCommand(list,dbcontext);
            dbcontext.Open();
            Console.WriteLine($"{"ID",-10}{"NameCategory"}");
            SqlDataReader read = query.ExecuteReader();
            while (read.Read())
            {
                Console.WriteLine(read["ID"] + "         " + read["NameCategory"]);
            }

        }
        public void GroupCategory()
        {

        }
        public void AddCartegory()
        {

        }
        public void DeLeteCartegory()
        {

        }
       
    }
}
