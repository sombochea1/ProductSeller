using System;
using System.IO;
using System.Windows.Forms;

namespace ProductSeller
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
           
            txtID.Text = Data.Id + "";
            int id = int.Parse(txtID.Text);
            string pname = txtPname.Text.Trim();
            int qty = int.Parse(txtQty.Text);
            double uprice = double.Parse(txtPrice.Text);

            Products product = new Products(id, pname, qty, uprice);
            Data.List.Add(product);
            listView.Items.Add(product.item());

            Data.Temp_pname = "";
            Data.Temp_qty = "";
            Data.Temp_uprice = "";

            txtID.Clear();
            txtPname.Clear();
            txtQty.Clear();
            txtPrice.Clear();

            Data.Id++;
            txtID.Text = Data.Id + "";

        }

        private void btnView_Click(object sender, EventArgs e)
        {

            if (txtPname.Text!="" || txtQty.Text!="" || txtPrice.Text!="")
            {
                string pname = txtPname.Text;
                string qty = txtQty.Text;
                string uprice = txtPrice.Text;

                Data.Temp_pname = pname;
                Data.Temp_qty = qty;
                Data.Temp_uprice = uprice;
                
            }

            this.Hide();
            new ViewProduct().Show();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (Data.List.Count > 0)
            {
                foreach (Products temp in Data.List)
                {
                    listView.Items.Add(temp.item());
                    Data.GetLastId = temp.Id;
                }
            }
            else
            {
                Data.GetLastId = 0;
                Data.Id = 1;
            }
            
            if (Data.Id == Data.GetLastId)
                Data.Id++;
            else
                Data.Id = Data.GetLastId+1;

            txtID.Text = Data.Id + "";


            if(Data.Temp_pname!="" || Data.Temp_qty!="" || Data.Temp_uprice != "")
            {
                txtPname.Text = Data.Temp_pname;
                txtQty.Text = Data.Temp_qty;
                txtPrice.Text = Data.Temp_uprice;
            }

        }

        bool lbCheck = false;
        bool lbCheck2 = false;

        private void txtPname_TextChanged(object sender, EventArgs e)
        {
            if (txtPname.Text.Trim() != "")
            {
                lbRequred.Text = "";
            }
            else
            {
                Data.Temp_pname = "";
                lbRequred.Text = "*";
            }

            check_qty_price();


        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            int qty_check = 0;

            if (txtQty.Text.Trim() != "")
            {
                try
                {
                    int qty = int.Parse(txtQty.Text);
                    qty_check = qty;

                    if (qty_check > 0)
                    {
                        lbRequred2.Text = "";
                        lbCheck = true;
                    }
                    else
                    {
                        lbCheck = false;
                        lbRequred2.Text = "*";
                    }
                }
                catch (Exception)
                {
                    lbCheck = false;
                    lbRequred2.Text = "*";
                }
            }
            else
            {
                Data.Temp_qty = "";
                lbCheck = false;
                lbRequred2.Text = "*";
            }

            check_qty_price();

        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            double price_check = 0;

            if (txtPrice.Text.Trim() != "")
            {
                try
                {
                    double price = double.Parse(txtPrice.Text);
                    price_check = price;

                    if (price_check > 0)
                    {
                        lbRequred3.Text = "";
                        lbCheck2 = true;
                    }
                    else
                    {
                        lbCheck2 = false;
                        lbRequred3.Text = "*";
                    }
                }
                catch (Exception)
                {
                    lbCheck2 = false;
                    lbRequred3.Text = "*";
                }
            }
            else
            {
                Data.Temp_uprice = "";
                lbCheck2 = false;
                lbRequred3.Text = "*";
            }

            check_qty_price();

        }

        private void check_qty_price()
        {
            if (txtPname.Text.Trim() != "" && txtQty.Text != "" && txtPrice.Text != "" && lbCheck != false && lbCheck2 != false)
                btnAdd.Enabled = true;
            else
                btnAdd.Enabled = false;
        }
        
        //Over testing data file
        private void btnUseDataFile_Click(object sender, EventArgs e)
        {

            Products p = new Products();
            ListViewItem it;

            string d1 = File.ReadAllText("mydata.txt");
            string[] d2 = p.ToStringList(d1);
            foreach (string temp in d2)
            {
                string[] d4 = p.ToStringArray(temp);
                it = new ListViewItem(d4);
                listView.Items.Add(it);
            }

            
        }
    }
}
