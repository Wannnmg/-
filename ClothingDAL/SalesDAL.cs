using ClothingEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingDAL
{
    public class SalesDAL
    {
        //添加
        public int insertSales(SalesEntity salesEntity)
        {
            DBHelper.PrepareSql("insert into Sales(ReceiptsCode,SalesDate,AllMoney,SalesmanID,CashierID) values(@ReceiptsCode,getdate(),@AllMoney,@SalesmanID,@CashierID)");
            DBHelper.SetParameter("ReceiptsCode", salesEntity.ReceiptsCode);
            DBHelper.SetParameter("AllMoney", salesEntity.AllMoney);
            DBHelper.SetParameter("SalesmanID", salesEntity.SalesmanID);
            DBHelper.SetParameter("CashierID", salesEntity.CashierID);
            int no= DBHelper.ExecNonQuery();
            return no;
        }
        //根据流水号查询记录
        public DataTable SelectID(String id)
        {
            DBHelper.PrepareSql("select * from Sales where ReceiptsCode=@ReceiptsCode");
            DBHelper.SetParameter("ReceiptsCode", id);
            DataTable dt= DBHelper.ExecQuery();
            return dt;
        }
        //查询出每笔流水号订单的利润额
        public DataTable SelectProfit(string Start,string end,string salesman)
        {
            string str = @"select sales.ReceiptsCode 小票流水,SalesDate 购物日期,sales.AllMoney 购物金额,money.allmoney 单笔利润,
              salesman.SalesmanName 导购员姓名,cashierman.SalesmanName 收银员姓名 from sales 
              left join SalesMan salesman on sales.SalesmanID=salesman.SalesmanID 
              left join SalesMan cashierman on sales.CashierID=cashierman.SalesmanID
              left join 
              (select ReceiptsCode,salesmoney.allmoney from Sales inner join 
              (select SalesID,Sum(Convert(decimal(8,2),((GoodsMoney/Quantity)-StorePrice)   *Quantity))          allmoney   from SalesDetail inner join Goods on      SalesDetail.GoodsID=Goods.GoodsID   group  by     SalesID)   salesmoney
              on Sales.SalesID=salesmoney.SalesID) money on Sales.ReceiptsCode=money.ReceiptsCode       where         SalesDate between @Start and @end";
            if (salesman!="--请选择--")
            {
                str += " and salesman.SalesmanName= @SalesmanName";
                
            }
            DBHelper.PrepareSql(str);
            
            DBHelper.SetParameter("Start", Start);
            DBHelper.SetParameter("end", end);
            DBHelper.SetParameter("SalesmanName", salesman);
            DataTable dt= DBHelper.ExecQuery();
            return dt;
        }
    }
}
