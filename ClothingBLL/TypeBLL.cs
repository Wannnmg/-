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
    public class TypeBLL
    {
        TypeDAL TypeDAL=new TypeDAL();
        //增
        public int TypeInsert(TypeEntity typeEntity)
        {
            return TypeDAL.TypeInsert(typeEntity);
        }
        //删
        public int TypeDelete(TypeEntity typeEntity)
        {
            return TypeDAL.TypeDelete(typeEntity);
        }
        //改
        public int TypeUpdate(TypeEntity typeEntity)
        {
            return TypeDAL.TypeUpdate(typeEntity);
        }
        //查
        public List<TypeEntity> TypeSelect()
        {
            
            return TypeDAL.TypeSelect();
        }
        //详情查找
        public TypeEntity TypeSelect(int TypeID)
        {
            return TypeDAL.TypeSelect(TypeID);
        }
    }
}
