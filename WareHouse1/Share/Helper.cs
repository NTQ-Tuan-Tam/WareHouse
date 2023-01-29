using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouse1.Share
{
   public static class Helper
    {

        public static float InputFloatNumber()
        {
            try
            {
                return float.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.Write("\tInvalid input, please try again: ");
                return InputFloatNumber();
            }
        }

        public static int InputIntNumber()
        {
            try
            {
                return int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.Write("\tInvalid input, please try again: ");
                return InputIntNumber();
            }
        }
        
    }
}
