using System;
using System.Windows.Forms;

namespace ProductSeller
{
    public partial class ViewProduct : Form
    {
        public ViewProduct()
        {
            InitializeComponent();
        }
        
        private void ViewProduct_Load(object sender, EventArgs e)
        {
            if(Data.List.Count > 0)
            {
                foreach (Products temp in Data.List)
                    listView.Items.Add(temp.item());
            }

            btnUpdate.Enabled = false;
            btnDel.Enabled = false;
            txtPname.Enabled = false;
            txtPrice.Enabled = false;
            txtQty.Enabled = false;
            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Dispose();
            new frmMain().Show();
        }

        private void ViewProduct_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private bool active_update = false;
        private ListViewItem item_selected;

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 0)
            {
                btnDel.Enabled = false;
                txtPname.Enabled = false;
                txtPrice.Enabled = false;
                txtQty.Enabled = false;
                active_update = false;

                txtID.Clear();
                txtPname.Clear();
                txtQty.Clear();
                txtPrice.Clear();

                lbRequred.Text = "";
                lbRequred2.Text = "";
                lbRequred3.Text = "";

                return;
            }

            item_selected = listView.SelectedItems[0];

            txtID.Text = item_selected.Text;
            txtPname.Text = item_selected.SubItems[1].Text;
            txtQty.Text = item_selected.SubItems[2].Text;
            txtPrice.Text = Data.PriceToDouble(item_selected.SubItems[3].Text)+"";

            btnDel.Enabled = true;
            txtPname.Enabled = true;
            txtPrice.Enabled = true;
            txtQty.Enabled = true;

            active_update = true;

    }

        private void btnDel_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView.SelectedItems)
            {
                int index = item.Index;
                listView.Items.Remove(item);
                Data.List.RemoveAt(index);
            }

            txtPname.Clear();
            txtQty.Clear();
            txtPrice.Clear();

            lbRequred.Text = "";
            lbRequred2.Text = "";
            lbRequred3.Text = "";

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int index = -1;
            if (listView.SelectedItems.Count > 0)
            {
                index = listView.Items.IndexOf(listView.SelectedItems[0]);
            }

            int id = int.Parse(txtID.Text);
            string pname = txtPname.Text.Trim();
            int qty = int.Parse(txtQty.Text);
            double uprice = double.Parse(txtPrice.Text);

            Products product = new Products(id, pname, qty, uprice);

            if (index != -1)
            {
                Data.List[index] = product;
                listView.Items.RemoveAt(index);
                listView.Items.Insert(index, product.item());
            }

            txtID.Clear();
            txtPname.Clear();
            txtQty.Clear();
            txtPrice.Clear();

        }

        private void txtPname_TextChanged(object sender, EventArgs e)
        {
            bool lbCheck = false;
            bool lbCheck2 = false;
            bool lbCheck3 = false;
            int qty_check = 0;
            double price_check = 0;

            if (txtPname.Text.Trim() != "")
            {
                lbRequred.Text = "";
                lbCheck3 = true;
            }
            else
            {
                lbCheck3 = false;
                lbRequred.Text = "*";
            }
            
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
                btnDel.Enabled = false;
                lbCheck = false;
                lbRequred2.Text = "*";
            }

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
                btnDel.Enabled = false;
                lbCheck2 = false;
                lbRequred3.Text = "*";
            }

            if (lbCheck3 && lbCheck && lbCheck2)
            {
                
                if (active_update)
                {
                    if (txtID.Text.Trim() == item_selected.Text &&
                       txtPname.Text.Trim() == item_selected.SubItems[1].Text &&
                       txtQty.Text.Trim() == item_selected.SubItems[2].Text &&
                       (Data.PriceToDouble(txtPrice.Text) == Data.PriceToDouble(item_selected.SubItems[3].Text))) 
                    {
                        
                        btnUpdate.Enabled = false;
                        btnDel.Enabled = true;
                    }
                    else
                    {
                        btnUpdate.Enabled = true;
                        btnDel.Enabled = false;
                    }
                }
            }
            else
            {
                btnUpdate.Enabled = false;
                btnDel.Enabled = false;
            }

        }
    }
}
