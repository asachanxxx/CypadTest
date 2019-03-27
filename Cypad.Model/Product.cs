using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cypad.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string ProCode { get; set; }
        public string ProName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal WsPrice { get; set; }
        public decimal SellingPrice { get; set; }

    }
}
