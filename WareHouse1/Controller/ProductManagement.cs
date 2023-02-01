using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Migrations.Model;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using WareHouse1.Models;
using WareHouse1.Share;

namespace WareHouse1.Controller
{
    public class ProductManagement
    {
        public void ManagementProduct()
        {
            Console.Clear();
            Console.WriteLine("=== Management Product ===");
            Console.WriteLine("[1]. Show list Prodct");
            Console.WriteLine("[2]. Add new Prodct ");
            Console.WriteLine("[3]. Update Prodct ");
            Console.WriteLine("[4]. Show Detail Prodct ");
            Console.WriteLine("[5]. Delete Prodct ");
            Console.WriteLine("[Q]. Quit Prodct ");
        }
        
        public void ShowListProduct()
        {
            Console.WriteLine("=== ListProduct ===");
            SqlConnection dbcontext = new SqlConnection();

            Console.WriteLine($"{"ID", -15}{"NamePrduct", -20}{"Color",-10}{"Price",-10}{"Stok",-10}{"Category", -15}{"WareHouse",-15}{"Address",-10}");
            
            dbcontext.ConnectionString = ConfigurationManager.ConnectionStrings["WareHouseEntities"].ConnectionString;
            try
            {
                SqlCommand query = new SqlCommand("Select IDProduct,NameProduct,Color,Price,Stok,NameCategory,WareHouse1,Address " +
                             " From Products AS P " +
                             "INNER JOIN Categories AS C " +
                             "ON P.IDCategory = C.ID " +
                             "INNER JOIN WareHouses AS W  " +
                             "ON P.IDWareHouse = W.ID", dbcontext);
                dbcontext.Open();
                SqlDataReader sdr = query.ExecuteReader();
                while (sdr.Read())
                {
                    Console.WriteLine($"{sdr["IDProduct"],-15}{sdr["NameProduct"],-20}{sdr["Color"],-10}{sdr["Price"],-10}{sdr["Stok"],-10}{sdr["NameCategory"],-15}{sdr["WareHouse1"],-15}{sdr["Address"],-10}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Co loi xay ra !!!" + e);
            }
            finally
            {
                dbcontext.Close();
            }



        }
        public void AddNewProduct()
        {
            Console.Write("Input nameproduct: ");
            var NameProduct = Console.ReadLine();
            Console.Write("Input Color: ");
            var color = Console.ReadLine(); 
            Console.Write("Input Price: ");
            var price = Helper.InputFloatNumber();
            Console.Write("Input stokl: ");
            var stok = Helper.InputFloatNumber();
            CategoriesManagement categories = new CategoriesManagement();
            categories.ListCartegory();
            Console.Write("Input ID Category: ");
            var idcategoey = Helper.InputIntNumber();
            WareHouseManagement wareHouseManagement= new WareHouseManagement();
            wareHouseManagement.ListWarehouse();
            Console.Write("Input ID WareHosue: ");
            var idWareHouse = Helper.InputIntNumber();
           
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["WareHouseEntities"].ConnectionString;
           var add = "INSERT INTO Products (NameProduct,Color,Price,Stok,IDCategory,IDWareHouse)" + " VALUES (@NameProduct,@Color,@Price,@Stok,@IDCategory,@IDWareHouse)";
                                           
            SqlCommand cmd = new SqlCommand(add, connection);
            cmd.Parameters.AddWithValue("@NameProduct", NameProduct);
            cmd.Parameters.AddWithValue("@Color", color);
            cmd.Parameters.AddWithValue("@Price",price );
            cmd.Parameters.AddWithValue("@Stok", stok);
            cmd.Parameters.AddWithValue("@IDCategory", idcategoey);
            cmd.Parameters.AddWithValue("@IDWareHouse", idWareHouse);
            connection.Open();
            cmd.ExecuteNonQuery();
            Console.WriteLine("Them moi du lieu thanh cong !!!");



        }
        
        public void UpdateProduct()
        {
            Console.Write("input idproduct: ");
            var IDProduct = Helper.InputIntNumber();
            Console.Write("Input nameproduct: ");
            var NameProduct = Console.ReadLine();
            Console.Write("Input Color: ");
            var color = Console.ReadLine();
            Console.Write("Input Price: ");
            var price = Helper.InputFloatNumber();
            Console.Write("Input stokl: ");
            var stok = Helper.InputFloatNumber();
            CategoriesManagement categories = new CategoriesManagement();
            categories.ListCartegory();
            Console.Write("Input ID Category: ");
            var idcategoey = Helper.InputIntNumber();
            WareHouseManagement wareHouseManagement = new WareHouseManagement();
            wareHouseManagement.ListWarehouse();
            Console.Write("Input ID WareHosue: ");
            var idWareHouse = Helper.InputIntNumber();


            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["WareHouseEntities"].ConnectionString;
            connection.Open();



            var update = "UPDATE Products " +
                         "SET NameProduct = @NameProduct,Color = @Color,Price = @Price,Stok = @Stok,IDCategory = @IDCategory,IDWareHouse = @IDWareHouse " +
                         "WHERE IDProduct = @IDProduct";
            SqlCommand cmd = new SqlCommand(update, connection);
            cmd.Parameters.AddWithValue("@IDProduct", IDProduct);
            cmd.Parameters.AddWithValue("@NameProduct", NameProduct);
            cmd.Parameters.AddWithValue("@Color", color);
            cmd.Parameters.AddWithValue("@Price", price);
            cmd.Parameters.AddWithValue("@Stok", stok);
            cmd.Parameters.AddWithValue("@IDCategory", idcategoey);
            cmd.Parameters.AddWithValue("@IDWareHouse", idWareHouse);
           
            cmd.ExecuteNonQuery();
            Console.WriteLine("update thanhcng");
            connection.Close();
            
        }
        public void DetailProduct()
        {
            
            SqlConnection dbcontext = new SqlConnection();

            dbcontext.ConnectionString = ConfigurationManager.ConnectionStrings["WareHouseEntities"].ConnectionString;
            try
            {
                ShowListProduct();
                Console.WriteLine("Nhap ID Detail Product: ");
                var IDProduct = Helper.InputFloatNumber();
                Console.WriteLine($"{"ID",-10}{"NameProduct",-15}{"Color",-10}{"Price",-10}{"Stok",-10}{"IDCategory",-15}{"IDWareHouse",-10}");
                SqlCommand query = new SqlCommand("Select IDProduct,NameProduct,Color,Price,Stok,NameCategory,WareHouse1,Address " +
                                                     " From Products AS P " +
                                                     "INNER JOIN Categories AS C " +
                                                     "ON P.IDCategory = C.ID " +
                                                     "INNER JOIN WareHouses AS W  " +
                                                     "ON P.IDWareHouse = W.ID " +
                                                     "WHERE IDProduct = @IDProduct ", dbcontext);
                query.Parameters.AddWithValue("@IDProduct", IDProduct);//chuyen gia tri 
                dbcontext.Open();
                SqlDataReader sdr = query.ExecuteReader();
                while (sdr.Read())
                {
                    Console.WriteLine($"{sdr["IDProduct"],-10}{sdr["NameProduct"],-15}{sdr["Color"],-10}{sdr["Price"],-10}{sdr["Stok"],-10}{sdr["NameCategory"],-15}{sdr["WareHouse1"],-10}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Co loi xay ra !!!" + e);
            }
            finally
            {
                dbcontext.Close();
            }

        }
        public void DeleteProduct()
        {
            SqlConnection dbcontext = new SqlConnection();



            dbcontext.ConnectionString = ConfigurationManager.ConnectionStrings["WareHouseEntities"].ConnectionString;
            try
            {
                Console.WriteLine("Nhap ID Detail Product: ");
                var IDProduct = Helper.InputFloatNumber();
                SqlCommand query = new SqlCommand("Delete From Products Where IDProduct = @IDProduct ", dbcontext);
                query.Parameters.AddWithValue("@IDproduct", IDProduct);//chuyen gia tri 
                dbcontext.Open();
                
                SqlDataReader sdr = query.ExecuteReader();
                Console.WriteLine("done delete product");
            }
            catch (Exception e)
            {
                Console.WriteLine("Co loi xay ra !!!" + e);
            }
            finally
            {
                dbcontext.Close();
            }
        }
       
    }
}
