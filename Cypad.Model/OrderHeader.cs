using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cypad.Model
{
    public class OrderHeader
    {
        public int Id { get; set; }
        public int DocumentNo { get; set; }
        public int CustomerId { get; set; }
        public decimal ItemTotalDiscount { get; set; }
        public decimal SubTotalDiscount { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal GrossTotal { get; set; }
        public decimal NetTotal { get; set; }
        public decimal TotalGp { get; set; }
        public decimal ExpectedGp { get; set; }
        public decimal GpDeviation { get; set; }


    }
}
