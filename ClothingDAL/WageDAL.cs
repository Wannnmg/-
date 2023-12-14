using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingDAL
{
    public class WageDAL
    {
        //以时间为条件查询出员工的当月工资
        public DataTable SelectWage(string start,string end)
        {
            DBHelper.PrepareSql(@"declare @AllSumMoney decimal(10,2)
                 select @AllSumMoney=(select sum(AllMoney) from Sales where SalesDate between @start and @end)
                 if @AllSumMoney is null
                 	set @AllSumMoney = 0
                 select SalesmanID 员工ID,SalesmanName 员工姓名,[Role] 员工职位,Mobile 员工电话,Wage 基本工资,
                 case
                  when [Role]='收银员' then 0.00
                  else CommissionRate
                 end 提成比例
                 ,
                 case
                  when [role]='店长' then @AllSumMoney
                  when AllMoney is null then 0
                  else AllMoney
                 end 销售额
                 ,
                 case 
                  when [role]='店长' then Convert(decimal(9,2),@AllSumMoney*CommissionRate+Wage)
                  when AllMoney is null then Convert(decimal(9,2),Wage)
                  else Convert(decimal(9,2),AllMoney*CommissionRate+Wage)
                 end 应发工资 
                 from SalesMan left join
                 (select SalesmanID SalesmanIDright,sum(AllMoney) AllMoney from Sales where SalesDate  between @start and @end group by SalesmanID) salesmanAll 
                 on SalesMan.SalesmanID=salesmanAll.SalesmanIDright");
            DBHelper.SetParameter("start",start);
            DBHelper.SetParameter("end",end);
            DataTable dt= DBHelper.ExecQuery();
            return dt;
        }
    }
}
