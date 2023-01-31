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
using System.Linq.Expressions;
using System.CodeDom;

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
                       " From Categories";
            SqlCommand query = new SqlCommand(list,dbcontext);
            dbcontext.Open();
            Console.WriteLine($"{"ID",-10}{"NameCategory"}");
            SqlDataReader read = query.ExecuteReader();
            while (read.Read())
            {
                Console.WriteLine($"{read["ID"],-10}{read["NameCategory"],-10}"); 
            }

        }
        public void GroupCategory()
        {
            
            Console.WriteLine("Input Category");
            string inputCategory = Console.ReadLine(); // no check DB
            Console.WriteLine("Category Detail Product");
            SqlConnection dbcontext = new SqlConnection();
            dbcontext.ConnectionString = ConfigurationManager.ConnectionStrings["WareHouseEntities"].ConnectionString;
            
            Console.WriteLine($"{"IDproduct",-15}{"NameProduct",-20}{"Color",-10}{"Price",-10}{"Stok",-10}{"Category",-15}{"WareHouse",-10}");
            var detail = "Select IDProduct,NameProduct,Color,Price,Stok,NameCategory,WareHouse1,Address " +
                             " From Products AS P " +
                             "INNER JOIN Categories AS C " +
                             "ON P.IDCategory = C.ID " +
                             "INNER JOIN WareHouses AS W  " +
                             "ON P.IDWareHouse = W.ID " + 
                             " Where C.NameCategory = @NameCategory";
            
            SqlCommand query = new SqlCommand(detail,dbcontext);
            query.Parameters.AddWithValue("@NameCategory",inputCategory);
           
            dbcontext.Open();
            SqlDataReader Read = query.ExecuteReader();
            while (Read.Read())
            {
                Console.WriteLine($"{Read["IDProduct"],-15}{Read["NameProduct"],-20}{Read["Color"],-10}{Read["Price"],-10}{Read["Stok"],-10}{Read["NameCategory"],-15}{Read["WareHouse1"],-10}");
            }
            dbcontext.Close();
            

        }
        public void AddCartegory()
        {
            //k cho trùng lặp tên category?
            //kiem tra input?
            Console.WriteLine("Category Detail Product: ");
            Console.WriteLine("Input Category Product: ");
            string inputCategory = Console.ReadLine();

            SqlConnection dbcontext = new SqlConnection();
            dbcontext.ConnectionString = ConfigurationManager.ConnectionStrings["WareHouseEntities"].ConnectionString;
            var addCategory = "INSERT INTO Categories(NameCategory) VALUES (@NameCategory) ";
            SqlCommand query = new SqlCommand(addCategory,dbcontext);
            dbcontext.Open();
            query.Parameters.AddWithValue("@NameCategory",inputCategory);
            query.ExecuteNonQuery();
            SqlDataReader Reader = query.ExecuteReader();
            
            dbcontext.Close();
            Console.WriteLine("Insert sucssesfull ! ");

        }
        public void DeLeteCartegory()
        {
            
            Console.WriteLine("Input Delete NameCategory: ");
            string Category = Console.ReadLine();

            SqlConnection dbcontext = new SqlConnection();
            dbcontext.ConnectionString = ConfigurationManager.ConnectionStrings["WareHouseEntities"].ConnectionString;
            var addCategory = "DELETE FROM Categories WHERE NameCategory = @NameCategory ";
            SqlCommand query = new SqlCommand(addCategory, dbcontext);
            dbcontext.Open();
            query.Parameters.AddWithValue("@NameCategory", Category);
            query.ExecuteNonQuery();
            Console.WriteLine("delete sucsess! ");
            dbcontext.Close();
        }
       
    }
}
