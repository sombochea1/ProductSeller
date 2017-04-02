using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductSeller
{
    public partial class PrintPreview : Form
    {
        public PrintPreview()
        {
            InitializeComponent();
        }

        private void PrintPreview_Load(object sender, EventArgs e)
        {
            if(Data.List.Count > 0)
            {
                txtPrintDoc.AppendText(Data.PrintDoc(Data.List));
            }
        }
    }
}
