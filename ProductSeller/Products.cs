using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductSeller
{
    public class Products
    {
        private int id;
        private string pname;
        private int qty;
        private double uprice;

        public double Amount()
        {
            return Qty * Uprice;
        }
        public Products()
        {

        }
        public Products(int id, string pname, int qty, double uprice)
        {
            Id = id;
            Pname = pname;
            Qty = qty;
            Uprice = uprice;
        }

        public int Id { get => id; set => id = value; }
        public string Pname { get => pname; set => pname = value; }
        public int Qty { get => qty; set => qty = value; }
        public double Uprice { get => uprice; set => uprice = value; }

        public ListViewItem item()
        {
            string[] str_data_en = { id.ToString("000"), pname, qty + "", uprice.ToString(), Amount().ToString("$#,##0.00")};
            return new ListViewItem(str_data_en);
        }

        public override string ToString()
        {
            string data = "";
            data = "" + id.ToString("000") + "," + pname + "," + qty + "," + uprice + "," + Amount().ToString("$#,##0.00") + "";

            return data;
        }

        public string[] ToStringArray(string data)
        {
            string[] arr = data.Split(',');

            return arr;
        }

        public string[] ToStringList(string data)
        {
            string[] list;

            list = data.Split('\n');

            return list;
        }
    }
}
