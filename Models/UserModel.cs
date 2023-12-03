using phan_quan_ly_nhan_su.common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace phan_quan_ly_nhan_su.Models
{
    public class UserModel : ConnectSql
    {
        public UserModel() : base("users")
        {

        }

        public dynamic getLogin(string username = "", string password = "")
        {
            string condition = $"username = '{username}' and pass = '{password}'";

            dynamic user = this.show(condition);

            dynamic userObject = this.ConvertDataTableToArrayOfArrays(user);

            if (userObject  == null )
            {
                Console.WriteLine("Tài khoản không hợp lệ");
            } else
            {

                Console.WriteLine("đang nhạp thanh cong");
                /**
                    * Chuyển màn khác
                    */

            }

            /**
             * string dtJson = JsonConvert.SerializeObject(userObject);
                Console.WriteLine(dtJson);
            */


            return 0;
        }

        
    }
}
