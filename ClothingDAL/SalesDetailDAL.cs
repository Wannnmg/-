using ClothingEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingDAL
{
    public class SalesDetailDAL
    {
        public int insertSalesDetail(SalesDetailEntity salesDetailEntity)
        {
            DBHelper.PrepareSql("insert into SalesDetail(SalesID,GoodsID,Quantity,GoodsMoney) values(@SalesID,@GoodsID,@Quantity,@GoodsMoney)");
            DBHelper.SetParameter("SalesID", salesDetailEntity.SalesID);
            DBHelper.SetParameter("GoodsID", salesDetailEntity.GoodsID);
            DBHelper.SetParameter("Quantity", salesDetailEntity.Quantity);
            DBHelper.SetParameter("GoodsMoney", salesDetailEntity.GoodsMoney);
            int no = DBHelper.ExecNonQuery();
            return no;
        }
    }
}
