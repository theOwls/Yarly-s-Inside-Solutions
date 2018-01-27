using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Reflection;
using System.ComponentModel.DataAnnotations.Schema;
using YIS.GDPDataHandler.Extensions;

namespace YIS.GDPDataHandler.Factories
{
    public class EntityDataTableFactory: IEntityDataTableFactory
    {
        public DataTable CreateDataTableFrom<T>(List<T> entityList) where T : class
        {
            DataTable entityTable = CreateDataTableFor(entityList);
            foreach(var entity in entityList)
            {
                GenerateDataRowFrom(entity, ref entityTable);
            }
            return entityTable;
        }
        
        private DataTable CreateDataTableFor<T>(List<T> entityList) where T : class
        {
            Type classType = entityList.First().GetType();
            List<PropertyInfo> propertyList
                = classType.GetProperties()
                .Where(p => p.GetCustomAttributes(typeof(NotMappedAttribute)).Any() == false)
                .ToList();
            
            string entityName = classType.UnderlyingSystemType.Name;
            DataTable entityTable = new DataTable(entityName);

            foreach(PropertyInfo prop in propertyList)
            {
                DataColumn column = new DataColumn();
                column.ColumnName = prop.Name;
                Type dataType = prop.PropertyType;
                if (IsNullable(dataType))
                {
                    if (dataType.IsGenericType)
                    {
                        dataType = dataType.GenericTypeArguments.FirstOrDefault();
                    }
                }
                else
                {
                    column.AllowDBNull = false;
                }
                column.DataType = dataType;
                entityTable.Columns.Add(column);
            }
            return entityTable;
        }

        private void GenerateDataRowFrom<T>(T entity, ref DataTable entityDataTable) where T : class
        {
            Type classType = entity.GetType();
            DataRow row = entityDataTable.NewRow();
            List<PropertyInfo> entityPropertyInfoList = classType.GetProperties().ToList();
            foreach(PropertyInfo prop in entityPropertyInfoList)
            {
                if (entityDataTable.Columns.Contains(prop.Name))
                {
                    if (entityDataTable.Columns[prop.Name].IsNotNull())
                    {
                        row[prop.Name] = prop.GetValue(entity, null) ?? DBNull.Value;
                    }
                }
            }
            entityDataTable.Rows.Add(row);
        }

        private bool IsNullable(Type type)
        {
            if (type.IsValueType.IsFalse())
                return true;

            if (Nullable.GetUnderlyingType(type).IsNotNull())
                return true;

            return false;
        }
    }
}
