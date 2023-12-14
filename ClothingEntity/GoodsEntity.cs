using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingEntity
{
    public class GoodsEntity
    {
        public int GoodsID { get; set; }
        public string BarCode { get; set; }
        public int TypeID { get; set; }
        public string GoodsName { get; set; }
        public double StorePrice { get; set; }
        public double SalePrice { get; set; }
        public double Discount { get; set; }
        public int StockNum { get; set; }
        public string StockDate { get; set; }
        public string TypeName { get; set; }
    }
}
