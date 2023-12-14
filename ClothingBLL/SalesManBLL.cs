using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothingEntity;
using ClothingDAL;

namespace ClothingBLL
{
    public class SalesManBLL
    {
        SalesManDAL manDAL=new SalesManDAL();
        public DataTable GetIdSelect(SalesManEntity salesMan)
        {
            return manDAL.GetIdSelect(salesMan);
        }
        public DataTable GetSelect()
        {
            return manDAL.GetSelect();
        }
        public int insertMan(SalesManEntity salesManEntity)
        {
            return manDAL.insertMan(salesManEntity);
        }
        public int updateMan(SalesManEntity salesManEntity)
        {
            return manDAL.UpdatetMan(salesManEntity);
        }
        public int deleteMan(SalesManEntity salesManEntity)
        {
            return manDAL.DeleteMan(salesManEntity);
        }
        public DataTable GetShoopingSelect()
        {
            return manDAL.GetShoopingSelect();
        }
    }
}
