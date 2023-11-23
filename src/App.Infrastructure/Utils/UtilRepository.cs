using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection;

namespace App.Infrastructure.Utils
{
    public class UtilRepository
    {
        public object SetDbString(string param)
        {
            if (param == null)
            {
                return DBNull.Value;
            }
            return param;
        }

        public object SetDbInt(int? param)
        {
            if (param == null)
            {
                return DBNull.Value;
            }

            return param;
        }

        public object SetDbDecimal(decimal? param)
        {
            if (param == null)
            {
                return DBNull.Value;
            }

            return param;
        }

        public object SetDbFloat(float? param)
        {
            if (param == null)
            {
                return DBNull.Value;
            }

            return param;
        }

        public object SetDbDateTime(DateTime? param)
        {
            if (param == null)
            {
                return DBNull.Value;
            }

            return param;
        }

        public object SetDbDate(DateOnly? param)
        {
            if (param == null)
            {
                return DBNull.Value;
            }

            return param;
        }

        public object SetDbDateTime(string param, string format)
        {

            try
            {
                if (string.IsNullOrEmpty(param) || string.IsNullOrEmpty(format))
                {
                    return DBNull.Value;
                }

                DateTime fecha = DateTime.ParseExact(param, format, System.Globalization.CultureInfo.InvariantCulture);

                return fecha;

            }
            catch (Exception ex)
            {
                return DBNull.Value;
            }

        }

        public object SetDbBoolean(bool? param)
        {
            if (param == null)
            {
                return false;
            }

            return param;
        }
        protected int GetDbInt(SqlDataReader reader, string paramReader)
        {
           
            try
            {
                return reader[paramReader] == DBNull.Value ? 0 : Convert.ToInt32(reader[paramReader]);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        protected decimal GetDbDecimal(SqlDataReader reader, string paramReader)
        {
            try
            {
                return reader[paramReader] == DBNull.Value ? 0 : (decimal)reader[paramReader];
            }
            catch (Exception ex)
            {
                return 0;
            }
            
        }
        protected float GetDbFloat(SqlDataReader reader, string paramReader)
        {
            try
            {
                return reader[paramReader] == DBNull.Value ? 0 : (float)(double)reader[paramReader];
            }
            catch (Exception ex)
            {
                return 0;
            }

        }
        protected string GetDbString(SqlDataReader reader, string paramReader)
        {
            try
            {
                return reader[paramReader] == DBNull.Value ? string.Empty : reader[paramReader].ToString();
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
            
        }

        protected char GetDbChar(SqlDataReader reader, string paramReader)
        {
            return reader[paramReader] == DBNull.Value ? '\0' : Convert.ToChar(reader[paramReader]);
        }

        protected DateTime? GetDbDateTime(SqlDataReader reader, string paramReader)
        {
            return reader[paramReader] == DBNull.Value ? (DateTime?)null : (DateTime)reader[paramReader];
        }

        protected string GetDbDateTimeToString(SqlDataReader reader, string paramReader, string format)
        {
            return reader[paramReader] == DBNull.Value ? string.Empty : Convert.ToDateTime(reader[paramReader]).ToString(format);
        }

        protected bool GetDbBoolean(SqlDataReader reader, string paramReader)
        {
            return reader[paramReader] != DBNull.Value && Convert.ToBoolean(reader[paramReader]);
        }

        public DataTable ConvertListToDatatable<T>(IList<T> items)
        {
            var dataTable = new DataTable();
            Type itemsType = typeof(T);
            foreach (PropertyInfo prop in itemsType.GetProperties())
            {
                var column = new DataColumn(prop.Name)
                {
                    DataType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType
                };
                dataTable.Columns.Add(column);
            }
            foreach (var item in items)
            {
                int j = 0;
                object[] newRow = new object[dataTable.Columns.Count];
                foreach (PropertyInfo prop in itemsType.GetProperties())
                {
                    newRow[j] = prop.GetValue(item, null);
                    if (newRow[j] != null)
                    {
                        if (newRow[j].ToString().Length > 4000)
                        {
                            newRow[j] = newRow[j].ToString().Substring(0, 4000);
                        }
                    }
                    j++;
                }
                dataTable.Rows.Add(newRow);
            }
            return dataTable;
        }


    }
}
