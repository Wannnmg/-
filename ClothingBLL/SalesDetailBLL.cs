using ClothingDAL;
using ClothingEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingBLL
{
    public class SalesDetailBLL
    {
        SalesDetailDAL salesDetailDAL=new   SalesDetailDAL();
        SalesDetailEntity salesDetailEntity=new SalesDetailEntity();
        public int insertSalesDetail(SalesDetailEntity salesDetailEntity)
        {
            
            return salesDetailDAL.insertSalesDetail(salesDetailEntity);
        }
    }
}
