using ClothingDAL;
using ClothingEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingBLL
{
    public class SalesBLL
    {
        SalesDAL salesDAL=new   SalesDAL();
        public int insertSales(SalesEntity salesEntity)
        {

            return salesDAL.insertSales(salesEntity);
        }
        public DataTable SelectID(String id)
        {
            
            return salesDAL.SelectID(id);
        }
        public DataTable SelectProfit(string Start, string end, string salesman)
        {
            
            return salesDAL.SelectProfit(Start,end, salesman);
        }
    }
}
