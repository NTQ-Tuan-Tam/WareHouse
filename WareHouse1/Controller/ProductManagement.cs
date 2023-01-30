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
            Console.WriteLine("ListProduct");
            SqlConnection dbcontext = new SqlConnection();

            Console.WriteLine($"{"ID", -5}{"Name", -10}{"Color",-10}{"Price",-10}{"Stok",-10}{"Category", -15}{"WareHouse",-15}{"Address",-10}");
            
            dbcontext.ConnectionString = ConfigurationManager.ConnectionStrings["WareHouseEntities"].ConnectionString;
            try
            {
                // viết câu lệnh query truy xuất dữ liệu
                
                SqlCommand query = new SqlCommand("Select IDProduct,NameProduct,Color,Price,Stok,NameCategory,WareHouse1,Address " +
                             " From Products AS P " +
                             "INNER JOIN Categories AS C " +
                             "ON P.IDCategory = C.ID " +
                             "INNER JOIN WareHouses AS W  " +
                             "ON P.IDWareHouse = W.ID", dbcontext);
                // mở chuỗi kết nối
                dbcontext.Open();
                // sử dụng phương thức ExecuteReader() để thực thi câu lệnh
                SqlDataReader sdr = query.ExecuteReader();
                // sử dụng vòng lặp while để lấy hết dữ liệu có trong bảng
                while (sdr.Read())
                {
                    // hiển thị dữ liệu ra màn hình
                    Console.WriteLine(sdr["IDProduct"] + "    " + 
                        sdr["NameProduct"] + "    " + 
                        sdr["Color"] + "    " + 
                        sdr["Price"] + "      " +
                        sdr["Stok"]+ "       " + 
                        sdr["NameCategory"] + "        " + 
                        sdr["WareHouse1"] + "    " +
                        sdr["Address"]);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Co loi xay ra !!!" + e);
            }
            // dóng chuỗi kết nối
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
            Console.Write("Input IDCategory: ");
            var idcategoey = Helper.InputFloatNumber();
            Console.Write("Input IDWareHosue: ");
            var idWareHouse = Helper.InputFloatNumber();
           
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["WareHouseEntities"].ConnectionString;
             //var command = new SqlCommand();
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
            Console.Write("Input IDCategory: ");
            var idcategoey = Helper.InputFloatNumber();
            Console.Write("Input IDWareHosue: ");
            var idWareHouse = Helper.InputFloatNumber();
            
            
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
            //Console.WriteLine("input ID Product detail: ");
            //var IDProduct = Helper.InputIntNumber();
            //SqlConnection connection = new SqlConnection();
            //connection.ConnectionString = ConfigurationManager.ConnectionStrings["WareHouseEntities"].ConnectionString;
            //connection.Open();
            //var detail = "SELECT * FROM Products WHERE IDProduct = @IDProduct";
            //SqlCommand cmd = new SqlCommand(detail, connection);
            //cmd.Parameters.AddWithValue("@IDProduct", IDProduct);

            //cmd.ExecuteNonQuery();
            SqlConnection dbcontext = new SqlConnection();

            

            dbcontext.ConnectionString = ConfigurationManager.ConnectionStrings["WareHouseEntities"].ConnectionString;
            try
            {
                Console.WriteLine("Nhap ID Detail Product: ");
                var IDProduct = Helper.InputFloatNumber();
                Console.WriteLine($"{"ID",-5}{"Name",-10}{"Color",-10}{"Price",-10}{"Stok",-10}{"IDCategory",-25}{"IDWareHouse",-10}");
                // viết câu lệnh query truy xuất dữ liệu
                SqlCommand query = new SqlCommand("Select IDProduct,NameProduct,Color,Price,Stok,NameCategory,WareHouse1,Address " +
                                                     " From Products AS P " +
                                                     "INNER JOIN Categories AS C " +
                                                     "ON P.IDCategory = C.ID " +
                                                     "INNER JOIN WareHouses AS W  " +
                                                     "ON P.IDWareHouse = W.ID " +
                                                     "Where IDProduct = @IDProduct ", dbcontext);
                query.Parameters.AddWithValue("@IDproduct", IDProduct);//chuyen gia tri 
                // mở chuỗi kết nối
                dbcontext.Open();
                // sử dụng phương thức ExecuteReader() để thực thi câu lệnh
                SqlDataReader sdr = query.ExecuteReader();
                // sử dụng vòng lặp while để lấy hết dữ liệu có trong bảng
                while (sdr.Read())
                {
                    // hiển thị dữ liệu ra màn hình
                    Console.WriteLine(sdr["IDProduct"] + "    " +
                        sdr["NameProduct"] + "    " +
                        sdr["Color"] + "    " +
                        sdr["Price"] + "      " +
                        sdr["Stok"] + "     " +
                        sdr["NameCategory"] + "             " +
                        sdr["WareHouse1"] + "     " +
                        sdr["Address"]); 
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Co loi xay ra !!!" + e);
            }
            // dóng chuỗi kết nối
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
                // viết câu lệnh query truy xuất dữ liệu
                SqlCommand query = new SqlCommand("Delete From Products Where IDProduct = @IDProduct ", dbcontext);
                query.Parameters.AddWithValue("@IDproduct", IDProduct);//chuyen gia tri 
                // mở chuỗi kết nối
                dbcontext.Open();
                // sử dụng phương thức ExecuteReader() để thực thi câu lệnh
                SqlDataReader sdr = query.ExecuteReader();
                // sử dụng vòng lặp while để lấy hết dữ liệu có trong bảng
                Console.WriteLine("done delete product");
            }
            catch (Exception e)
            {
                Console.WriteLine("Co loi xay ra !!!" + e);
            }
            // dóng chuỗi kết nối
            finally
            {
                dbcontext.Close();
            }
        }
    }
}
