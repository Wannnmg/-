using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothingEntity;

namespace ClothingDAL
{
    public class GoodsDAL
    {
        //根据多条件查询
        public DataTable select(string ID,string Name,string StartTime,string EndTime,string Class,string str)
        {
            string sql = "select * from Goods inner join [Type] on Goods.TypeID=[Type].TypeID where 1=1";
            if (ID != "")
                sql += " and BarCode=@BarCode";
            if (Name != "")
                sql += " and GoodsName like '%"+Name+"%'";
            if (str!="全部")
            {
                sql += string.Format(" and StockDate between '{0}' and '{1}'", StartTime, EndTime);
            }
            
            if (Class != "--请选择--")
            {
                sql += " and TypeName=@TypeName";
            }
            DBHelper.PrepareSql(sql);
            DBHelper.SetParameter("BarCode", ID);
            //DBHelper.SetParameter("GoodsName",Name);
            DBHelper.SetParameter("TypeName", Class);
            DataTable dt= DBHelper.ExecQuery();
            return dt;
        }
        //根据条码查询
        public DataTable select(string ID)
        {
            string sql = "select * from Goods inner join [Type] on Goods.TypeID=[Type].TypeID where BarCode=@BarCode";
            DBHelper.PrepareSql(sql);
            DBHelper.SetParameter("BarCode", ID);
            DataTable dt = DBHelper.ExecQuery();
            return dt;
        }
        //添加
        public int insertGooods(GoodsEntity goodsEntity)
        {
            int no = 0;
            try
            {
                DBHelper.PrepareSql("insert into Goods(BarCode,TypeID,GoodsName,StorePrice,SalePrice,Discount,StockNum,StockDate) values(@BarCode,@TypeID,@GoodsName,@StorePrice,@SalePrice,@Discount,@StockNum,@StockDate)");
                DBHelper.SetParameter("BarCode", goodsEntity.BarCode);
                DBHelper.SetParameter("TypeID", goodsEntity.TypeID);
                DBHelper.SetParameter("GoodsName", goodsEntity.GoodsName);
                DBHelper.SetParameter("StorePrice", goodsEntity.StorePrice);
                DBHelper.SetParameter("SalePrice", goodsEntity.SalePrice);
                DBHelper.SetParameter("Discount", goodsEntity.Discount);
                DBHelper.SetParameter("StockNum", goodsEntity.StockNum);
                DBHelper.SetParameter("StockDate", goodsEntity.StockDate);
                no = DBHelper.ExecNonQuery();
                return no;
            }
            catch (Exception)
            {

                return no;
            }
            
        }
        //修改产品信息或进行库存增减
        public int UpdateGooods(GoodsEntity goodsEntity)
        {
            int no = 0;
            try
            {
                DBHelper.PrepareSql("update Goods set TypeID=@TypeID,GoodsName=@GoodsName,StorePrice=@StorePrice,SalePrice=@SalePrice,Discount=@Discount,StockNum=StockNum+@StockNum,StockDate=@StockDate where BarCode=@BarCode");
                DBHelper.SetParameter("TypeID", goodsEntity.TypeID);
                DBHelper.SetParameter("GoodsName", goodsEntity.GoodsName);
                DBHelper.SetParameter("StorePrice", goodsEntity.StorePrice);
                DBHelper.SetParameter("SalePrice", goodsEntity.SalePrice);
                DBHelper.SetParameter("Discount", goodsEntity.Discount);
                DBHelper.SetParameter("StockNum", goodsEntity.StockNum);
                DBHelper.SetParameter("StockDate", goodsEntity.StockDate);
                DBHelper.SetParameter("BarCode", goodsEntity.BarCode);
                no = DBHelper.ExecNonQuery();
                return no;
            }
            catch (Exception)
            {

                return no;
            }
            
            
        }
        //修改库存数量
        public int UpdateGooods(string BarCode,int Num)
        {
            int no = 0;
            try
            {
                DBHelper.PrepareSql("update Goods set StockNum=StockNum-@Num where BarCode=@BarCode");
                DBHelper.SetParameter("Num", Num);
                DBHelper.SetParameter("BarCode", BarCode);
                no = DBHelper.ExecNonQuery();
                return no;
            }
            catch (Exception)
            {

                return no;
            }
            
        }
    }
}
