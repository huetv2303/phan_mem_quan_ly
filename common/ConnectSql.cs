using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Dynamic;

namespace phan_quan_ly_nhan_su.common
{
    public class ConnectSql
    {
        private string connectionString = @"Data Source=DESKTOP-URN2QOU\TUONGHUE;Initial Catalog=QuanLyNhanSu;Integrated Security=True";

        protected string table;
        public ConnectSql(string table)
        {
            this.table = table;
        }

     


        public dynamic ExecuteQuery(string query)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    adapter.Fill(dataTable);
                    List<dynamic> result = new List<dynamic>();
                    foreach (DataRow row in dataTable.Rows)
                    {
                        dynamic item = new ExpandoObject();
                        foreach (DataColumn column in dataTable.Columns)
                        {
                            ((IDictionary<string, object>)item)[column.ColumnName] = row[column];
                        }
                        result.Add(item);
                    }

                    if(result.Count > 0)
                    {
                        return result;
                    } else
                    {
                        return null;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error executing query: {ex.Message}");
                    return null;
                }
                finally
                {
                    connection.Close();
                }
            }
           
        }


        public dynamic create(string columns, string values)
        {
            string sql = "insert into " + this.table + "(" + columns + ")" + "values (" + values + ")";

            return this.ExecuteQuery(sql);
        }

        public dynamic getData()
        {
            string sql = "select * from " + this.table ;
            return this.ExecuteQuery(sql);
        }

    }
}
