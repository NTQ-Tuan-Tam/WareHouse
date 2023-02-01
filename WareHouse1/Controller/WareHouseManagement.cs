using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using WareHouse1.Models;
using WareHouse1.Share;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace WareHouse1.Controller
{
    public  class WareHouseManagement
    {
        public void WareHouseOption()
        {
            Console.WriteLine("=== Warehouse Management ===");
            Console.WriteLine("[1]:List Warehouse");
            Console.WriteLine("[2]:List Group Address Warehouse");
            Console.WriteLine("[3]:Add Warehouse");
            Console.WriteLine("[4]:Delete Warehouse");
            Console.WriteLine("[Q]:Quit WareHouse");
        }
        public void ListWarehouse() 
        {
            Console.WriteLine("=== List WareHouse === ");
            SqlConnection dbcontext = new SqlConnection();
            dbcontext.ConnectionString = ConfigurationManager.ConnectionStrings["WareHouseEntities"].ConnectionString;
            var ListWH = " SELECT * FROM WareHouses";
            SqlCommand query = new SqlCommand(ListWH,dbcontext);
            dbcontext.Open();
            SqlDataReader read = query.ExecuteReader();
            Console.WriteLine($"{"ID",-10}{"WareHouse",-15}{"Address",-10}");
            while (read.Read())
            {
                Console.WriteLine($"{read["ID"],-10}{read["WareHouse1"],-15}{read["Address"],-10}");
            }
            dbcontext.Close();
        }
        public void ListGroupAddressWarehouse()
        {
            Console.WriteLine("Input Address WereHouse");
            string inputAddress = Console.ReadLine(); // no check DB
            Console.WriteLine("Category Detail Product");
            SqlConnection dbcontext = new SqlConnection();
            dbcontext.ConnectionString = ConfigurationManager.ConnectionStrings["WareHouseEntities"].ConnectionString;

            
            var list = "Select IDProduct,NameProduct,Color,Price,Stok,NameCategory,WareHouse1,Address " +
                             " From Products AS P " +
                             "INNER JOIN Categories AS C " +
                             "ON P.IDCategory = C.ID " +
                             "INNER JOIN WareHouses AS W  " +
                             "ON P.IDWareHouse = W.ID " +
                             " Where W.Address = @Address";

            SqlCommand query = new SqlCommand(list, dbcontext);
            query.Parameters.AddWithValue("@Address", inputAddress);

            dbcontext.Open();
            SqlDataReader Read = query.ExecuteReader();
            Console.WriteLine($"{"IDproduct",-15}{"NameProduct",-20}{"Color",-10}{"Price",-10}{"Stok",-10}{"Category",-15}{"WareHouse",-15}{"Address",-10}");
            while (Read.Read())
            {
                Console.WriteLine($"{Read["IDProduct"],-15}{Read["NameProduct"],-20}{Read["Color"],-10}{Read["Price"],-10}{Read["Stok"],-10}{Read["NameCategory"],-15}{Read["WareHouse1"],-15}{Read["Address"],-10}");
            }
            dbcontext.Close();
        }
        public void AddWareHouse()
        {
            Console.WriteLine("=== Add WareHouse ===");
            Console.WriteLine("input Name WareHouse");
            string NameWareHouse = Console.ReadLine();
            Console.WriteLine("input Name Address");
            string Address = Console.ReadLine();
            SqlConnection dbcontex = new SqlConnection();
            dbcontex.ConnectionString = ConfigurationManager.ConnectionStrings["WareHouseEntities"].ConnectionString;
            var update = "INSERT INTO WareHouses(WareHouse1,Address) VALUES (@NameWareHouse,@Address)";
            SqlCommand query = new SqlCommand(update, dbcontex);
            dbcontex.Open();
            query.Parameters.AddWithValue("@NameWareHouse", NameWareHouse);
            query.Parameters.AddWithValue("@Address", Address);
            query.ExecuteNonQuery();
            dbcontex.Close();
            Console.WriteLine("Add sucsess ! ");
        }
        public void DeleteWareHouse()
        {
            Console.WriteLine("input Name Address");
            int ID =Helper.InputIntNumber();
            SqlConnection dbcontex = new SqlConnection();
            dbcontex.ConnectionString = ConfigurationManager.ConnectionStrings["WareHouseEntities"].ConnectionString;
            var Delete = "DELETE FROM WareHosues WHERE ID = @ID";
            SqlCommand query = new SqlCommand(Delete, dbcontex);
            dbcontex.Open();
            query.Parameters.AddWithValue("@NameWareHouse", ID);
            query.ExecuteNonQuery();
            dbcontex.Close();
            Console.WriteLine("Delete sucsess ! ");
        }
        
    }
}
