using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using ClothingDAL;
using ClothingEntity;

namespace ClothingDAL
{
    public class TypeDAL
    {
        //增
        public int TypeInsert(TypeEntity typeEntity)
        {
            DBHelper.PrepareSql("insert into [Type](TypeName) values(@TypeName)");
            DBHelper.SetParameter("TypeName", typeEntity.TypeName);
            return DBHelper.ExecNonQuery();
        }
        //删
        public int TypeDelete(TypeEntity typeEntity)
        {
            DBHelper.PrepareSql("Delete from [Type] where TypeID=@TypeID");
            DBHelper.SetParameter("TypeName", typeEntity.TypeID);
            return DBHelper.ExecNonQuery();
        }
        //改
        public int TypeUpdate(TypeEntity typeEntity)
        {
            DBHelper.PrepareSql("Update [Type] set TypeName=@TypeName where TypeID=@TypeID");
            DBHelper.SetParameter("TypeName", typeEntity.TypeName);
            DBHelper.SetParameter("TypeID", typeEntity.TypeID);
            return DBHelper.ExecNonQuery();
        }
        //查
        public List<TypeEntity> TypeSelect()
        {
            DBHelper.PrepareSql("select * from [Type]");
            List<TypeEntity> ListtypeEntities = new List<TypeEntity>();
            DataTable dataTable = new DataTable();
            dataTable = DBHelper.ExecQuery();
            foreach (DataRow dr in dataTable.Rows)
            {
                TypeEntity typeEntity = new TypeEntity();
                typeEntity.TypeID = int.Parse(dr["TypeID"].ToString());
                typeEntity.TypeName = dr["TypeName"].ToString();
                ListtypeEntities.Add(typeEntity);
            }
            return ListtypeEntities;

        }
        //详情查找
        public TypeEntity TypeSelect(int TypeID)
        {
            DBHelper.PrepareSql("select * from [Type] where TypeID=@TypeID");
            DBHelper.SetParameter("TypeID", TypeID);
            DataTable dataTable = new DataTable();
            dataTable = DBHelper.ExecQuery();
            TypeEntity typeEntity = new TypeEntity();
            typeEntity.TypeID = int.Parse(dataTable.Rows[0]["TypeID"].ToString());
            typeEntity.TypeName = dataTable.Rows[0]["TypeName"].ToString();
            return typeEntity;
        }
    }
}
