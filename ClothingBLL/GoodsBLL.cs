using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothingDAL;
using ClothingEntity;

namespace ClothingBLL
{
    public class GoodsBLL
    {
        GoodsDAL GoodsDAL=new GoodsDAL();
        public DataTable select(string ID, string Name, string StartTime, string EndTime, string Class,string str)
        {
            
            return GoodsDAL.select(ID,Name,StartTime,EndTime,Class,str);
        }
        public DataTable select(string ID)
        {

            return GoodsDAL.select(ID);
        }
        public int insertGooods(GoodsEntity goodsEntity)
        {
            
            int no = GoodsDAL.insertGooods(goodsEntity);
            return no;
        }
        //修改
        public int UpdateGooods(GoodsEntity goodsEntity)
        {
            int no = GoodsDAL.UpdateGooods(goodsEntity);
            return no;
        }
        public int UpdateGooods(string BarCode, int Num)
        {
            
            return GoodsDAL.UpdateGooods(BarCode,Num);
        }
    }
}
