using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductSeller
{
    class Data
    {
        private static List<Products> list = new List<Products>();
        public static List<Products> List
        {
            get => list;
            set => list = value;
        }
        public static int Count_item(){ return List.Count(); }
        
        private static int _id;
        private static int _getLastId;
        public static int Id { get => _id; set => _id = value; }
        public static int GetLastId { get => _getLastId; set => _getLastId = value; }

        // Temp Memory //
        private static string temp_pname;
        private static string temp_qty;
        private static string temp_uprice;
        
        public static string Temp_pname { get => temp_pname; set => temp_pname = value; }
        public static string Temp_qty { get => temp_qty; set => temp_qty = value; }
        public static string Temp_uprice { get => temp_uprice; set => temp_uprice = value; }

        //Converter to Price Double with $ sign
        public static double PriceToDouble(string uprice)
        {
            double real_price = 0;
            string[] hack_text = uprice.Split('$');
            string data = "";
            foreach (string temp in hack_text)
            {
                if (temp == "$")
                    continue;
                else
                    data += temp;
            }
            try
            {
                real_price = double.Parse(data);
            }
            catch (Exception)
            {
                return real_price = 0;
            }

            return real_price;
        }
    }
}
