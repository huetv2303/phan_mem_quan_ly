using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Dynamic;
using Newtonsoft.Json;

namespace phan_quan_ly_nhan_su.common
{
    public class ConnectSql
    {
        private string str = @"Data Source=DESKTOP-URN2QOU\TUONGHUE;Initial Catalog=QuanLyNhanSuSQL;Integrated Security=True";

        

        protected string table;

        public ConnectSql(string table)
        {
            this.table = table;
        }

        public dynamic ExecuteQuery(string query)
        {  //B1: ket not db
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();
                //B2: tao doi tuong command thuc hien truy van
                SqlCommand cmd = new SqlCommand(query, conn);
                //B3: Đổ dl từ dataadapter để lấy dữ liệu truy cập
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.SelectCommand = cmd;

                dt.Clear();
                adapter.Fill(dt);

                conn.Close();
            }

            return dt;

        }
        private Dictionary<string, dynamic> handleData(Dictionary<string, dynamic> data)
        {
            Dictionary<string, dynamic> result = new Dictionary<string, dynamic>();

            foreach (var item in data)
            {
                if (item.Value != "")
                {
                    result[item.Key] = $"'{item.Value}'";
                }
            }

            return result;
        }
        public string buildSqlCreate(Dictionary<string, dynamic> data)
        {
            List<string> colunms = new List<string>(data.Keys);
            List<dynamic> values = new List<dynamic>(data.Values);

            string colunms1 = string.Join(",", colunms);
            string values1 = string.Join(",", values);


            string sql = $"Insert into {this.table} ({colunms1}) Values ({values1})";


            return sql;
        }
        public dynamic create(Dictionary<string, dynamic> data)
        {
            Dictionary<string, dynamic> chuanBiDuLieu = this.handleData(data);


            string sql = buildSqlCreate(chuanBiDuLieu);
            return this.ExecuteQuery(sql);
        }

        public dynamic show(string condition = null)
        {
            string sql = $"Select * from {this.table}";

            if (condition != null)
            {
                sql += $" where {condition}";
            }

            return this.ExecuteQuery(sql);
        }

        public dynamic delete(string columns, string condition)
        {
            string sql = $"Delete from  {this.table} where {columns} = {condition}";
            Console.WriteLine(sql); ;
            return this.ExecuteQuery(sql);
        }

        public dynamic update(Dictionary<string, dynamic> data, string condition)
        {
            /* return this.ExecuteQuery($"update {this.table} set {sql} where {condition}");
  */
            string sql = this.buildSqlUpdate(data, condition);
            return this.ExecuteQuery(sql);


        }
        public string buildSqlUpdate(Dictionary<string, dynamic> data, string condition)
        {

            /** 
             
                set data moi phai co dang nhu sau: col = v, col = v, ...

                B1: convert data thanh mang  sau ["col = v", "col = v", ...] 
                B2: tan mang tren + join de co duoc chuoi mong muon
             */
            List<string> colAndValue = new List<string>(); /* <=> colAndValue = [] */

            foreach (var item in data)
            {
                string value = $"{item.Key} = '{item.Value}'";
                colAndValue.Add(value);
            }


            string set = string.Join(",", colAndValue);

            string sql = $"Update {this.table} Set {set} Where {condition} ";

            return sql;
        }


        protected List<dynamic> ConvertDataTableToArrayOfArrays(DataTable dt)
        {
            List<dynamic> result = new List<dynamic>();

            foreach (DataRow row in dt.Rows)
            {
                dynamic item = new System.Dynamic.ExpandoObject();
                var dictionary = (IDictionary<string, object>)item;

                foreach (DataColumn col in dt.Columns)
                {
                    dictionary[col.ColumnName] = row[col];
                }

                result.Add(item);
            }

            if (result.Count == 0)
            {
                return null;
            }

            return result;
        }
    }


}
