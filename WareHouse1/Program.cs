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
            Console.WriteLine("=== Menu Management===");
            Console.WriteLine("[1].Management Product");
            Console.WriteLine("[2].Management  Category Product ");
            Console.WriteLine("[3].Management WareHose");
            var loop = true;
            while (loop)
            {

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
                                break;
                            case "2":
                                _product.AddNewProduct();
                                break;
                            case "3":
                                _product.UpdateProduct();
                                break;
                            case "4":
                                _product.DetailProduct();
                                break;
                            case "5":
                                _product.DeleteProduct();
                                break;
                            case "Q":
                                
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
                                break;
                            case "2":
                                _Category.GroupCategory();
                                break;
                            case "3":
                                _Category.AddCartegory();
                                break;
                            case "4":
                                _Category.DeLeteCartegory();
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
                                break;
                            case "2":
                                WareHouse.ListGroupAddressWarehouse();
                                break;
                            case "3":
                                WareHouse.AddWareHouse();
                                break;
                            case "4":
                                WareHouse.DeleteWareHouse();
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
