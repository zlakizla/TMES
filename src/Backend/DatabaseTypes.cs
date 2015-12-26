using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Backend
{
    public class Dataset
    {
        public List<Row> Rows;
        public Dataset(SqlDataReader dr)
        {
            Rows = new List<Row>();
            Int32 Index = 0;
            while(dr.Read())
            {
                var Row = new Row(Index);
                for(int i = 0; i < dr.FieldCount; i++)
                {
                    Row.Columns.Add(new Column(dr.GetName(i),dr[i]));
                }
                Rows.Add(Row);
                Index++;
            }
        }
    }

    public class Row
    {
        public Int32 Index;
        public List<Column> Columns;
        public Object this[String ColumnName]
        {
            get
            {     
                var Column = Columns.FirstOrDefault(x => x.Name == ColumnName);
                if(Column == null)
                {
                    return null;
                }
                return Column.Value;
            }
        }
        
        public Row(Int32 Index)
        {
            this.Index = Index;
            this.Columns = new List<Column>();
        }
    }

    public class Column
    {
        public String Name;
        public Object Value;
        public Column(String Name, Object Value)
        {
            this.Name = Name;
            this.Value = Value;
        }
    }
}