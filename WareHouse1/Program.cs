using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WareHouse1.Controller;
using WareHouse1.Models;

namespace WareHouse1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Management management = new Management();
            var loop = true;
            while (loop)
            {
                //Console.WriteLine("=== Menu Management===");
                //Console.WriteLine("[1].Management Product");
                //Console.WriteLine("[2].Management  Category Product ");
                //Console.WriteLine("[3].Management WareHose");
                management.ShowMenuManagement();
                Console.Write(">>>Input selection: ");
                var select = Console.ReadLine();
                switch (select.ToUpper())
                {
                    
                    case "1":
                        ProductManagement _product = new ProductManagement();
                        _product.ManagementProduct();
                        var option1 = Console.ReadLine();

                        switch (option1.ToUpper())
                        {
                            case "1":
                                _product.ShowListProduct();
                                Console.ReadKey();
                                break;
                            case "2":
                                _product.AddNewProduct();
                                Console.ReadKey();
                                break;
                            case "3":
                                _product.UpdateProduct();
                                Console.ReadKey();
                                break;
                            case "4":
                                _product.DetailProduct();
                                Console.ReadKey();
                                break;
                            case "5":
                                _product.DeleteProduct();
                                Console.ReadKey();
                                break;
                            case "Q":
                                Console.ReadKey();
                                break;
                            default:
                                Console.WriteLine("Invalid selection Product!");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                        }
                        break;
                    case "2":
                        CategoriesManagement _Category = new CategoriesManagement();
                        _Category.CartegoryManagrnt();
                        var option2 = Console.ReadLine();
                        switch (option2.ToUpper())
                        {
                            case "1":
                                _Category.ListCartegory();
                                Console.ReadKey();
                                break;
                            case "2":
                                _Category.GroupCategory();
                                Console.ReadKey();
                                break;
                            case "3":
                                _Category.AddCartegory();
                                Console.ReadKey();
                                break;
                            case "4":
                                _Category.DeLeteCartegory();
                                Console.ReadKey();
                                break;
                            case "Q":

                                break;
                        }
                        break;
                    case"3":
                        WareHouseManagement WareHouse = new WareHouseManagement();
                        WareHouse.WareHouseOption();
                        var WareHouseOption = Console.ReadLine();
                        switch (WareHouseOption.ToUpper())
                        {
                            case"1":
                                WareHouse.ListWarehouse();
                                Console.ReadKey();
                                break;
                            case "2":
                                WareHouse.ListGroupAddressWarehouse();
                                Console.ReadKey();
                                break;
                            case "3":
                                WareHouse.AddWareHouse();
                                Console.ReadKey();
                                break;
                            case "4":
                                WareHouse.DeleteWareHouse();
                                Console.ReadKey();
                                break;
                            case "Q":

                                break;
                        }
                        break;


                    default:
                        Console.WriteLine("Invalid selection!");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }

        }


    }
}
