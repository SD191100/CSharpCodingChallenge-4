using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Util
{
    public class DBConnUtil
    {
        private static IConfigurationRoot _configuration;
        static string s = null;

        static DBConnUtil() {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("C:\\Users\\shiva\\source\\repos\\InsuranceManagementSystem\\Util\\appSettings.json", optional: true, reloadOnChange: true);
            _configuration = builder.Build();
        }

        public static string ReturnCn(string key)
        {
            //if (_connection == null)
            //{
            //    _connection = new SqlConnection(connectionString);
            //}
            //return _connection;
            s = _configuration.GetConnectionString("dbCn");
            return s;
        }
    }
}
