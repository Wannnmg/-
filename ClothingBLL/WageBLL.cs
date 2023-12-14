using ClothingDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingBLL
{
    public class WageBLL
    {
        WageDAL WageDAL=new WageDAL();
        public DataTable SelectWage(string start, string end)
        {
           
            return WageDAL.SelectWage(start,end);
        }
    }
}
