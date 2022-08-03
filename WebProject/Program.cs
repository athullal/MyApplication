using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;

namespace WebProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //string constr = "SERVER=localhost;DATABASE=EmployeeDB;USERNAME=root;PASSWORD=rootpass";

            //string query = @"select * from Department";

            //DataTable table = new DataTable();
            //MySqlDataReader myReader;
            //using (MySqlConnection myCon = new MySqlConnection(constr))
            //{
            //    myCon.Open();
            //    using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
            //    {
            //        myReader = myCommand.ExecuteReader();
            //        table.Load(myReader);
            //        myReader.Close();
            //        myCon.Close();
            //    }
            //}

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

