using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cypad.Model
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public int OrderHederId { get; set; }
        public int ProductId { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal CostPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal Qty { get; set; }
        public decimal TotalAmount { get; set; }

    }
}
