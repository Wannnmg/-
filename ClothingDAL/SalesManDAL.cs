using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothingEntity;

namespace ClothingDAL
{
    public class SalesManDAL
    {
        //通过账号获取详细信息
        public DataTable GetIdSelect(SalesManEntity salesMan)
        {
            DBHelper.PrepareSql("Select * from SalesMan where Mobile=@Mobile");
            DBHelper.SetParameter("Mobile", salesMan.Mobile);
            DataTable dt= DBHelper.ExecQuery();
            return dt;
        }
        //获取全部信息
        public DataTable GetSelect()
        {
            DBHelper.PrepareSql("select * from SalesMan");
             DataTable dataTable= DBHelper.ExecQuery();
            return dataTable;
        }
        //查询导购员的信息
        public DataTable GetShoopingSelect()
        {
            DBHelper.PrepareSql("select * from SalesMan where Role='导购员'");
            DataTable dataTable = DBHelper.ExecQuery();
            return dataTable;
        }
        //添加员工
        public int insertMan(SalesManEntity salesMan)
        {
            DBHelper.PrepareSql("insert into SalesMan(SalesmanName,Mobile,Pwd,Gender,Wage,CommissionRate,Role) values(@SalesmanName,@Mobile,@Pwd,@Gender,@Wage,@CommissionRate,@Role)");
            DBHelper.SetParameter("SalesmanName", salesMan.SalesmanName);
            DBHelper.SetParameter("Mobile", salesMan.Mobile);
            DBHelper.SetParameter("Pwd", salesMan.Pwd);
            DBHelper.SetParameter("Gender", salesMan.Gender);
            DBHelper.SetParameter("Wage", salesMan.Wage);
            DBHelper.SetParameter("CommissionRate", salesMan.CommissionRate);
            DBHelper.SetParameter("Role", salesMan.Role);
            int No = DBHelper.ExecNonQuery();
            return No;
        }
        //修改员工
        public int UpdatetMan(SalesManEntity salesMan)
        {
            DBHelper.PrepareSql("update SalesMan set SalesmanName=@SalesmanName,Mobile=@Mobile,Pwd=@Pwd,Gender=@Gender,Wage=@Wage,CommissionRate=@CommissionRat,Role=@Role where SalesmanID=@SalesmanID");
            DBHelper.SetParameter("SalesmanName", salesMan.SalesmanName);
            DBHelper.SetParameter("Mobile", salesMan.Mobile);
            DBHelper.SetParameter("Pwd", salesMan.Pwd);
            DBHelper.SetParameter("Gender", salesMan.Gender);
            DBHelper.SetParameter("Wage", salesMan.Wage);
            DBHelper.SetParameter("CommissionRat", salesMan.CommissionRate);
            DBHelper.SetParameter("Role", salesMan.Role);
            DBHelper.SetParameter("SalesmanID", salesMan.SalesmanID);
            int No = DBHelper.ExecNonQuery();
            return No;
        }
        //删除员工
        public int DeleteMan(SalesManEntity salesMan)
        {
            DBHelper.PrepareSql("delete from salesMan where SalesmanID=@SalesmanID");
            DBHelper.SetParameter("SalesmanID", salesMan.SalesmanID);
            int No = DBHelper.ExecNonQuery();
            return No;
        }
    }
}
