using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductSeller
{
    public static class currency
    {
        private static List<Products> _tempList = new List<Products>();

        public static List<Products> TempList { get => _tempList; set => _tempList = value; }
        
        
    }
}
