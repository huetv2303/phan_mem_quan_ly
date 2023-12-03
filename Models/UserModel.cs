using phan_quan_ly_nhan_su.common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phan_quan_ly_nhan_su.Models
{
    public class UserModel : ConnectSql
    {
        public UserModel() : base("users")
        {

        }

        public dynamic getLogin(string username, string password)
        { 
            string sql = "select * from " + this.table + " where username='" + username   + "' and password='" + password+ "'";
           
            
            return this.ExecuteQuery(sql);
        }
    }
}
