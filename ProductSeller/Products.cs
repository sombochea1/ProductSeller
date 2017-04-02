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
            string[] str_data_en = { id.ToString("000"), pname, qty + "", uprice.ToString("$#,##0.00"), Amount().ToString("$#,##0.00")};
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

        public double ChangeAmount(string currency)
        {
            if (currency == "KHR")
            {
                return (Qty * Uprice) * 4000;
            }
            else if (currency == "USD")
            {
                return (Qty * Uprice) / 4000;
            }
            else
            {
                MessageBox.Show("Something error!");
                return 0;
            }


        }

        public double ChangePrice(string currency)
        {
            if (currency == "KHR")
            {
                return Uprice * 4000;
            }
            else if (currency == "USD")
            {
                return Uprice / 4000;
            }
            else
            {
                MessageBox.Show("Something error!");
                return 0;
            }


        }

        public ListViewItem item(string currency)
        {
            string[] str_data_en = { Id.ToString("000"), Pname, Qty+"", ChangePrice(currency).ToString("KHR#,##0.00"), ChangeAmount(currency).ToString("KHR#,##0.00") };

            return new ListViewItem(str_data_en);
        }
        

    }
}
