using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.ModelLogic
{
    public class AdminProcessor
    {
        public static bool CheckAdmin(string email, string password)
        {
            Admin data = new Admin
            {
                Email = email,
                Password = password,
            };

            string sql = @"SELECT* FROM dbo.Admin WHERE Email='"+data.Email+"' AND Password='"+data.Password+"'";
            return SqlDataAccess.CheckAdmin(sql, data);
        }
    }
}
